using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class OpenClaim
    {
        [Display(Name ="Select Branch")]
        [Required(ErrorMessage ="Branch Is Required")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Branch Is Required")]
        [Display(Name ="Open Job")]
        public string JobCode { get; set; }
        public List<SelectListItem> ListofBranch { get; set; }
        public bool isFound { get; set; } = true; // check if JobCode not Found in the Database then set to False
        public string ClaimStatus { get; set; }
        public int cFlag { get; set; }
        
    }
}