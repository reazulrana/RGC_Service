using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class JobAssignViewModel
    {
        [Display(Name ="Job Code")]
        public string JobCode { get; set; }
        [Display(Name ="Issue Date")]
        public Nullable<System.DateTime> IsssueDate { get; set; }
        [Display(Name = "Issue To")]
        public string IssueTo { get; set; }
        public List<SelectListItem> listEmployee { get; set; }
        public JobStatusViewModel jobstatus { get; set; }

    }
}