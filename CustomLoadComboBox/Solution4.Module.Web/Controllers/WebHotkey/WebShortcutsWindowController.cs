using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web;

namespace Solution4.Module.Web.Controllers.WebHotkey
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WebShortcutsWindowController : WindowController, IXafCallbackHandler
    {
        public WebShortcutsWindowController()
        {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            Frame.ViewChanged += Frame_ViewChanged;
            ((WebWindow)Window).PagePreRender += CurrentRequestWindow_PagePreRender;
        }
        protected override void OnDeactivated()
        {
            ((WebWindow)Window).PagePreRender -= CurrentRequestWindow_PagePreRender;
            Frame.ViewChanged -= Frame_ViewChanged;
            base.OnDeactivated();
        }
        void Frame_ViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (Frame.View != null)
            {
                Frame.View.ControlsCreated += View_ControlsCreated;
            }
        }
        void View_ControlsCreated(object sender, EventArgs e)
        {
            RegisterXafCallackHandler();
        }
        private void RegisterXafCallackHandler()
        {
            if (XafCallbackManager != null)
            {
                XafCallbackManager.RegisterHandler("T171941", this);
                XafCallbackManager.RegisterHandler("T171942", this);
            }
        }
        protected XafCallbackManager XafCallbackManager
        {
            get
            {
                return WebWindow.CurrentRequestPage != null ? ((ICallbackManagerHolder)WebWindow.CurrentRequestPage).CallbackManager : null;
            }
        }
        void CurrentRequestWindow_PagePreRender(object sender, EventArgs e)
        {
            WebWindow window = (WebWindow)sender;
            string script = IsSuitableView() ? @"
window.onkeydown = function(e) { 
    var key = e.keyCode ? e.keyCode : e.which;
    if (key == 13 && e.ctrlKey) { //Control+Enter=13 83=s
         RaiseXafCallback(globalCallbackControl, 'T171941', 'SaveAction', '', false);
         e.preventDefault(); 
    }  
    if (key == 13 && e.altKey) { //Control+Enter=13 83=s
         RaiseXafCallback(globalCallbackControl, 'T171942', 'SaveAndNewAction', '', false);
         e.preventDefault(); 
    }                                       
};" : "window.onkeydown=undefined;";
            window.RegisterStartupScript(GetType().FullName, script);
        }
        public void ProcessAction(string parameter)
        {
            if (IsSuitableView() && (Frame != null))
            {
                switch (parameter)
                {
                    case "SaveAction":
                        SimpleAction saveAction = Frame.GetController<ModificationsController>().SaveAction;
                        if (saveAction.Enabled && saveAction.Active)
                        {
                            saveAction.DoExecute();
                        }
                        break;
                    case "SaveAndNewAction":
                        //var a2 = Frame.GetController<ModificationsController>().SaveAndNewAction;
                        var a2 = Frame.GetController<ModificationsController>().SaveAndNewAction;
                        if (a2.Enabled && a2.Active)
                        {
                            a2.DoExecute(a2.Items.FirstActiveItem);
                        }
                        break;
                }
            }
        }
        protected virtual bool IsSuitableView()
        {
            return Frame.View != null && Frame.View.IsRoot && !(Frame.View is ListView) && !(Frame is NestedFrame) && !(Frame is PopupWindow);
        }
    }

}
//function KeyPress(e) {
//      var key = window.event? event : e;
//      if (key.keyCode == 83 && key.ctrlKey) {
//        RaiseXafCallback(globalCallbackControl, 'T171942', 'SaveAndNewAction', '', false);
//         e.preventDefault(); 
//        //alert('Ctrl+z');
//      }
//}
//window.onkeydown = function(e) { 
//    //var key = e.keyCode ? e.keyCode : e.which;
//    var key = window.event? event : e;
//    if (key.ctrlKey && key.keyCode == 13 ) { //Control+Enter=13 83=s
//         RaiseXafCallback(globalCallbackControl, 'T171942', 'SaveAndNewAction', '', false);
//         e.preventDefault(); 
//    } 
//    if (key == 13 && e.altKey) { //Control+Enter=13 83=s
//         RaiseXafCallback(globalCallbackControl, 'T171941', 'SaveAction', '', false);
//         e.preventDefault(); 
//    }                                       
//    if (e.ctrlKey && key == 83 ) { //Control+Enter=13 83=s
//         RaiseXafCallback(globalCallbackControl, 'T171942', 'SaveAndNewAction', '', false);
//         e.preventDefault(); 
//    }  
//    if (key == 13 && e.altKey) { //Control+Enter=13 83=s
//         RaiseXafCallback(globalCallbackControl, 'T171941', 'SaveAction', '', false);
//         e.preventDefault(); 
//    }                                       
//};" : "window.onkeydown=undefined;";