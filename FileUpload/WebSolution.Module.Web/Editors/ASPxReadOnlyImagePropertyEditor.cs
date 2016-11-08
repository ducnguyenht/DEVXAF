﻿using DevExpress.ExpressApp.Web.Editors.ASPx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.ExpressApp.SystemModule;
using System.Diagnostics;
using DevExpress.ExpressApp.Web;
using DevExpress.Web.ASPxObjectContainer;

namespace WebSolution.Module.Web.Editors
{
    [PropertyEditor(typeof(string), "ASPxReadOnlyImagePropertyEditor", false)]
    public class ASPxReadOnlyImagePropertyEditor : WebPropertyEditor
    {
        public ASPxReadOnlyImagePropertyEditor(Type objectType, DevExpress.ExpressApp.Model.IModelMemberViewItem mode) : base(objectType, mode) { }
        public string ResourceUrl
        {
            get
            {
                return (string)PropertyValue;
            }
        }
        protected override WebControl CreateViewModeControlCore()
        {
            ASPxObjectContainer container = CreateContainer();
            container.Enabled = false;
            return container;
        }
        protected override WebControl CreateEditModeControlCore()
        {
            ASPxObjectContainer container = CreateContainer();
            return container;
        }
        private ASPxObjectContainer CreateContainer()
        {
            ASPxObjectContainer container = new ASPxObjectContainer();
            ASPxReadOnlyImageSizeAttribute attr = this.MemberInfo.FindAttribute<ASPxReadOnlyImageSizeAttribute>();
            if ((string)PropertyValue != "")
            {
                if (this.CurrentObject != null)
                {
                    try
                    {
                        int targetWidth = (int)this.ObjectTypeInfo.FindMember(attr.WidthProperty).GetValue(this.CurrentObject);
                        int targetHeight = (int)this.ObjectTypeInfo.FindMember(attr.HeightProperty).GetValue(this.CurrentObject);
                        int newWidth = attr.Width;
                        int newHeight = attr.Height;
                        if (targetWidth != 0 && targetHeight != 0)
                        {
                            var ratioX = (double)(attr.Width) / (double)(targetWidth);
                            var ratioY = (double)(attr.Height) / (double)(targetHeight);
                            var ratio = Math.Min(ratioX, ratioY);

                            newWidth = (int)(Convert.ToUInt32(targetWidth) * ratio);
                            newHeight = (int)(Convert.ToUInt32(targetHeight) * ratio);
                        }
                        container.Width = newWidth;
                        container.Height = newHeight;
                    }
                    catch (Exception)
                    {

                    }

                }
            }
            else
            {
                container.Width = 100;
                container.Height = 100;
            }
            return container;
        }
        protected override object GetControlValueCore()
        {
            return ((ASPxObjectContainer)Editor).ObjectUrl;
        }
        protected override void ReadEditModeValueCore()
        {
            ((ASPxObjectContainer)Editor).ObjectUrl = ResourceUrl;
        }
        protected override void ReadViewModeValueCore()
        {
            ((ASPxObjectContainer)InplaceViewModeEditor).ObjectUrl = ResourceUrl;
        }
    }
}