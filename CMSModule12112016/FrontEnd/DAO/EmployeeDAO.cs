using CMSModule.Module.BusinessObjects.CMS.Galina;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InsuranceAM.WebApi.DataAccess
{
    public class EmployeeDAO : XpoDAO
    {
        public EmployeeDAO()
            : base(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString,
                typeof(CMSModule.Module.CMSModuleModule).Assembly)
        {

        }

        public IList<About> GetEmployeesByTitle()
        {
            var uow = ProvideUnitOfWork();
            var result = new XPCollection<About>(uow);//, new BinaryOperator("Title", title, BinaryOperatorType.Equal));
            //IList<About> ret = new List<About>();
            //foreach (var em in result)
            //{
            //    ret.Add(new About()
            //    {
            //        Id = em.Oid.ToString(),
            //        Name = em.FirstName + " " + em.LastName
            //    });
            //}
            return result;
        }
    }
}