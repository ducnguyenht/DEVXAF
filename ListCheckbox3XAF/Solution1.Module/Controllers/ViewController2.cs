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
using DevExpress.XtraPrinting;
namespace Solution1.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class ViewController2 : ViewController
    {
        public ViewController2()
        {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
        }
        private ExportController exportController;
        protected override void OnActivated()
        {
            base.OnActivated();
            exportController = Frame.GetController<ExportController>();
            exportController.CustomExport += new EventHandler<CustomExportEventArgs>(CustomExport);
        }
        protected virtual void CustomExport(object sender, CustomExportEventArgs e)
        {
            //e.FileName = e.FileName + "_" + DateTime.Now.ToString("MM.dd.yy");
            //Customize Export Options 
            if (e.ExportTarget == ExportTarget.Xls)
            {
                XlsExportOptions options = (XlsExportOptions)e.ExportOptions;
                if (options == null)
                {
                    options = new XlsExportOptions();
                }
                options.SheetName = View.Caption;
                options.ShowGridLines = true;
                e.ExportOptions = options;
                var t = 1;
            }
        }
        protected override void OnDeactivated()
        {
            exportController.CustomExport -= new EventHandler<CustomExportEventArgs>(CustomExport);
            base.OnDeactivated();
        }
    }
}
