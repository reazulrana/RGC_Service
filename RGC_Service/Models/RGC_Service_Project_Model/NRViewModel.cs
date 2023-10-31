using DAL_Service.Model;
using RGC_Service.Models.BussinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class NRViewModel
    {
        [Required(ErrorMessage =("Job Code is Required"))]
        public string JobCode { get; set; }
        public List<string> NRCode { get; set; }
        public string NRCodeOthers { get; set; }
        public string NRBy { get; set; }
        public DateTime? NRDate { get; set; }
        public List<NRDetailsModel> GetAllNR { get; set; }
        public List<SelectListItem> ListofEmployee { get; set; }

        public bool blnNRValidation { get; set; } = true;
        public string NRValidationMessage { get; set; }
    }
}