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
    
    public partial class LogUser
    {
        public long LID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> LogIn { get; set; }
        public Nullable<System.DateTime> LogOut { get; set; }
        public string LogINFrom { get; set; }
        public string UserPC { get; set; }
    }
}
