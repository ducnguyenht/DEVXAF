	
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace TestLog.RDS
{
    // ############################################################################
    // #
    // #        ---==>  T H I S  F I L E  W A S  G E N E R A T E D  <==---
    // #
    // # This file was generated by the CodeGen Prototype
    // # Generated on 20/03/2017 8:35:22 CH
    // #
    // # Edits to this file may cause incorrect behavior and will be lost
    // # if the code is regenerated.
    // #
    // ############################################################################
	
	// TestLog Unit-of-Work

	public partial class TestLogUnitOfWork : UnitOfWork
	{
		public TestLogUnitOfWork() : base(new TestLogDb()) { }
	}
}