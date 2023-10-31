using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Service.Model;
using RGC_Service.Models.BussinessModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class PendingViewModel
    {
        [Required(ErrorMessage ="Field is Required")]
        public string JobCode { get; set; }
        public List<string> PenCode { get; set; }
        public string PenCodeOthers { get; set; }
        [Display(Name ="Pending By")]
        [Required(ErrorMessage ="Field is Required")]
        public string PendingBy { get; set; }
        [Display(Name = "Pending Date")]
        [Required(ErrorMessage = "Field is Required")]
        public DateTime? PendingDate { get; set; }
        public bool IsSelected { get; set; }
        public List<Pending> ListPending { get; set; }
        public List<PendingModel> AllPending { get; set; }
        public List<SelectListItem> LisofEmployee { get; set; }

        public bool IsModelValid { get; set; } = true;
        public string ValidationMessage { get; set; }





    }
}