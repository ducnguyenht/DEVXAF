using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using CMSModule.Module.BusinessObjects.CMS.Galina;

namespace CMSModule.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.GetObjectsCount(typeof(About), null) == 0)
            {
                ObjectSpace.CreateObject<About>();
            }
            if (ObjectSpace.GetObjectsCount(typeof(Home), null) == 0)
            {
                ObjectSpace.CreateObject<Home>();
            }

            //var About = "About";
            //About theObject = ObjectSpace.FindObject<About>(CriteriaOperator.Parse("Code=?", About));
            //if (theObject == null)
            //{
            //    theObject = ObjectSpace.CreateObject<About>();
            //    theObject.Code = About;
            //}
            Contact Contact = ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse("Code=?", "Contact"));
            if (Contact == null)
            {
                Contact = ObjectSpace.CreateObject<Contact>();
                Contact.Code = "Contact";
            }
            ObjectSpace.CommitChanges();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}

            //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
