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
    
    public partial class tbReminder
    {
        public int RAID { get; set; }
        public string JobNo { get; set; }
        public string CTP { get; set; }
        public Nullable<System.DateTime> RecDate { get; set; }
        public Nullable<System.DateTime> ReminderDate { get; set; }
        public Nullable<bool> BillTag { get; set; }
        public string Remarks { get; set; }
    }
}
