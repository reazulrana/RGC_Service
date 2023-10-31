using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class JobDeliveryViewModel : JobStatusViewModel
    {

        [Display(Name = "Free of Cost/Complimentory")]
        public Nullable<int> FreeOfCost { get; set; }
        //public override Nullable<double> TotalAmount
        //{
        //    get
        //    {
        //        return ((PrdAmt + FaultFindingCharge + RepairCharge + OtherAmt + VatAmnt) - (Dis + AdvanceAmnt));

        //    }
        //}
    }
}