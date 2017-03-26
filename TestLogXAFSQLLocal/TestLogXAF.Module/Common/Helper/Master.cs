using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASDMS.Module.Common.Helper
{
    public class Master
    {
        public Master()
        {
            list = new List<Detail>();
            deleted = new List<object>();
        }
        public List<Detail> list { get; set; }
        public List<object> deleted { get; set; }
        public Guid Oid { get; set; }
        public void UpdateDetail(string propertyName, string oldValue, string newValue, bool IsNewObject)
        {
            if (IsNewObject)
            {
                Detail detail = new Detail();
                detail.propertyName = propertyName;
                detail.oldValue = oldValue;
                detail.newValue = newValue;
                list.Add(detail);
            }
            else
            {
                var listTemp = list.Where(w => w.propertyName == propertyName && w.oldValue == oldValue && w.newValue==w.newValue).FirstOrDefault();
                if (listTemp == null)
                {
                    Detail detail = new Detail();
                    detail.propertyName = propertyName;
                    detail.oldValue = oldValue;
                    detail.newValue = newValue;
                    list.Add(detail);
                }
                else
                {
                    listTemp.newValue = newValue;
                }
            }

        }
        public string DescriptionTemp { get; set; }
        public string DescriptionHistory()
        {
            DescriptionTemp = "";
            if (list != null)
            {
                foreach (var listHistory in list)
                {
                    DescriptionTemp += listHistory.propertyName + ": " + listHistory.oldValue + " -> " + listHistory.newValue + Environment.NewLine;
                }
                return DescriptionTemp;
            }
            return @"";
        }
    }
    public class Detail
    {
        public string propertyName { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
    }
}
