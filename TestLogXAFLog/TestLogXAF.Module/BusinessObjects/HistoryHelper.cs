using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HistoryHelper
{
    public HistoryHelper()
    {
        list = new List<HistoryHelperDetail>();
    }
    List<HistoryHelperDetail> list { get; set; }
    public void UpdateDetail(string propertyName, string oldValue, string newValue)
    {
        var listTemp = list.Where(w => w.propertyName == propertyName).FirstOrDefault();
        if (listTemp == null)
        {
            HistoryHelperDetail detail = new HistoryHelperDetail();
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
    public string DescriptionHistory()
    {
        string DescriptionTemp = "";
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
public class HistoryHelperDetail
{
    public string propertyName { get; set; }
    public string oldValue { get; set; }
    public string newValue { get; set; }
}

