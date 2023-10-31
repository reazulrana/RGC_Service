using DAL_Service;
using DAL_Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGC_Service.Models.RGC_Service_Project_Model
{
    public class ProductServiceViewModel
    {
        public string JobCode { get; set; }
        [Display(Name ="Service By")]
        public string ServiceBy { get; set; }
        [Display(Name = "Date")]
        public string ServiceDate { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        //List<ServiceDetail> ListofProduct { get; set; }
        public List<SelectListItem> ListofEmployee { get; set; }
        public string RefuseDescription { get; set; }
        public string RefuseAmount { get; set; }

        public List<string> PartNo { get; set; }
        public List<string> Description { get; set; }
        public List<double> Qty { get; set; }
        public List<double> Price { get; set; }
       

     





    }
}