using System;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Booking;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace NamolyOnPremises.Module.Web.Controllers.Hotel.Booking
{
    public partial class HotelFolioOnlySelectOneRowListView : ViewController
    {
        HotelFolio _Folio = null;
        ListView _ChargeRulesNestedListView = null;
        DetailView _DetailView = null;


        public HotelFolioOnlySelectOneRowListView()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetViewId = "HotelBooking_DetailView";
        }

        protected override void OnActivated()
        {
            base.OnActivated();
         // Perform various tasks depending on the target View.
            _DetailView = View as DetailView;
            ListPropertyEditor foliosListPropertyEditor = _DetailView.FindItem("Folios") as ListPropertyEditor;
            if (foliosListPropertyEditor != null)
                foliosListPropertyEditor.ControlCreated += foliosListPropertyEditor_ControlCreated;


            ListPropertyEditor chargeRulesListPropertyEditor = ((DetailView)View).FindItem("ChargeRules") as ListPropertyEditor;
            if (chargeRulesListPropertyEditor != null)
                chargeRulesListPropertyEditor.ControlCreated += chargeRulesListPropertyEditor_ControlCreated;
        }




        // ChargeRules
        void chargeRulesListPropertyEditor_ControlCreated(object sender, EventArgs e)
        {
            ListPropertyEditor chargeRulesListPropertyEditor = (ListPropertyEditor)sender;
            _ChargeRulesNestedListView = chargeRulesListPropertyEditor.ListView;

            try
            {
                ASPxGridListEditor chargeRulesGrid = _ChargeRulesNestedListView.Editor as ASPxGridListEditor;
                chargeRulesGrid.NewObjectAdding += chargeRulesGrid_NewObjectAdding;
            }
            catch { }

            if (_Folio != null)
                _ChargeRulesNestedListView.CollectionSource.Criteria["FilterListViewChargeRules"] = new BinaryOperator("Folio.Oid", _Folio.Oid);
            else
                _ChargeRulesNestedListView.CollectionSource.Criteria["FilterListViewChargeRules"] = CriteriaOperator.Parse("1 = 2");
        }

        void chargeRulesGrid_NewObjectAdding(object sender, NewObjectAddingEventArgs e)
        {
            if (e == null) return;
            if (e.AddedObject == null) return;
            if (!(e.AddedObject is HotelFolioDetailChargeRule)) return;
            HotelFolioDetailChargeRule hotelFolioDetailChargeRule = e.AddedObject as HotelFolioDetailChargeRule;
            if (_Folio != null)
            {
                hotelFolioDetailChargeRule.Folio = _Folio;
            }
        }














        // Folios
        void foliosListPropertyEditor_ControlCreated(object sender, EventArgs e)
        {
            ListPropertyEditor foliosListPropertyEditor = sender as ListPropertyEditor;
            if (foliosListPropertyEditor != null)
                if (foliosListPropertyEditor.ListView != null)
                {
                    ListView foliosListView = foliosListPropertyEditor.ListView;
                    foliosListView.ControlsCreated += foliosListView_ControlsCreated;
                }
        }

        void foliosListView_ControlsCreated(object sender, EventArgs e)
        {
            ListView foliosListView = sender as ListView;
            if (foliosListView.Editor != null)
            {
                ASPxGridListEditor aSPxGridListEditor = foliosListView.Editor as ASPxGridListEditor;
                try
                {
                    aSPxGridListEditor.Grid.SettingsBehavior.AllowSelectSingleRowOnly = true;
                }
                catch { }
            }
            foliosListView.SelectionChanged += foliosListView_SelectionChanged;
        }

        void foliosListView_SelectionChanged(object sender, EventArgs e)
        {
            ListView foliosListView = sender as ListView;
            try
            {
                _Folio = foliosListView.Editor.GetSelectedObjects()[0] as HotelFolio;
            }
            catch { _Folio = null; }
        }













        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated()
        {
            DetailView detailView = View as DetailView;
            ListPropertyEditor foliosListView = detailView.FindItem("Folios") as ListPropertyEditor;
            if (foliosListView != null)
                foliosListView.ControlCreated -= foliosListPropertyEditor_ControlCreated;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
