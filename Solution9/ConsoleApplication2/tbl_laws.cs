//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_laws
    {
        public int lawid { get; set; }
        public string code_ { get; set; }
        public string title_ { get; set; }
        public int typeid { get; set; }
        public string industryid { get; set; }
        public string coquan { get; set; }
        public System.DateTime date_ { get; set; }
        public Nullable<System.DateTime> date_use { get; set; }
        public string user_sing { get; set; }
        public string file_ { get; set; }
        public short option_ { get; set; }
        public bool isdelete { get; set; }
        public bool isactive { get; set; }
        public int priority { get; set; }
    }
}