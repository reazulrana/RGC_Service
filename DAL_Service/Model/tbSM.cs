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
    
    public partial class tbSM
    {
        public int AID { get; set; }
        public string ContactNo { get; set; }
        public string SMSText { get; set; }
        public string UserID { get; set; }
        public string PCName { get; set; }
        public Nullable<bool> Tag { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string SMSSource { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
    }
}
