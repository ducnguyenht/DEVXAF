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

namespace Solution1.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ViewController1 : ViewController
    {
        public ViewController1()
        {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
        }
        private ExportController exportController;
        protected override void OnActivated()
        {
            base.OnActivated();
            exportController = Frame.GetController<ExportController>();
            if (exportController != null)
            {
                exportController.CustomGetDefaultFileName += exportController_CustomGetDefaultFileName;
            }
        }
        void exportController_CustomGetDefaultFileName(
            object sender, CustomGetDefaultFileNameEventArgs e)
        {
            //Provide a custom file name 
            e.FileName = e.FileName + "_" + DateTime.Now.ToString("MM.dd.yy");
            //if (e.ExportTarget == ExportTarget.Xls)
            //{
            //    XlsExportOptions options = (XlsExportOptions)e.ExportOptions;
            //    if (options == null)
            //    {
            //        options = new XlsExportOptions();
            //    }
            //    options.SheetName = View.Caption;
            //    options.ShowGridLines = true;
            //    e.ExportOptions = options;
            //}
        }
        protected override void OnDeactivated()
        {
            if (exportController != null)
            {
                exportController.CustomGetDefaultFileName -= exportController_CustomGetDefaultFileName;
            }
            base.OnDeactivated();
        }
    }
}
