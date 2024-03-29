// 
//  CalendarWindow.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;

namespace GtkForms.Custom
{
	public partial class CalendarWindow : Gtk.Window
	{
		public CalendarWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			calendar.DaySelectedDoubleClick += Calendar_DaySelectedDoubleClick;
		}
		
		public DateTime Date {
			get { return calendar.Date; }
			set { calendar.Date = value; }
		}

		protected override void OnShown ()
		{
			base.OnShown ();
			GrabFocus ();
		}
		
		protected virtual void Calendar_DaySelectedDoubleClick (object sender, System.EventArgs e)
		{
			Hide ();
		}
		
		protected virtual void GtkFormsCustomCalendarWindow_FocusOutEvent (object o, Gtk.FocusOutEventArgs args)
		{
			Hide ();
		}
	}
}

