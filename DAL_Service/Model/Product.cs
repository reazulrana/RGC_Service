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
    
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string RPCode { get; set; }
        public Nullable<int> CatagoryID { get; set; }
        public string ProdName { get; set; }
        public string LocationCode { get; set; }
        public string Model { get; set; }
        public string BinNmbr { get; set; }
        public string Country { get; set; }
        public string Maker { get; set; }
        public string Measure { get; set; }
        public Nullable<int> QtyAvl { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> MaxOrder { get; set; }
        public bool Discontinued { get; set; }
        public bool Sales { get; set; }
        public string Tag { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> Date_Time { get; set; }
        public Nullable<System.DateTime> ReorderDate { get; set; }
        public bool ReorderTag { get; set; }
        public Nullable<double> DollerPrice { get; set; }
        public Nullable<double> OP { get; set; }
        public Nullable<int> UPNO { get; set; }
        public string TrackNO { get; set; }
    }
}