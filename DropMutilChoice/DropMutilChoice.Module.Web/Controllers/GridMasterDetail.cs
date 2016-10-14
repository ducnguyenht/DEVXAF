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
using DevExpress.ExpressApp.Web.Editors.ASPx;
using System.Web.UI;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxMenu.Internal;
using DevExpress.Web.ASPxTabControl;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Web;

namespace DropMutilChoice.Module.Web.Controllers
{
    public class GridMasterDetailViewController : ViewController<ListView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (Frame != null && Frame.Template is ISupportActionsToolbarVisibility)
            {
                ((ISupportActionsToolbarVisibility)(Frame.Template)).SetVisible(false);// = false;
            }
            if (View.Model.MasterDetailMode == MasterDetailMode.ListViewAndDetailView)
            {
                ASPxGridListEditor listEditor = View.Editor as ASPxGridListEditor;
                if (listEditor != null)
                {
                    listEditor.Grid.SettingsDetail.ShowDetailRow = true;
                    listEditor.Grid.Templates.DetailRow = new ASPxGridViewDetailRowTemplate(View);
                }
              
            }
        }
      
        class ASPxGridViewDetailRowTemplate : ITemplate
        {
            private ListView masterListViewCore;
            public ASPxGridViewDetailRowTemplate(ListView masterListView)
            {
                masterListViewCore = masterListView;
            }
            public void InstantiateIn(Control container)
            {
                GridViewDetailRowTemplateContainer templateContainer = (GridViewDetailRowTemplateContainer)container;
                ASPxPageControl pageControl = DevExpress.ExpressApp.Web.RenderHelper.CreateASPxPageControl();
                object masterObject = masterListViewCore.ObjectSpace.GetObject(templateContainer.Grid.GetRow(templateContainer.VisibleIndex));
                pageControl.EnableCallBacks = true;
                pageControl.Width = Unit.Percentage(100);
                pageControl.ContentStyle.Paddings.Padding = Unit.Pixel(0);
                container.Controls.Add(pageControl);
                foreach (IMemberInfo mi in masterListViewCore.ObjectTypeInfo.Members)
                {
                    if (mi.IsList && mi.IsPublic)
                    {
                        IObjectSpace os = WebApplication.Instance.CreateObjectSpace();
                        string listViewId = DevExpress.ExpressApp.Model.NodeGenerators.ModelNestedListViewNodesGeneratorHelper.GetNestedListViewId(mi);
                        CollectionSourceBase cs = new PropertyCollectionSource(os, mi.ListElementType, os.GetObject(masterObject), mi, CollectionSourceMode.Proxy);
                        ListView detailsListView = WebApplication.Instance.CreateListView(listViewId, cs, false);

                        Frame detailsFrame = WebApplication.Instance.CreateFrame(TemplateContext.NestedFrame);
                        //if (detailsFrame.Template!=null)
                        //{
                        //    ((ISupportActionsToolbarVisibility)(detailsFrame.Template)).SetVisible(false);// = false;
                        //}
                     
                        detailsFrame.SetView(detailsListView);
                        detailsFrame.CreateTemplate();

                        Control detailsTemplateControl = (Control)detailsFrame.Template;
                        detailsTemplateControl.ID = string.Format("detailsTemplateControl_{0}", mi.Name);
                        TabPage page = new TabPage(mi.DisplayName);
                        page.Controls.Add(detailsTemplateControl);
                        pageControl.TabPages.Add(page);
                    }
                }
            }
          
        }
    }
}
