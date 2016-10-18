using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Scheduler.Web;
using DevExpress.ExpressApp.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.ExpressApp.Web.Templates;
using DrPepper.Module.BusinessObjects;
using System.Web.UI;

namespace MainDemo.Module.Web {
    public class MySchedulerControllerWeb:ViewController<ListView> {
        public MySchedulerControllerWeb() {
            this.TargetViewId = "WorkOrder_ListView";
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            ASPxSchedulerListEditor editor = View.Editor as ASPxSchedulerListEditor;
            if(editor != null) {
                ASPxScheduler scheduler = ((ASPxSchedulerListEditor)editor).SchedulerControl;
                if(scheduler != null) {
                    scheduler.Load += scheduler_Load;
                }
            }
        }
        void scheduler_Load(object sender,EventArgs e) {
            ASPxScheduler scheduler = sender as ASPxScheduler;
            scheduler.Templates.HorizontalResourceHeaderTemplate = new MyHorizontalResourceHeaderTemplate();
        }
        protected override void OnDeactivated() {
            ASPxSchedulerListEditor editor = View.Editor as ASPxSchedulerListEditor;
            if(editor != null) {
                ASPxScheduler scheduler = ((ASPxSchedulerListEditor)editor).SchedulerControl;
                if(scheduler != null)
                    scheduler.Load -= scheduler_Load;
                base.OnDeactivated();
            }
        }
    }
}
