// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

// This file has been generated by the GUI designer. Do not modify.


public partial class MainWindow
{
	
	private global::Gtk.HBox hbox1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::GtkForms.FormsGridView gridview;
	private global::Gtk.Table table1;
	private global::Gtk.Alignment alignmentFavourite;
	private global::GtkForms.FormsCheckButton checkFavourite;
	private global::Gtk.Alignment alignmentPrice;
	private global::GtkForms.FormsSpinButton spinPrice;
	private global::Gtk.Button buttonLoad;
	private global::GtkForms.FormsEntry entryID;
	private global::GtkForms.FormsEntry entryName;
	private global::Gtk.Label labelError;
	private global::GtkForms.FormsLabel labelFavourite;
	private global::GtkForms.FormsLabel labelID;
	private global::GtkForms.FormsLabel labelName;
	private global::GtkForms.FormsLabel labelPrice;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.gridview = new global::GtkForms.FormsGridView ();
		this.gridview.CanFocus = true;
		this.gridview.Name = "gridview";
		this.gridview.AutoGenerateColumns = true;
		this.gridview.FontSize = 10;
		this.GtkScrolledWindow.Add (this.gridview);
		this.hbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.GtkScrolledWindow]));
		w2.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table (((uint)(6)), ((uint)(2)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		this.table1.BorderWidth = ((uint)(4));
		// Container child table1.Gtk.Table+TableChild
		this.alignmentFavourite = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignmentFavourite.Name = "alignmentFavourite";
		// Container child alignmentFavourite.Gtk.Container+ContainerChild
		this.checkFavourite = new global::GtkForms.FormsCheckButton ();
		this.checkFavourite.CanFocus = true;
		this.checkFavourite.Name = "checkFavourite";
		this.checkFavourite.Label = "";
		this.checkFavourite.DrawIndicator = true;
		this.checkFavourite.FontSize = 10;
		this.alignmentFavourite.Add (this.checkFavourite);
		this.table1.Add (this.alignmentFavourite);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignmentFavourite]));
		w4.TopAttach = ((uint)(3));
		w4.BottomAttach = ((uint)(4));
		w4.LeftAttach = ((uint)(1));
		w4.RightAttach = ((uint)(2));
		w4.XOptions = ((global::Gtk.AttachOptions)(4));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.alignmentPrice = new global::Gtk.Alignment (1F, 0.5F, 0F, 1F);
		this.alignmentPrice.Name = "alignmentPrice";
		// Container child alignmentPrice.Gtk.Container+ContainerChild
		this.spinPrice = new global::GtkForms.FormsSpinButton ();
		this.spinPrice.WidthRequest = 60;
		this.spinPrice.CanFocus = true;
		this.spinPrice.Name = "spinPrice";
		this.alignmentPrice.Add (this.spinPrice);
		this.table1.Add (this.alignmentPrice);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignmentPrice]));
		w6.TopAttach = ((uint)(2));
		w6.BottomAttach = ((uint)(3));
		w6.LeftAttach = ((uint)(1));
		w6.RightAttach = ((uint)(2));
		w6.XOptions = ((global::Gtk.AttachOptions)(4));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.buttonLoad = new global::Gtk.Button ();
		this.buttonLoad.CanFocus = true;
		this.buttonLoad.Name = "buttonLoad";
		this.buttonLoad.UseUnderline = true;
		this.buttonLoad.Label = global::Mono.Unix.Catalog.GetString ("Load");
		this.table1.Add (this.buttonLoad);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.buttonLoad]));
		w7.TopAttach = ((uint)(5));
		w7.BottomAttach = ((uint)(6));
		w7.LeftAttach = ((uint)(1));
		w7.RightAttach = ((uint)(2));
		w7.XOptions = ((global::Gtk.AttachOptions)(4));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.entryID = new global::GtkForms.FormsEntry ();
		this.entryID.CanFocus = true;
		this.entryID.Name = "entryID";
		this.entryID.IsEditable = true;
		this.entryID.InvisibleChar = '●';
		this.entryID.FontSize = 10;
		this.table1.Add (this.entryID);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.entryID]));
		w8.LeftAttach = ((uint)(1));
		w8.RightAttach = ((uint)(2));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.entryName = new global::GtkForms.FormsEntry ();
		this.entryName.CanFocus = true;
		this.entryName.Name = "entryName";
		this.entryName.IsEditable = true;
		this.entryName.InvisibleChar = '●';
		this.entryName.FontSize = 10;
		this.table1.Add (this.entryName);
		global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.entryName]));
		w9.TopAttach = ((uint)(1));
		w9.BottomAttach = ((uint)(2));
		w9.LeftAttach = ((uint)(1));
		w9.RightAttach = ((uint)(2));
		w9.XOptions = ((global::Gtk.AttachOptions)(4));
		w9.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.labelError = new global::Gtk.Label ();
		this.labelError.Name = "labelError";
		this.labelError.LabelProp = global::Mono.Unix.Catalog.GetString ("error message");
		this.table1.Add (this.labelError);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelError]));
		w10.TopAttach = ((uint)(4));
		w10.BottomAttach = ((uint)(5));
		w10.RightAttach = ((uint)(2));
		w10.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.labelFavourite = new global::GtkForms.FormsLabel ();
		this.labelFavourite.Name = "labelFavourite";
		this.labelFavourite.Xalign = 1F;
		this.labelFavourite.Yalign = 0F;
		this.labelFavourite.LabelProp = global::Mono.Unix.Catalog.GetString ("Favourite");
		this.labelFavourite.FontSize = 10;
		this.table1.Add (this.labelFavourite);
		global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelFavourite]));
		w11.TopAttach = ((uint)(3));
		w11.BottomAttach = ((uint)(4));
		w11.XOptions = ((global::Gtk.AttachOptions)(4));
		w11.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.labelID = new global::GtkForms.FormsLabel ();
		this.labelID.Name = "labelID";
		this.labelID.Xalign = 1F;
		this.labelID.Yalign = 0F;
		this.labelID.LabelProp = global::Mono.Unix.Catalog.GetString ("ID");
		this.labelID.FontSize = 10;
		this.table1.Add (this.labelID);
		global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelID]));
		w12.XOptions = ((global::Gtk.AttachOptions)(4));
		w12.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.labelName = new global::GtkForms.FormsLabel ();
		this.labelName.Name = "labelName";
		this.labelName.Xalign = 1F;
		this.labelName.Yalign = 0F;
		this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString ("Company name\n");
		this.labelName.FontSize = 10;
		this.table1.Add (this.labelName);
		global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelName]));
		w13.TopAttach = ((uint)(1));
		w13.BottomAttach = ((uint)(2));
		w13.XOptions = ((global::Gtk.AttachOptions)(4));
		w13.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.labelPrice = new global::GtkForms.FormsLabel ();
		this.labelPrice.Name = "labelPrice";
		this.labelPrice.Xalign = 1F;
		this.labelPrice.Yalign = 0F;
		this.labelPrice.LabelProp = global::Mono.Unix.Catalog.GetString ("Price");
		this.labelPrice.FontSize = 10;
		this.table1.Add (this.labelPrice);
		global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelPrice]));
		w14.TopAttach = ((uint)(2));
		w14.BottomAttach = ((uint)(3));
		w14.XOptions = ((global::Gtk.AttachOptions)(4));
		w14.YOptions = ((global::Gtk.AttachOptions)(4));
		this.hbox1.Add (this.table1);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.table1]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		this.Add (this.hbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 651;
		this.DefaultHeight = 300;
		this.labelError.Hide ();
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.entryName.Validating += new global::System.ComponentModel.CancelEventHandler (this.OnEntryNameValidating);
		this.buttonLoad.Clicked += new global::System.EventHandler (this.ButtonLoad_Clicked);
	}
}
