// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2010 Krzysztof Marecki
// Copyright (c) 2007 Novell, Inc.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace GtkForms
{
	[SerializableAttribute] 
	public class NotifiedBindingList<T> : BaseCollection<T>,
		IBindingList, IList, ICollection, 
		IEnumerable, ICancelAddNew, IRaiseItemChangedEvents
	{
		bool allow_edit = true;
		bool allow_remove = true;
		bool allow_new;
		bool allow_new_set;

		bool raise_list_changed_events = true;
		
		bool type_has_default_ctor;
		bool type_raises_item_changed_events;

		bool add_pending;
		int pending_add_index;
		
		PropertyChangedEventHandler property_changed_event_handler;
		Collection<T> collection;

		void CheckType ()
		{
			ConstructorInfo ci = typeof (T).GetConstructor (Type.EmptyTypes);
			type_has_default_ctor = (ci != null);
			type_raises_item_changed_events = typeof (INotifyPropertyChanged).IsAssignableFrom (typeof (T));
		}

		public NotifiedBindingList (IList<T> list) : base(list)
		{
			CheckType ();
			property_changed_event_handler = new PropertyChangedEventHandler (PropertyChangedHandler);
		}

		public NotifiedBindingList () : base ()
		{
			CheckType ();
			property_changed_event_handler = new PropertyChangedEventHandler (PropertyChangedHandler);
		}
		
		public NotifiedBindingList (IEnumerable list)
			: base ()
		{
			foreach (var item in list) {
				Add ((T) item);
			}
		}

		public bool AllowEdit {
			get { return allow_edit; }
			set {
				if (allow_edit != value) {
					allow_edit = value;

					if (raise_list_changed_events)
						OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, -1 /* XXX */));
				}
			}
		}

		public bool AllowNew {
			get {
				/* if the user explicitly it, return that value */
				if (allow_new_set)
					return allow_new;

				/* if the list type has a default constructor we allow new */
				if (type_has_default_ctor)
					return true;

				/* if the user adds a delegate, we return true even if
				   the type doesn't have a default ctor */
				if (AddingNew != null)
					return true;

				return false;
			}
			set {
				// this funky check (using AllowNew
				// instead of allow_new allows us to
				// keep the logic for the 3 cases in
				// one place (the getter) instead of
				// spreading them around the file (in
				// the ctor, in the AddingNew add
				// handler, etc.
				if (AllowNew != value) {
					allow_new_set = true;

					allow_new = value;

					if (raise_list_changed_events)
						OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, -1 /* XXX */));
				}
			}
		}

		public bool AllowRemove {
			get { return allow_remove; }
			set {
				if (allow_remove != value) {
					allow_remove = value;

					if (raise_list_changed_events)
						OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, -1 /* XXX */));
				}
			}
		}

		protected virtual bool IsSortedCore {
			get { return false; }
		}

		public bool RaiseListChangedEvents {
			get { return raise_list_changed_events; }
			set { raise_list_changed_events = value; }
		}

		protected virtual ListSortDirection SortDirectionCore {
			get { return ListSortDirection.Ascending; }
		}

		protected virtual PropertyDescriptor SortPropertyCore {
			get { return null; }
		}

		protected virtual bool SupportsChangeNotificationCore {
			get { return true; }
		}

		protected virtual bool SupportsSearchingCore {
			get { return false; }
		}

		protected virtual bool SupportsSortingCore {
			get { return false; }
		}

		public event AddingNewEventHandler AddingNew;
		public event ListChangedEventHandler ListChanged;
		
		public T AddNew ()
		{
			return (T)AddNewCore ();
		}

		protected virtual object AddNewCore ()
		{
			if (!AllowNew)
				throw new InvalidOperationException ();

			AddingNewEventArgs args = new AddingNewEventArgs ();

			OnAddingNew (args);

			T new_obj = (T)args.NewObject;
			if (new_obj == null) {
				if (!type_has_default_ctor)
					throw new InvalidOperationException ();

				new_obj = (T)Activator.CreateInstance (typeof (T));
			}

			Add (new_obj);
			pending_add_index = IndexOf (new_obj);
			add_pending = true;
			
			return new_obj;
		}

		protected virtual void ApplySortCore (PropertyDescriptor prop, ListSortDirection direction)
		{
			throw new NotSupportedException ();
		}

		public virtual void CancelNew (int itemIndex)
		{
			if (!add_pending)
				return;

			if (itemIndex != pending_add_index)
				return;

			add_pending = false;

			base.RemoveItem (itemIndex);

			if (raise_list_changed_events)
				OnListChanged (new ListChangedEventArgs (ListChangedType.ItemDeleted, itemIndex));
		}

		protected override void ClearItems ()
		{
			EndNew (pending_add_index);
			
			if (type_raises_item_changed_events) {
				
				INotifyPropertyChanged notified = null;
				
				foreach (T item in this) {
					notified = item as INotifyPropertyChanged;
					if (notified != null)
						notified.PropertyChanged -= PropertyChangedHandler;
				}
			}

			base.ClearItems ();

			OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, -1));
		}

		public virtual void EndNew (int itemIndex)
		{
			if (!add_pending)
				return;

			if (itemIndex != pending_add_index)
				return;

			add_pending = false;
		}
		
		protected virtual int FindCore (PropertyDescriptor prop, object key)
		{
			for (int index = 0; index < base.Count; index++) {
				T current = base[index];
				object propval = prop.GetValue (current);
				if (Comparer.Default.Compare (key, propval) == 0) {
					return index;
				}
			}
			
			return -1;
		}

		protected override void InsertItem (int index, T item)
		{
			EndNew (pending_add_index);

			base.InsertItem (index, item);

			if (type_raises_item_changed_events) {
				var notified = item as INotifyPropertyChanged;
				if (notified != null)
					notified.PropertyChanged += PropertyChangedHandler;
			}
			
			if (raise_list_changed_events)
				OnListChanged (new ListChangedEventArgs (ListChangedType.ItemAdded, index));
		}

		protected virtual void OnAddingNew (AddingNewEventArgs e)
		{
			if (AddingNew != null)
				AddingNew (this, e);
		}

		protected virtual void OnListChanged (ListChangedEventArgs e)
		{
			if (ListChanged != null)
				ListChanged (this, e);
		}

		protected override void RemoveItem (int index)
		{
			if (!AllowRemove)
				throw new NotSupportedException ();

			EndNew (pending_add_index);

			if (type_raises_item_changed_events) {
				var notified = this [index] as INotifyPropertyChanged;
				if (notified != null)
					notified.PropertyChanged -= PropertyChangedHandler;
			}
			
			base.RemoveItem (index);
			
			if (raise_list_changed_events)
				OnListChanged (new ListChangedEventArgs (ListChangedType.ItemDeleted, index));
		}

		protected virtual void RemoveSortCore ()
		{
			throw new NotSupportedException ();
		}

		public void ResetBindings ()
		{
			OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, -1));
		}

		public void ResetItem (int position)
		{
			OnListChanged (new ListChangedEventArgs (ListChangedType.ItemChanged, position));
		}

		protected override void SetItem (int index, T item)
		{
			INotifyPropertyChanged notified = null;
			
			if (type_raises_item_changed_events) {
				notified = this [index] as INotifyPropertyChanged;
				if (notified != null)
					notified.PropertyChanged -= PropertyChangedHandler;
			}
			
			base.SetItem (index, item);
			
			if (type_raises_item_changed_events) {
				notified = item as INotifyPropertyChanged;
				if (notified != null)
					notified.PropertyChanged += PropertyChangedHandler;
			}
				
			OnListChanged (new ListChangedEventArgs (ListChangedType.ItemChanged, index));
		}
		
		

		void IBindingList.AddIndex (PropertyDescriptor index)
		{
			/* no implementation by default */
		}

		object IBindingList.AddNew ()
		{
			return AddNew ();
		}

		void IBindingList.ApplySort (PropertyDescriptor property, ListSortDirection direction)
		{
			ApplySortCore (property, direction);
		}

		int IBindingList.Find (PropertyDescriptor property, object key)
		{
			return FindCore (property, key);
		}

		void IBindingList.RemoveIndex (PropertyDescriptor property)
		{
			/* no implementation by default */
		}

		void IBindingList.RemoveSort ()
		{
			RemoveSortCore ();
		}

		bool IBindingList.IsSorted {
			get { return IsSortedCore; }
		}

		ListSortDirection IBindingList.SortDirection {
			get { return SortDirectionCore; }
		}

		PropertyDescriptor IBindingList.SortProperty {
			get { return SortPropertyCore; }
		}

		bool IBindingList.AllowEdit {
			get { return AllowEdit; }
		}

		bool IBindingList.AllowNew {
			get { return AllowNew; }
		}

		bool IBindingList.AllowRemove {
			get { return AllowRemove; }
		}

		bool IBindingList.SupportsChangeNotification {
			get { return SupportsChangeNotificationCore; }
		}

		bool IBindingList.SupportsSearching {
			get { return SupportsSearchingCore; }
		}

		bool IBindingList.SupportsSorting {
			get { return SupportsSortingCore; }
		}

		bool IRaiseItemChangedEvents.RaisesItemChangedEvents {
			get { return type_raises_item_changed_events; }
		}
		
		void PropertyChangedHandler (object sender, PropertyChangedEventArgs args)
		{
			int index = IndexOf ((T)sender);
			
			if (index >= 0)
				OnListChanged (new ListChangedEventArgs (ListChangedType.ItemChanged, index));
		}
	}
	
	public class NotifiedBindingList : NotifiedBindingList<object>
	{
	}

}