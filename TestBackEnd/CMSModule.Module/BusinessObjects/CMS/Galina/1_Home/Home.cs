using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.IO;
using System.Web;
using System.Drawing;

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    [DevExpress.ExpressApp.ConditionalAppearance.Appearance(
        "NewHidden",
        DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.Action,
        "true",
        TargetItems = "New",
        Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide,
        Context = "DetailView")]
    [DevExpress.ExpressApp.ConditionalAppearance.Appearance(
        "DeleteHidden",
        DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.Action,
        "true",
        TargetItems = "Delete",
        Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide,
        Context = "DetailView")]

    public class Home : BaseObject
    {
        public Home(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        // Fields...

        private string _ContentVNP02;
        private string _ContentRUP02;
        private string _ContentP02;
        private FileData _FileDataP09;
        private string _ImageURLP09;
        private string _ContentRUP09;
        private string _ContentVNP09;
        private string _ContentP09;
        private string _VideoURLP09;
        private string _DescriptionRUP09;
        private string _DescriptionVNP09;
        private string _DescriptionP09;
        private string _TitleRUP09;
        private string _TitleVNP09;
        private string _TitleP09;

        private FileData _FileDataP08;
        private string _ImageURLP08;
        private string _ContentRUP08;
        private string _ContentVNP08;
        private string _ContentP08;
        private string _DescriptionRUP08;
        private string _DescriptionVNP08;
        private string _DescriptionP08;
        private string _TitleRUP08;
        private string _TitleVNP08;
        private string _TitleP08;

        private FileData _FileDataP07;
        private string _ImageURLP07;
        private string _ContentRUP07;
        private string _ContentVNP07;
        private string _ContentP07;
        private string _DescriptionRUP07;
        private string _DescriptionVNP07;
        private string _DescriptionP07;
        private string _TitleRUP07;
        private string _TitleVNP07;
        private string _TitleP07;

        private FileData _FileDataP06;
        private string _ImageURLP06;
        private string _ContentRUP06;
        private string _ContentVNP06;
        private string _ContentP06;
        private string _DescriptionRUP06;
        private string _DescriptionVNP06;
        private string _DescriptionP06;
        private string _TitleRUP06;
        private string _TitleVNP06;
        private string _TitleP06;

        private string _DescriptionRUP05;
        private string _DescriptionVNP05;
        private string _DescriptionP05;
        private string _TitleRUP05;
        private string _TitleVNP05;
        private string _TitleP05;

        private string _ImageURLP03;
        private FileData _FileDataP03;
        private string _ContentRUP03;
        private string _ContentVNP03;
        private string _ContentP03;
        private string _DescriptionRUP03;
        private string _DescriptionVNP03;
        private string _DescriptionP03;
        private string _TitleRUP03;
        private string _TitleVNP03;
        private string _TitleP03;

        private string _DescriptionRUP02;
        private string _DescriptionVNP02;
        private string _DescriptionP02;
        private string _TitleRUP02;
        private string _TitleVNP02;
        private string _TitleP02;

        #region get-set
        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP02
        {
            get
            {
                return _TitleP02;
            }
            set
            {
                SetPropertyValue("TitleP02", ref _TitleP02, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP02
        {
            get
            {
                return _TitleVNP02;
            }
            set
            {
                SetPropertyValue("TitleVNP02", ref _TitleVNP02, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP02
        {
            get
            {
                return _TitleRUP02;
            }
            set
            {
                SetPropertyValue("TitleRUP02", ref _TitleRUP02, value);
            }
        }


        public string DescriptionP02
        {
            get
            {
                return _DescriptionP02;
            }
            set
            {
                SetPropertyValue("DescriptionP02", ref _DescriptionP02, value);
            }
        }

        public string DescriptionVNP02
        {
            get
            {
                return _DescriptionVNP02;
            }
            set
            {
                SetPropertyValue("DescriptionVNP02", ref _DescriptionVNP02, value);
            }
        }

        public string DescriptionRUP02
        {
            get
            {
                return _DescriptionRUP02;
            }
            set
            {
                SetPropertyValue("DescriptionRUP02", ref _DescriptionRUP02, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP02
        {
            get
            {
                return _ContentP02;
            }
            set
            {
                SetPropertyValue("ContentP02", ref _ContentP02, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP02
        {
            get
            {
                return _ContentVNP02;
            }
            set
            {
                SetPropertyValue("ContentVNP02", ref _ContentVNP02, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP02
        {
            get
            {
                return _ContentRUP02;
            }
            set
            {
                SetPropertyValue("ContentRUP02", ref _ContentRUP02, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP03
        {
            get
            {
                return _TitleP03;
            }
            set
            {
                SetPropertyValue("TitleP03", ref _TitleP03, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP03
        {
            get
            {
                return _TitleVNP03;
            }
            set
            {
                SetPropertyValue("TitleVNP03", ref _TitleVNP03, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP03
        {
            get
            {
                return _TitleRUP03;
            }
            set
            {
                SetPropertyValue("TitleRUP03", ref _TitleRUP03, value);
            }
        }


        public string DescriptionP03
        {
            get
            {
                return _DescriptionP03;
            }
            set
            {
                SetPropertyValue("DescriptionP03", ref _DescriptionP03, value);
            }
        }

        public string DescriptionVNP03
        {
            get
            {
                return _DescriptionVNP03;
            }
            set
            {
                SetPropertyValue("DescriptionVNP03", ref _DescriptionVNP03, value);
            }
        }

        public string DescriptionRUP03
        {
            get
            {
                return _DescriptionRUP03;
            }
            set
            {
                SetPropertyValue("DescriptionRUP03", ref _DescriptionRUP03, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP03
        {
            get
            {
                return _ContentP03;
            }
            set
            {
                SetPropertyValue("ContentP03", ref _ContentP03, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP03
        {
            get
            {
                return _ContentVNP03;
            }
            set
            {
                SetPropertyValue("ContentVNP03", ref _ContentVNP03, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP03
        {
            get
            {
                return _ContentRUP03;
            }
            set
            {
                SetPropertyValue("ContentRUP03", ref _ContentRUP03, value);
            }
        }



        [NonPersistent, XafDisplayName("Choose Image P03"), VisibleInListView(false)]
        public FileData FileDataP03
        {
            get
            {
                return _FileDataP03;
            }
            set
            {
                SetPropertyValue("FileDataP03", ref _FileDataP03, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP03
        {
            get
            {
                return _ImageURLP03;
            }
            set
            {
                SetPropertyValue("ImageURLP03", ref _ImageURLP03, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP05
        {
            get
            {
                return _TitleP05;
            }
            set
            {
                SetPropertyValue("TitleP05", ref _TitleP05, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP05
        {
            get
            {
                return _TitleVNP05;
            }
            set
            {
                SetPropertyValue("TitleVNP05", ref _TitleVNP05, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP05
        {
            get
            {
                return _TitleRUP05;
            }
            set
            {
                SetPropertyValue("TitleRUP05", ref _TitleRUP05, value);
            }
        }

        public string DescriptionP05
        {
            get
            {
                return _DescriptionP05;
            }
            set
            {
                SetPropertyValue("DescriptionP05", ref _DescriptionP05, value);
            }
        }

        public string DescriptionVNP05
        {
            get
            {
                return _DescriptionVNP05;
            }
            set
            {
                SetPropertyValue("DescriptionVNP05", ref _DescriptionVNP05, value);
            }
        }

        public string DescriptionRUP05
        {
            get
            {
                return _DescriptionRUP05;
            }
            set
            {
                SetPropertyValue("DescriptionRUP05", ref _DescriptionRUP05, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP06
        {
            get
            {
                return _TitleP06;
            }
            set
            {
                SetPropertyValue("TitleP06", ref _TitleP06, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP06
        {
            get
            {
                return _TitleVNP06;
            }
            set
            {
                SetPropertyValue("TitleVNP06", ref _TitleVNP06, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP06
        {
            get
            {
                return _TitleRUP06;
            }
            set
            {
                SetPropertyValue("TitleRUP06", ref _TitleRUP06, value);
            }
        }

        public string DescriptionP06
        {
            get
            {
                return _DescriptionP06;
            }
            set
            {
                SetPropertyValue("DescriptionP06", ref _DescriptionP06, value);
            }
        }

        public string DescriptionVNP06
        {
            get
            {
                return _DescriptionVNP06;
            }
            set
            {
                SetPropertyValue("DescriptionVNP06", ref _DescriptionVNP06, value);
            }
        }

        public string DescriptionRUP06
        {
            get
            {
                return _DescriptionRUP06;
            }
            set
            {
                SetPropertyValue("DescriptionRUP06", ref _DescriptionRUP06, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP06
        {
            get
            {
                return _ContentP06;
            }
            set
            {
                SetPropertyValue("ContentP06", ref _ContentP06, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP06
        {
            get
            {
                return _ContentVNP06;
            }
            set
            {
                SetPropertyValue("ContentVNP06", ref _ContentVNP06, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP06
        {
            get
            {
                return _ContentRUP06;
            }
            set
            {
                SetPropertyValue("ContentRUP06", ref _ContentRUP06, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP06
        {
            get
            {
                return _ImageURLP06;
            }
            set
            {
                SetPropertyValue("ImageURLP06", ref _ImageURLP06, value);
            }
        }

        [NonPersistent, XafDisplayName("Choose Image P06"), VisibleInListView(false)]
        public FileData FileDataP06
        {
            get
            {
                return _FileDataP06;
            }
            set
            {
                SetPropertyValue("FileDataP06", ref _FileDataP06, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP07
        {
            get
            {
                return _TitleP07;
            }
            set
            {
                SetPropertyValue("TitleP07", ref _TitleP07, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP07
        {
            get
            {
                return _TitleVNP07;
            }
            set
            {
                SetPropertyValue("TitleVNP07", ref _TitleVNP07, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP07
        {
            get
            {
                return _TitleRUP07;
            }
            set
            {
                SetPropertyValue("TitleRUP07", ref _TitleRUP07, value);
            }
        }

        public string DescriptionP07
        {
            get
            {
                return _DescriptionP07;
            }
            set
            {
                SetPropertyValue("DescriptionP07", ref _DescriptionP07, value);
            }
        }

        public string DescriptionVNP07
        {
            get
            {
                return _DescriptionVNP07;
            }
            set
            {
                SetPropertyValue("DescriptionVNP07", ref _DescriptionVNP07, value);
            }
        }

        public string DescriptionRUP07
        {
            get
            {
                return _DescriptionRUP07;
            }
            set
            {
                SetPropertyValue("DescriptionRUP07", ref _DescriptionRUP07, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP07
        {
            get
            {
                return _ContentP07;
            }
            set
            {
                SetPropertyValue("ContentP07", ref _ContentP07, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP07
        {
            get
            {
                return _ContentVNP07;
            }
            set
            {
                SetPropertyValue("ContentVNP07", ref _ContentVNP07, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP07
        {
            get
            {
                return _ContentRUP07;
            }
            set
            {
                SetPropertyValue("ContentRUP07", ref _ContentRUP07, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP07
        {
            get
            {
                return _ImageURLP07;
            }
            set
            {
                SetPropertyValue("ImageURLP07", ref _ImageURLP07, value);
            }
        }

        [NonPersistent, XafDisplayName("Choose Image P07"), VisibleInListView(false)]
        public FileData FileDataP07
        {
            get
            {
                return _FileDataP07;
            }
            set
            {
                SetPropertyValue("FileDataP07", ref _FileDataP07, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP08
        {
            get
            {
                return _TitleP08;
            }
            set
            {
                SetPropertyValue("TitleP08", ref _TitleP08, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP08
        {
            get
            {
                return _TitleVNP08;
            }
            set
            {
                SetPropertyValue("TitleVNP08", ref _TitleVNP08, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP08
        {
            get
            {
                return _TitleRUP08;
            }
            set
            {
                SetPropertyValue("TitleRUP08", ref _TitleRUP08, value);
            }
        }

        public string DescriptionP08
        {
            get
            {
                return _DescriptionP08;
            }
            set
            {
                SetPropertyValue("DescriptionP08", ref _DescriptionP08, value);
            }
        }

        public string DescriptionVNP08
        {
            get
            {
                return _DescriptionVNP08;
            }
            set
            {
                SetPropertyValue("DescriptionVNP08", ref _DescriptionVNP08, value);
            }
        }

        public string DescriptionRUP08
        {
            get
            {
                return _DescriptionRUP08;
            }
            set
            {
                SetPropertyValue("DescriptionRUP08", ref _DescriptionRUP08, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP08
        {
            get
            {
                return _ContentP08;
            }
            set
            {
                SetPropertyValue("ContentP08", ref _ContentP08, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP08
        {
            get
            {
                return _ContentVNP08;
            }
            set
            {
                SetPropertyValue("ContentVNP08", ref _ContentVNP08, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP08
        {
            get
            {
                return _ContentRUP08;
            }
            set
            {
                SetPropertyValue("ContentRUP08", ref _ContentRUP08, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP08
        {
            get
            {
                return _ImageURLP08;
            }
            set
            {
                SetPropertyValue("ImageURLP08", ref _ImageURLP08, value);
            }
        }

        [NonPersistent, XafDisplayName("Choose Image P08"), VisibleInListView(false)]
        public FileData FileDataP08
        {
            get
            {
                return _FileDataP08;
            }
            set
            {
                SetPropertyValue("FileDataP08", ref _FileDataP08, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP09
        {
            get
            {
                return _TitleP09;
            }
            set
            {
                SetPropertyValue("TitleP09", ref _TitleP09, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP09
        {
            get
            {
                return _TitleVNP09;
            }
            set
            {
                SetPropertyValue("TitleVNP09", ref _TitleVNP09, value);
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP09
        {
            get
            {
                return _TitleRUP09;
            }
            set
            {
                SetPropertyValue("TitleRUP09", ref _TitleRUP09, value);
            }
        }

        public string DescriptionP09
        {
            get
            {
                return _DescriptionP09;
            }
            set
            {
                SetPropertyValue("DescriptionP09", ref _DescriptionP09, value);
            }
        }

        public string DescriptionVNP09
        {
            get
            {
                return _DescriptionVNP09;
            }
            set
            {
                SetPropertyValue("DescriptionVNP09", ref _DescriptionVNP09, value);
            }
        }

        public string DescriptionRUP09
        {
            get
            {
                return _DescriptionRUP09;
            }
            set
            {
                SetPropertyValue("DescriptionRUP09", ref _DescriptionRUP09, value);
            }
        }

        public string VideoURLP09
        {
            get
            {
                return _VideoURLP09;
            }
            set
            {
                SetPropertyValue("VideoURLP09", ref _VideoURLP09, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP09
        {
            get
            {
                return _ContentP09;
            }
            set
            {
                SetPropertyValue("ContentP09", ref _ContentP09, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP09
        {
            get
            {
                return _ContentVNP09;
            }
            set
            {
                SetPropertyValue("ContentVNP09", ref _ContentVNP09, value);
            }
        }

        [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP09
        {
            get
            {
                return _ContentRUP09;
            }
            set
            {
                SetPropertyValue("ContentRUP09", ref _ContentRUP09, value);
            }
        }

        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP09
        {
            get
            {
                return _ImageURLP09;
            }
            set
            {
                SetPropertyValue("ImageURLP09", ref _ImageURLP09, value);
            }
        }

        [NonPersistent, XafDisplayName("Choose Image P09"), VisibleInListView(false)]
        public FileData FileDataP09
        {
            get
            {
                return _FileDataP09;
            }
            set
            {
                SetPropertyValue("FileDataP09", ref _FileDataP09, value);
            }
        }
        #endregion

        #region Association
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<ListImagesHome> ListSlider
        {
            get
            {
                return GetCollection<ListImagesHome>("ListSlider");
            }
        }

        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<ListImagesHome01> ListImageRoooms
        {
            get
            {
                return GetCollection<ListImagesHome01>("ListImageRoooms");
            }
        }

        #endregion

        #region Logic
        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP03
        {
            get
            {
                if (ImageURLP03 != null && ImageURLP03 != "")
                {
                    return ImageURLP03.Substring(0, ImageURLP03.LastIndexOf('.')) + "_thumb" + ImageURLP03.Substring(ImageURLP03.LastIndexOf('.'));
                }
                return "";
            }
        }

        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP06
        {
            get
            {
                if (ImageURLP06 != null && ImageURLP06 != "")
                {
                    return ImageURLP06.Substring(0, ImageURLP06.LastIndexOf('.')) + "_thumb" + ImageURLP06.Substring(ImageURLP06.LastIndexOf('.'));
                }
                return "";
            }
        }

        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP07
        {
            get
            {
                if (ImageURLP07 != null && ImageURLP07 != "")
                {
                    return ImageURLP07.Substring(0, ImageURLP07.LastIndexOf('.')) + "_thumb" + ImageURLP07.Substring(ImageURLP07.LastIndexOf('.'));
                }
                return "";
            }
        }


        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP08
        {
            get
            {
                if (ImageURLP08 != null && ImageURLP08 != "")
                {
                    return ImageURLP08.Substring(0, ImageURLP08.LastIndexOf('.')) + "_thumb" + ImageURLP08.Substring(ImageURLP08.LastIndexOf('.'));
                }
                return "";
            }
        }

        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP09
        {
            get
            {
                if (ImageURLP09 != null && ImageURLP09 != "")
                {
                    return ImageURLP09.Substring(0, ImageURLP09.LastIndexOf('.')) + "_thumb" + ImageURLP09.Substring(ImageURLP09.LastIndexOf('.'));
                }
                return "";
            }
        }

        #endregion

        #region event

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "ImageURLP03":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
                case "ImageURLP06":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
                case "ImageURLP07":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
                case "ImageURLP09":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            ImageURLP03 = ValidateSystem.SaveFileToServer(FileDataP03, "About");
            ImageURLP06 = ValidateSystem.SaveFileToServer(FileDataP06, "About");
            ImageURLP07 = ValidateSystem.SaveFileToServer(FileDataP07, "About");
            ImageURLP08 = ValidateSystem.SaveFileToServer(FileDataP08, "About");
            ImageURLP09 = ValidateSystem.SaveFileToServer(FileDataP09, "About");
        }
        protected override void OnDeleting()
        {
            base.OnDeleting();

        }
        #endregion
    }
}
