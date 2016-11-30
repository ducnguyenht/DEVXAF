using CMS.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAANSolution_BackEnd.Models
{
    public class PageComponentViewModels
    {
        public int? Id { get; set; }
         [Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentType ContentType { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int ChangedBy { get; set; }

        public PageComponent_BO MapToBO()
        {
            PageComponent_BO ret = new PageComponent_BO();
            ret.Id = Id;
            ret.Code = Code;
            ret.Name = Name;
            ret.Description = Description;
            ret.ContentType = ContentType;
            ret.IsActive = IsActive;
            ret.CreatedOn = CreatedOn;
            ret.CreatedBy = CreatedBy;
            ret.ChangedOn = ChangedOn;
            ret.ChangedBy = ChangedBy;
            return ret;
        }

        public void MapFromBO(PageComponent_BO bo){
            this.Id = bo.Id;
            this.Code = bo.Code;
            this.Name = bo.Name;
            this.Description = bo.Description;
            this.ContentType = bo.ContentType;
            this.IsActive = bo.IsActive;
            this.CreatedOn = bo.CreatedOn;
            this.CreatedBy = bo.CreatedBy;
            this.ChangedOn = bo.ChangedOn;
            this.ChangedBy = bo.ChangedBy;
        }
        public static IList<PageComponentViewModels> MapFromBOs(IList<PageComponent_BO> bos)
        {
            IList<PageComponentViewModels> apiObjs = new List<PageComponentViewModels>();
            foreach (var bo in bos)
            {
                PageComponentViewModels apiObj = new PageComponentViewModels();
                apiObj.MapFromBO(bo);
                apiObjs.Add(apiObj);
            }
            return apiObjs;
        }
    }
}