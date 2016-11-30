using CMS.BusinessObjects.Base;
using CMS.BusinessObjects.Base.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessObjects
{
    public class PageComponent_BO : BusinessObject
    {
        public PageComponent_BO()
        {
            AddRule(new ValidateId("Code"));
            AddRule(new ValidateRequired("Name"));
        }
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentType ContentType { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int ChangedBy { get; set; }
    }
    public enum ContentType
    {
        Article = 1,
        Image = 2,
        Event = 3,
        Advertisement = 4
    }
}
