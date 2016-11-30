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

namespace CMSModule.Module.BusinessObjects.CMS.Galina
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [DevExpress.ExpressApp.ConditionalAppearance.Appearance("NewHidden", DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.Action, "true", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "DetailView")]
    [DevExpress.ExpressApp.ConditionalAppearance.Appearance("DeleteHidden", DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.Action, "true", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "DetailView")]
//    [RuleObjectExists("AnotherSingletonExists", DefaultContexts.Save, "True", InvertResult = true,
//CustomMessageTemplate = "Another Singleton already exists.")]
//    [RuleCriteria("CannotDeleteSingleton", DefaultContexts.Delete, "False",
//        CustomMessageTemplate = "Cannot delete Singleton.")]
    public class About : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public About(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }



        private string _Code;

        #region post 01
        private string _TitleP01;
        private string _TitleRUP01;
        private string _TitleVNP01;

        private string _DescriptionP01;
        private string _DescriptionRUP01;
        private string _DescriptionVNP01;

        private string _ImageURLP01;
        private FileData _FileDataP01;
        #endregion

        #region post 02
        private string _TitleRUP02;
        private string _TitleVNP02;
        private string _TitleP02;

        private string _DescriptionRUP02;
        private string _DescriptionVNP02;
        private string _DescriptionP02;

        private string _ContentP02;
        private string _ContentVNP02;
        private string _ContentRUP02;

        private FileData _FileDataP02;
        private string _ImageURLP02;
        #endregion

        #region post 03
        private string _TitleRUP03;
        private string _TitleVNP03;
        private string _TitleP03;

        private string _DescriptionRUP03;
        private string _DescriptionVNP03;
        private string _DescriptionP03;

        private string _ContentRUP03;
        private string _ContentVNP03;
        private string _ContentP03;

        private FileData _FileDataP03;
        private string _ImageURLP03;

        private string _VideoURLRUP03;
        private string _VideoURLVNP03;
        private string _VideoURLP03;
        #endregion

        #region post 04
        private string _TitleRUP04;
        private string _TitleVNP04;
        private string _TitleP04;

        private string _DescriptionRUP04;
        private string _DescriptionVNP04;
        private string _DescriptionP04;

        private string _ContentRUP04;
        private string _ContentVNP04;
        private string _ContentP04;

        #endregion

        #region get-set
        [Browsable(false)]
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                SetPropertyValue("Code", ref _Code, value);
            }
        }


         [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentP04
        {
            get
            {
                return _ContentP04;
            }
            set
            {
                SetPropertyValue("ContentP04", ref _ContentP04, value);
            }
        }

         [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentVNP04
        {
            get
            {
                return _ContentVNP04;
            }
            set
            {
                SetPropertyValue("ContentVNP04", ref _ContentVNP04, value);
            }
        }

         [Size(SizeAttribute.Unlimited), ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.HtmlPropertyEditor.Web.ASPxHtmlPropertyEditor")]
        public string ContentRUP04
        {
            get
            {
                return _ContentRUP04;
            }
            set
            {
                SetPropertyValue("ContentRUP04", ref _ContentRUP04, value);
            }
        }
        public string DescriptionP04
        {
            get
            {
                return _DescriptionP04;
            }
            set
            {
                SetPropertyValue("DescriptionP04", ref _DescriptionP04, value);
            }
        }

        public string DescriptionVNP04
        {
            get
            {
                return _DescriptionVNP04;
            }
            set
            {
                SetPropertyValue("DescriptionVNP04", ref _DescriptionVNP04, value);
            }
        }

        public string DescriptionRUP04
        {
            get
            {
                return _DescriptionRUP04;
            }
            set
            {
                SetPropertyValue("DescriptionRUP04", ref _DescriptionRUP04, value);
            }
        }


        public string TitleP04
        {
            get
            {
                return _TitleP04;
            }
            set
            {
                SetPropertyValue("TitleP04", ref _TitleP04, value);
            }
        }

        public string TitleVNP04
        {
            get
            {
                return _TitleVNP04;
            }
            set
            {
                SetPropertyValue("TitleVNP04", ref _TitleVNP04, value);
            }
        }

        public string TitleRUP04
        {
            get
            {
                return _TitleRUP04;
            }
            set
            {
                SetPropertyValue("TitleRUP04", ref _TitleRUP04, value);
            }
        }

        public string VideoURLP03
        {
            get
            {
                return _VideoURLP03;
            }
            set
            {
                SetPropertyValue("VideoURLP03", ref _VideoURLP03, value);
            }
        }


        public string VideoURLVNP03
        {
            get
            {
                return _VideoURLVNP03;
            }
            set
            {
                SetPropertyValue("VideoURLVNP03", ref _VideoURLVNP03, value);
            }
        }

        public string VideoURLRUP03
        {
            get
            {
                return _VideoURLRUP03;
            }
            set
            {
                SetPropertyValue("VideoURLRUP03", ref _VideoURLRUP03, value);
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

        [NonPersistent, XafDisplayName("Choose Image P03"), VisibleInListView(false)]//, 
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


        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP02
        {
            get
            {
                return _ImageURLP02;
            }
            set
            {
                SetPropertyValue("ImageURLP02", ref _ImageURLP02, value);
            }
        }

        [NonPersistent, XafDisplayName("Choose Image P02"), VisibleInListView(false)]//, 
        public FileData FileDataP02
        {
            get
            {
                return _FileDataP02;
            }
            set
            {
                SetPropertyValue("FileDataP02", ref _FileDataP02, value);
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

        public string DescriptionP01
        {
            get
            {
                return _DescriptionP01;
            }
            set
            {
                SetPropertyValue("DescriptionP01", ref _DescriptionP01, value);
            }
        }


        public string DescriptionVNP01
        {
            get
            {
                return _DescriptionVNP01;
            }
            set
            {
                SetPropertyValue("DescriptionVNP01", ref _DescriptionVNP01, value);
            }
        }


        public string DescriptionRUP01
        {
            get
            {
                return _DescriptionRUP01;
            }
            set
            {
                SetPropertyValue("DescriptionRUP01", ref _DescriptionRUP01, value);
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleP01
        {
            get
            {
                return _TitleP01;
            }
            set
            {
                SetPropertyValue("TitleP01", ref _TitleP01, value);
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

        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleVNP01
        {
            get
            {
                return _TitleVNP01;
            }
            set
            {
                SetPropertyValue("TitleVNP01", ref _TitleVNP01, value);
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


        [Size(SizeAttribute.DefaultStringMappingFieldSize), ImmediatePostData]
        public string TitleRUP01
        {
            get
            {
                return _TitleRUP01;
            }
            set
            {
                SetPropertyValue("TitleRUP01", ref _TitleRUP01, value);
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


        [Size(1028), ModelDefault("RowCount", "1"), VisibleInListView(true)]//, Browsable(false)]
        public string ImageURLP01
        {
            get
            {
                return _ImageURLP01;
            }
            set
            {
                SetPropertyValue("ImageURLP01", ref _ImageURLP01, value);
            }
        }





        [NonPersistent, XafDisplayName("Choose Image P01"), VisibleInListView(false)]
        public FileData FileDataP01
        {
            get
            {
                return _FileDataP01;
            }
            set
            {
                SetPropertyValue("FileDataP01", ref _FileDataP01, value);
            }
        }

        #endregion Russian

        #region logic
        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP01
        {
            get
            {
                if (ImageURLP01 != null && ImageURLP01 != "")
                {
                    return ImageURLP01.Substring(0, ImageURLP01.LastIndexOf('.')) + "_thumb" + ImageURLP01.Substring(ImageURLP01.LastIndexOf('.'));
                }
                return "";
            }
        }

        [EditorAlias("ASPxReadOnlyImagePropertyEditor")]
        [VisibleInLookupListView(false)]//VisibleInListView(false),
        //[XafDisplayName("Image")]
        public string PresentationThumbnailP02
        {
            get
            {
                if (ImageURLP02 != null && ImageURLP02 != "")
                {
                    return ImageURLP02.Substring(0, ImageURLP02.LastIndexOf('.')) + "_thumb" + ImageURLP02.Substring(ImageURLP02.LastIndexOf('.'));
                }
                return "";
            }
        }

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



        #endregion

        #region assocation
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<ListArticleABout> ListArticle
        {
            get
            {
                return GetCollection<ListArticleABout>("ListArticle");
            }
        }
        #endregion

        #region event

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case "ImageURLP01":
                    if (oldValue != null && oldValue.ToString() != newValue.ToString())
                    {
                        ValidateSystem.DeleteToServer(oldValue.ToString());
                    }
                    break;
                //case "TitleVNP01":
                //    URLVNP02 = ValidateSystem.RejectMarks(TitleVNP01, "-");
                //    break;
                //case "TitleRUP01":
                //    URLRUP02 = ValidateSystem.RejectMarks(TitleRUP01, "-");
                //    break;
            }
        }


        protected override void OnSaving()
        {
            base.OnSaving();

            ImageURLP01 = ValidateSystem.SaveFileToServer(FileDataP01, "About");
            ImageURLP02 = ValidateSystem.SaveFileToServer(FileDataP02, "About");
            ImageURLP03 = ValidateSystem.SaveFileToServer(FileDataP03, "About");
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();
          
        }

        #endregion



    }
}