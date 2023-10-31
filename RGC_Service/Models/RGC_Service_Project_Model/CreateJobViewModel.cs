using RGC_Service.Models.BussinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class CreateJobViewModel
    {
      [Display(Name ="Job No:")]
        public string JobCode { get; set; }

        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Branch is required")]
        public string Branch { get; set; }

     

        [Display(Name = "Cust. Name")]
        [Required(ErrorMessage = "Customer Name Is Required")]
        public string CustName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Customer Address Is Required")]
        public string CustAddress1 { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Cusrtomer Address Is Required")]
        public string CustAddress2 { get; set; }

        [Display(Name = "Email")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "Brand Is Required")]
        public string Brand { get; set; }

        [Display(Name = "Model No")]
        [Required(ErrorMessage = "Model Is Required")]
        public string ModelNo { get; set; }

        [Display(Name ="ESN Number")]
        public string ESN { get; set; }

        [Display(Name = "Seriel No")]
        [Required(ErrorMessage = "SL No Is Required")]
        public string SLNo { get; set; }

        [Display(Name = "Rec. Date")]
        //[DataType(DataType.Date, ErrorMessage = "Data is not DateTime")]
        public DateTime? ReceptDate { get; set; }

        [Display(Name = "Cust. Grade")]
        public string CustomerGrade { get; set; }

        [Display(Name = "Delivery Date")]
        //[DataType(DataType.Date, ErrorMessage = "Data is not DateTime")]

        public DateTime? AppDelDate { get; set; }

        [Display(Name = "Customer")]
        public bool IsRel { get; set; }


        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category No Is Required")]
        public string ServiceType { get; set; }

        [Display(Name = "Purchase Date")]
        //[DataType(DataType.Date, ErrorMessage = "Data is not DateTime")]
        public DateTime? PDate { get; set; }

        [Display(Name = "Rec. By")]
        [Required(ErrorMessage = "Category No Is Required")]
        public string ReceptBy { get; set; }
        [Display(Name = "Issue to")]
        public string IssueTo { get; set; }
        [Display(Name = "Issue Date")]
       
        public DateTime? IsssueDate { get; set; }
        [Display(Name = "Job Type")]
        public int? WCondition { get; set; }
        public int? cFlag { get; set; }
        public string Remk { get; set; }
        [Display(Name ="Physical Condition")]
        public string PhyCond { get; set; }
        public string Log_User { get; set; }
        public DateTime? Log_Date { get; set; }
        [Display(Name ="Mr No")]
        public string MRNO { get; set; }
        [Display(Name = "Previous Job")]
        public string LastJobNO { get; set; }
        [Display(Name = "Returned Items")]
        public string ReturnedItems { get; set; }
        public string ItemRemarks { get; set; }
        public string CustomerClaimsOthers { get; set; }
        public string sRemarks { get; set; }
        [Display(Name = "Cust. Ref")]
        public string CustomerReference { get; set; }
        [Display(Name = "Customer")]
        public string RELCustomer { get; set; }
        public string CustServiceType { get; set; }


        public List<SelectListItem> listofBranch { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> listofCustomerGrade { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> listofEmployee { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> listofCategory { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> listofBrand { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> listofModel { get; set; } = new List<SelectListItem>();
        //public List<ClaimListModel> ListofCustomerClaims { get; set; } // filter by category and jobcode and isSeleted will true

        public List<string> Fault { get; set; }

        public List<string> btlItemCap { get; set; }


        public int isEditable { get; set; } = 0; // 0 for new job and 1 = Edit Job



        // use for Enbale Warranty Radio Button Checked  Warranty Radio
        public bool blnslswarranty { get; set; } = false;
        public bool blnNonwarranty { get; set; } = true;
        public bool blnSvcWarranty { get; set; } = false;

        public bool blnWalkingService { get; set; } = true;
        public bool blnHomeService { get; set; } = false;

        //use for Eanble CustomerType And Warranty Radio Button
        public void EnableRadioButton ()
            {
            blnslswarranty = false;
            blnNonwarranty = false;
            blnSvcWarranty = false;

            blnWalkingService = false;

            blnHomeService = false;
                if (WCondition == 0)
                {
                    blnslswarranty = true;
                }
                else if (WCondition == 1)
                {
                    blnNonwarranty = true;
                }
                else if (WCondition == 2)
                {
                    blnSvcWarranty = true;
                }


            if (CustServiceType.ToLower() == "Walking Service".ToLower())
            {
                blnWalkingService = true;
            }
            else if(CustServiceType.ToLower() == "Home Service".ToLower())
            {
                blnHomeService = true;
            }
            
        }
        public bool blnPdateValidation { get; set; } = true; // warrant 0 and purchase date null then hit the property

    }
}