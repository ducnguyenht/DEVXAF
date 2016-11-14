using System;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.Editors;

namespace CMSModule.Module.Editors
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
            container.Width = 100;
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
//ASPxReadOnlyImageSizeAttribute attr = this.MemberInfo.FindAttribute<ASPxReadOnlyImageSizeAttribute>();
//if ((string)PropertyValue != "")
//{
//    if (this.CurrentObject != null)
//    {
//        try
//        {
//            var filePath = this.CurrentObject.GetType().GetProperty("ImageUrl").GetValue(this.CurrentObject, null).ToString();
//            string serverFilePath = HttpContext.Current.Request.MapPath(filePath);
//            //string filePath = HttpContext.Current.Request.MapPath("~/FileData/" + FileData.FileName);
//            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//            var image = System.Drawing.Image.FromStream(stream);
//            stream.Close();
//            //var image = System.Drawing.Image.FromFile(serverFilePath, true);
//            int targetWidth = image.Width; //(int)this.ObjectTypeInfo.FindMember(attr.WidthProperty).GetValue(this.CurrentObject);
//            int targetHeight = image.Height;//(int)this.ObjectTypeInfo.FindMember(attr.HeightProperty).GetValue(this.CurrentObject);
//            int newWidth = attr.Width;
//            int newHeight = attr.Height;
//            if (targetWidth != 0 && targetHeight != 0)
//            {
//                var ratioX = (double)(attr.Width) / (double)(targetWidth);
//                var ratioY = (double)(attr.Height) / (double)(targetHeight);
//                var ratio = Math.Min(ratioX, ratioY);

//                newWidth = (int)(Convert.ToUInt32(targetWidth) * ratio);
//                newHeight = (int)(Convert.ToUInt32(targetHeight) * ratio);
//            }
//            container.Width = newWidth;
//            container.Height = newHeight;
//        }
//        catch (Exception)
//        {

//        }

//    }
//}
//else
//{
//    container.Width = 100;
//    container.Height = 100;
//}