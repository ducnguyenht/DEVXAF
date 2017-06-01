using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NASDMS.Systems;

namespace NASDMS.RDS
{
	// Generated 06/01/2017 17:22:32
	
	// Add custom code inside partial class

	public partial class AuditTrail : Entity<AuditTrail>
    {
        [EnumDataType(typeof(CategoryAudit))]
        public CategoryAudit CategoryAudit
        {
            get
            {
                return (CategoryAudit)this.Category;
            }
            set
            {
                this.Category = (int)value;
            }
        }

        [EnumDataType(typeof(ActionAudit))]
        public ActionAudit ActionAudit
        {
            get
            {
                return (ActionAudit)this.Action;
            }
            set
            {
                this.Action = (int)value;
            }
        }
	} 
}	
