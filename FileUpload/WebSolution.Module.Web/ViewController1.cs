using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System.IO;
using System.Web;
using System.Security.Permissions;
using System.Security;

namespace WebSolution.Module.Web
{
    public partial class ViewController1 : ViewController
    {
        public ViewController1()
        {
            InitializeComponent();
            RegisterActions(components);
            TargetObjectType = typeof(DomainObject1);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.Committing += new EventHandler<CancelEventArgs>(ObjectSpace_Committing);
        }
        void ObjectSpace_Committing(object sender, CancelEventArgs e)
        {
            if (View.CurrentObject != null)
            {
                DomainObject1 obj = View.CurrentObject as DomainObject1;
                if (obj.File != null)
                {
                    try
                    {
                        string filePath = HttpContext.Current.Request.MapPath("~/FileData/" + obj.File.FileName);
                        Stream stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
                        obj.File.SaveToStream(stream);
                        obj.ImageUrl = "~/FileData/" + obj.File.FileName;
                        e.Cancel = true;
                    }
                    catch (SecurityException s)
                    {
                        Console.WriteLine(s.Message);
                    }
                    //FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Read, HttpContext.Current.Request.MapPath("~/FileData/"));
                    //f2.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, HttpContext.Current.Request.MapPath("~/FileData/" + obj.File.FileName));
                    //try
                    //{
                    //    string filePath = HttpContext.Current.Request.MapPath("~/FileData/" + obj.File.FileName);
                    //    Stream stream = new FileStream(HttpContext.Current.Request.MapPath("~/FileData/" + obj.File.FileName), FileMode.CreateNew, FileAccess.Write);
                    //    obj.File.SaveToStream(stream);
                    //    e.Cancel = true;
                    //    obj.ImageUrl = "~/FileData/" + obj.File.FileName;
                    //    f2.Demand();
                    //}
                    //catch (SecurityException s)
                    //{
                    //    Console.WriteLine(s.Message);
                    //}

                }
            }
        }
    }
}
