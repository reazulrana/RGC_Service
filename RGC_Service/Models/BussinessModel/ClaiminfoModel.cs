﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RGC_Service.Models.BussinessModel
{
    public class ClaiminfoModel
    {
        public long JobID { get; set; }
        public string JobCode { get; set; }
        public string Branch { get; set; }
        public string BrCode { get; set; }
        public Nullable<int> EID { get; set; }
        public string CustName { get; set; }
        public string CustAddress1 { get; set; }
        public string CustAddress2 { get; set; }
        public string CustEmail { get; set; }
        public string Brand { get; set; }
        public string ModelNo { get; set; }
        public string MobileNo { get; set; }
        public string ESN { get; set; }
        public string SLNo { get; set; }
        public Nullable<System.DateTime> ReceptDate { get; set; }
        public Nullable<System.DateTime> AppDelDate { get; set; }
        public string ServiceType { get; set; }
        public Nullable<System.DateTime> PDate { get; set; }
        public string ReceptBy { get; set; }
        public Nullable<int> ReceptByID { get; set; }
        public string IssueTo { get; set; }
        public Nullable<int> IssueToID { get; set; }
        public Nullable<System.DateTime> IsssueDate { get; set; }
        public Nullable<System.DateTime> SDate { get; set; }
        public string ServiceBy { get; set; }
        public Nullable<System.DateTime> DDate { get; set; }
        public string DeliverBy { get; set; }
        public Nullable<int> WCondition { get; set; }
        public Nullable<int> cFlag { get; set; }
        public Nullable<double> SvAmt { get; set; }
        public Nullable<double> PrdAmt { get; set; }
        public Nullable<double> OtherAmt { get; set; }
        public Nullable<double> Dis { get; set; }
        public Nullable<int> SRFlag { get; set; }
        public string Remk { get; set; }
        public string PhyCond { get; set; }
        public string Log_User { get; set; }
        public Nullable<System.DateTime> Log_Date { get; set; }
        public string MRNO { get; set; }
        public string LastJobNO { get; set; }
        public Nullable<double> cAdvance { get; set; }
        public Nullable<double> cTransportCrg { get; set; }
        public string ReturnedItems { get; set; }
        public string ItemRemarks { get; set; }
        public Nullable<int> FreeOfCost { get; set; }
        public Nullable<double> AdvanceAmnt { get; set; }
        public Nullable<int> VatAmnt { get; set; }
        public string ChassisNo { get; set; }
        public string MeterReading { get; set; }
        public string CustomerClaims { get; set; }
        public string RecAccessories { get; set; }
        public string CustServiceType { get; set; }
        public string sRemarks { get; set; }
        public Nullable<int> OnlineEntry { get; set; }
        public Nullable<double> VatPer { get; set; }
    }
}