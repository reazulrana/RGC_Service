using DAL_Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class JobStatusViewModel
    {
        [Display(Name = "Job No:")]
        public string JobCode { get; set; }

        [Display(Name = "Branch")]

        public string Branch { get; set; }



        [Display(Name = "Cust. Name")]

        public string CustName { get; set; }

        [Display(Name = "Address")]

        public string CustAddress1 { get; set; }

        [Display(Name = "Contact")]

        public string CustAddress2 { get; set; }

        [Display(Name = "Email")]
        public string CustEmail { get; set; }


        //DateInformation Information Property

        [Display(Name = "Receive Date")]
   
        public DateTime? ReceptDate { get; set; }

        [Display(Name = "Receive By")]
        public string ReceptBy { get; set; }

        [Display(Name = "App Del Date")]
        public DateTime? AppDelDate { get; set; }

        [Display(Name = "Service Date")]
        public Nullable<System.DateTime> SDate { get; set; }

        [Display(Name = "Service by")]
        public string ServiceBy { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime? PDate { get; set; }

        [Display(Name = "Previous Job ")]

        public string LastJobNO { get; set; }


        //Product Information Property

        [Display(Name = "Category")]
        public string ServiceType { get; set; }

        public string Brand { get; set; }

        [Display(Name = "Model No")]
        public string ModelNo { get; set; }

        [Display(Name = "SL No")]
        public string SLNo { get; set; }
        
        [Display(Name = "ESN Number")]
        public string ESN { get; set; }

      
        


      




    

        
        [Display(Name = "Issue to")]
        public string IssueTo { get; set; }

        [Display(Name = "Issue Date")]
        public DateTime? IsssueDate { get; set; }

        [Display(Name = "Job Type")]
        public int? WCondition { get; set; }


        public int? cFlag { get; set; }

        [Display(Name ="Remarks")]
        public string Remk { get; set; }
  

        [Display(Name ="MR No")]
        public string MRNO { get; set; }
                     

        public bool isSalesWarr { get; set; } = false;
        public bool isNonWarr { get; set; } = false;
        public bool isSVCWarr { get; set; } = false;

        [Display(Name ="Delivery Date")]
        public Nullable<System.DateTime> DDate { get; set; }

        [Display(Name ="Delivery by")]
        public string DeliverBy { get; set; }

        [Display(Name ="Fault Finding Charge")]
        public Nullable<double> FaultFindingCharge { get; set; }

        [Display(Name = "Repair Charge")]
        public Nullable<double> RepairCharge { get; set; }


        [Display(Name ="Service Charge")]
        public Nullable<double> SvAmt { get { return FaultFindingCharge + RepairCharge; } }

        [Display(Name = "Cost of Spare")]
        public Nullable<double> PrdAmt { get; set; }

        [Display(Name = "Others Charge")]
        public Nullable<double> OtherAmt { get; set; }

        [Display(Name ="Discount")]
        public Nullable<double> Dis { get; set; }

  
   

        [Display(Name ="Advance Amount")]
        public Nullable<double> AdvanceAmnt { get; set; }

        [Display(Name ="VAT")]
        public Nullable<int> VatAmnt { get; set; }

        [Display(Name = "Total Amount")]

        public virtual Nullable<double> TotalAmount { get {
                return ((PrdAmt + FaultFindingCharge+RepairCharge + OtherAmt + VatAmnt) - (Dis + AdvanceAmnt));

            } }

        [Display(Name ="Job Status")]
        public string JobStatus { get {
                string result = "";

                if (cFlag == -1)
                {
                    result = "Not Service";
                }
                else if (cFlag == 1)
                {
                    result = "Service";

                }
                else if (cFlag == 9)
                {
                    result = "Pending";

                }

                else if (cFlag == 99)
                {
                    result = "Not Repairable";

                }
                else if (cFlag == 100)
                {
                    result = "Return To The Customer";

                }
                else if(cFlag==0 || cFlag == 2)
                {
                    result = "Delivered";
                }

                return result;

            } }

        //public List<SelectedItem>

        public List<ServiceDetail> ListofParts { get; set; }
        public List<CustomerClaim> ListofComplain { get; set; }
        public List<ServiceItem> ListofItem { get; set; }


    }
}