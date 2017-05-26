using NASDMS.RDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestLogXAF.Web
{
    public class AuditTrailViewModel
    {
        public static List<AuditTrail> GetAuditTrailsPaged(Int32 startRecord, Int32 maxRecords, String sortColumns)
        {
            NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
            List<NASDMS.RDS.AuditTrail> auditTrails = new List<NASDMS.RDS.AuditTrail>();


            try
            {
                Guid Oid = new Guid("1e01c667-8f46-4e83-83dd-6b4d8aef701f");
                AuditTrailService.GetAuditTrailsPaged(ref auditTrails, startRecord,  maxRecords,  sortColumns);
                return auditTrails;
            }
            catch (Exception) { }
            return auditTrails;
        }


        // columns are specified in the sort expression to avoid a SQL Injection attack.

        private static void VerifySortColumns(string sortColumns)
        {
            sortColumns = sortColumns.ToLowerInvariant().Replace(" asc", String.Empty).Replace(" desc", String.Empty);
            String[] columnNames = sortColumns.Split(',');

            foreach (String columnName in columnNames)
            {

                switch (columnName.Trim().ToLowerInvariant())
                {
                    case "contactid":
                    case "firstname":
                    case "lastname":
                    case "emailaddress":
                    case "phone":
                    case "":
                        break;
                    default:
                        throw new ArgumentException("SortColumns contains an invalid column name.");
                }
            }
        }

        public static Int32 GetAuditTrailsPagedCount()
        {
          

            Int32 result = 0;

            try
            {
                NASDMS.RDS.Services.AuditTrailServices.IAuditTrailService AuditTrailService = new NASDMS.RDS.Services.AuditTrailServices.AuditTrailService();
                List<NASDMS.RDS.AuditTrail> auditTrails = new List<NASDMS.RDS.AuditTrail>();
                AuditTrailService.GetAuditTrails()
                result = 99;
            }
            catch (Exception e)
            {
                // Handle exception.
            }
            finally
            {
            }

            return result;
        }
    }
}