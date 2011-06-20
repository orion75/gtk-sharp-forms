// 
//  MainWindow.cs
//  
//  Author:
//       Krzysztof Marecki <>
// 
//  Copyright (c) 2011 Krzysztof Marecki
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
using Gtk;
using GtkForms;
using CheckBoxBinding;

public partial class MainWindow: FormsWindow
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	
		Status status = new Status ();
		status.Enabled = true;
		check.DataBindings.Add ("Active", status, "Enabled", 
			false, DataSourceUpdateMode.OnPropertyChanged);
		label.DataBindings.Add ("Visible", status, "Enabled");
		entry.DataBindings.Add ("Visible", status, "Enabled");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
