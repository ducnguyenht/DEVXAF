using CMS.BusinessObjects;
using CMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.OnDemandServices
{
    public class PageComponents
    {
        public PageComponents()
        {
           
        }
        public PageComponent_BO GetItem(int pageComponentId)
        {
            var dbObj = CMSContext.PageComponents.Single(pageComponentId);
            PageComponent_BO apiObj = new PageComponent_BO();
            apiObj.Id = dbObj.Id;
            apiObj.Code = dbObj.Code;
            apiObj.Name = dbObj.Name;
            apiObj.Description = dbObj.Description;
            apiObj.ContentType = (ContentType)(dbObj.ContentType);
            apiObj.IsActive = dbObj.IsActive;
            return apiObj;
        }
        public List<PageComponent_BO> GetData()
        {
            IEnumerable<PageComponent> dbObjs = CMSContext.PageComponents.All();
            List<PageComponent_BO> ret = new List<PageComponent_BO>();
            foreach (var dbObj in dbObjs)
            {
                PageComponent_BO apiObj = new PageComponent_BO();
                apiObj.Id = dbObj.Id;
                apiObj.Code = dbObj.Code;
                apiObj.Name = dbObj.Name;
                apiObj.Description = dbObj.Description;
                apiObj.ContentType = (ContentType)(dbObj.ContentType);
                apiObj.IsActive = dbObj.IsActive;
                //apiObj.CreatedOn = dbObj.CreatedOn;
                //apiObj.CreatedBy = dbObj.CreatedBy;
                //apiObj.ChangedOn = dbObj.ChangedOn;
                //apiObj.ChangedBy = dbObj.ChangedBy;
                ret.Add(apiObj);
            }
            return ret;
        }
        public void AddItem(PageComponent_BO postedItem)
        {
            PageComponent newDbObj = new PageComponent();
            newDbObj.Id = postedItem.Id;
            newDbObj.Code = postedItem.Code;
            newDbObj.Name = postedItem.Name;
            newDbObj.Description = postedItem.Description;
            newDbObj.ContentType = (int)postedItem.ContentType;
            newDbObj.IsActive = postedItem.IsActive;
            //newDbObj.CreatedOn = postedItem.CreatedOn;
            //newDbObj.CreatedBy = postedItem.CreatedBy;
            //newDbObj.ChangedOn = postedItem.ChangedOn;
            //newDbObj.ChangedBy = postedItem.ChangedBy;
            CMSContext.PageComponents.Insert(newDbObj);
        }
        public void UpdateItem(PageComponent_BO postedItem)
        {
            var dbObj = CMSContext.PageComponents.Single(postedItem.Id);
            dbObj.Name = postedItem.Name;
            dbObj.Code = postedItem.Code;
            dbObj.Description = postedItem.Description;
            dbObj.ContentType = (int)postedItem.ContentType;
            dbObj.IsActive = postedItem.IsActive;
            //dbObj.CreatedOn = postedItem.CreatedOn;
            //dbObj.CreatedBy = postedItem.CreatedBy;
            //dbObj.ChangedOn = postedItem.ChangedOn;
            //dbObj.ChangedBy = postedItem.ChangedBy;
            CMSContext.PageComponents.Update(dbObj);
        }
        public void DeleteItem(int id)
        {
            var dbObj = CMSContext.PageComponents.Single(id);
            CMSContext.PageComponents.Delete(dbObj);
        }
    }
    
}
