	
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace AuditTrailRDS.RDSMysql
{
    // ############################################################################
    // #
    // #        ---==>  T H I S  F I L E  W A S  G E N E R A T E D  <==---
    // #
    // # This file was generated by the CodeGen Prototype
    // # Generated on 3/20/2017 12:11:21 PM
    // #
    // # Edits to this file may cause incorrect behavior and will be lost
    // # if the code is regenerated.
    // #
    // ############################################################################
	
	// AuditTrailRDS Unit-of-Work

	public partial class AuditTrailRDSUnitOfWork : UnitOfWork
	{
		public AuditTrailRDSUnitOfWork() : base(new AuditTrailRDSDb()) { }
	}
}
