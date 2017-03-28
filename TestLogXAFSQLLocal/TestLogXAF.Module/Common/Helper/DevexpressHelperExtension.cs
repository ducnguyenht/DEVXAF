using DevExpress.Persistent.AuditTrail;
using DevExpress.Xpo;
using NASDMS.Module.Common.Helper;
using NASDMS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DevexpressHelperExtension
{

    public static List<NASDMS.Module.Common.NonPersistents.History> LoadHistory(Guid Oid, Session session)
    {
        NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
        List<NASDMS.Module.Common.NonPersistents.History> lstH = new List<NASDMS.Module.Common.NonPersistents.History>();
        try
        {
            List<NASDMS.RDS.AuditTrail> auditTrails = new List<NASDMS.RDS.AuditTrail>();
            AuditTrailService.GetAuditTrails(ref auditTrails, Oid);
            foreach (var item in auditTrails)
            {
                NASDMS.Module.Common.NonPersistents.History h = new NASDMS.Module.Common.NonPersistents.History(session);
                h.ChangedBy = item.ChangedBy;
                h.Data = item.Data;
                h.ChangedOn = item.ChangedOn.Value;
                h.Action = item.ActionAudit;
                h.Category = item.CategoryAudit;
                lstH.Add(h);
            }
        }
        catch (Exception)
        {
            lstH = new List<NASDMS.Module.Common.NonPersistents.History>();
        }
        return lstH;
    }




    /// <summary>
    /// Save AuditTrail to Mysql.
    /// </summary>
    /// <param name="master">The master.</param>
    /// <param name="oid">The oid.</param>
    /// <param name="name">The name.</param>
    /// <param name="category">The category.</param>
    /// <param name="IsNewObj">if set to <c>true</c> [is new object].</param>
    /// <param name="nameObjectDeleted">The name object deleted.</param>
    public static void ToHistory(this Master HistoryHelper, Guid Oid, string ObjToString, string ChangedBy, CategoryAudit Category, bool IsNewObject = false, string NameObjectDeleted = null)
    {
        if (IsNewObject)
        {
            if (HistoryHelper.DescriptionHistory() != "")
            {
                NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
                var temp = new Master();
                temp.list = HistoryHelper.list.Where(o => o.action == NASDMS.Module.Common.Helper.Action.Created).ToList();
                if (temp.DescriptionHistory() != "")
                {
                    AuditTrailService.AddAuditTrail(Oid, ChangedBy, temp.DescriptionHistory(), Category, ActionAudit.Created);
                    foreach (var item in temp.list)
                    {
                        HistoryHelper.list.Remove(item);
                    }
                }
            }
        }
        else
        {
            if (NameObjectDeleted == null)
            {
                if (HistoryHelper.DescriptionHistory() != "")
                {
                    NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
                    var finds = HistoryHelper.list.Where(o => o.Oid == HistoryHelper.Oid).ToList();
                    var DescriptionTemp = "";
                    if (finds != null)
                    {
                        foreach (var listHistory in finds)
                        {
                            DescriptionTemp += listHistory.propertyName + ": " + listHistory.oldValue + " -> " + listHistory.newValue + Environment.NewLine;
                        }
                    }
                    foreach (var item in finds)
                    {
                        HistoryHelper.list.Remove(item);

                    }
                    AuditTrailService.AddAuditTrail(Oid, ChangedBy, ObjToString + Environment.NewLine + DescriptionTemp, Category, ActionAudit.Updated);
                }
            }
            else
            {
                NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
                AuditTrailService.AddAuditTrail(Oid, ChangedBy, NameObjectDeleted, Category, ActionAudit.Deleted);
            }
        }
        return;
    }

    public static string ToCustomString(this object obj)
    {
        string ret = "N/A";
        if (obj == null)
        {
            return ret;
        }
        switch (Type.GetTypeCode(obj.GetType()))
        {
            case TypeCode.DateTime:
                var date = obj.ToObject<DateTime>();
                if (date != default(DateTime))
                    ret = date.ToDateTime();
                break;
            case TypeCode.Decimal:
                ret = obj.ToObject<Decimal>().ToQuantity();
                break;
            default:
                if (obj.GetType().IsEnum)
                {
                    ret = obj.ToObject<Enum>().ToEnumLocalization();
                }
                else
                {
                    ret = obj.ToString();
                }
                break;
        }
        return ret;
    }
    /// <summary>
    /// Localize Property Field(Name -> Tên).
    /// </summary>
    public static string ToLocalization(this string str, object T)
    {
        return DevExpress.ExpressApp.Utils.CaptionHelper.GetMemberCaption(T.GetType(), str);
    }
    /// <summary>
    /// Localize Enum Field( Enum.Status -> Trạng thái).
    /// </summary>
    public static string ToEnumLocalization(this Enum str)
    {
        return DevExpress.ExpressApp.Utils.CaptionHelper.GetDisplayText(str);
    }
    public static string ToChildHistory(this string str)
    {
        return "\t\t" + str;
    }
    public static string WithChildTable(this string str, object T)
    {
        return T.GetType().Name + Environment.NewLine + str;
    }
    /// <summary>
    /// dd/MM/yyyy hh:mm:ss
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>dd/MM/yyyy hh:mm:ss</returns>
    public static string ToDateTime(this DateTime dt)
    {
        return dt.ToString("dd/MM/yyyy hh:mm:ss");
    }
    public static string ToDateTime(this DateTime? dt)
    {
        return dt.Value.ToString("dd/MM/yyyy hh:mm:ss");
    }
    /// <summary>
    /// To the price #,##0 : 30,000
    /// </summary>
    public static string ToPrice(this decimal? de)
    {
        return de.Value.ToString("#,##0");
    }
    /// <summary>
    /// To the price? #,##0 : 30,000
    /// </summary>
    public static string ToPrice(this decimal de)
    {
        return de.ToString("#,##0");
    }
    /// <summary>
    /// To the quantity #,##0.00
    /// </summary>
    public static string ToQuantity(this decimal? de)
    {
        return de.Value.ToString("#,##0.00");
    }
    /// <summary>
    /// To the quantity? #,##0.00
    /// </summary>
    public static string ToQuantity(this decimal de)
    {
        return de.ToString("#,##0.00");
    }
    public static T ToObject<T>(this object obj)
    {
        return (T)obj;
    }
}

