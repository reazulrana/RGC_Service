//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_Service.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Branch
    {
        public int BrID { get; set; }
        public string BranchName { get; set; }
        public string phone { get; set; }
        public string ContactPerson { get; set; }
        public string Desg { get; set; }
        public Nullable<int> Flag { get; set; }
        public Nullable<int> EID { get; set; }
        public string BrCode { get; set; }
        public Nullable<int> ActiveInactive { get; set; }
        public string BrType { get; set; }
        public Nullable<int> ActiveDeactive { get; set; }
        public string BranchEmail { get; set; }
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
    }
}
