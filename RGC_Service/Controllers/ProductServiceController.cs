using DAL_Service;
using DAL_Service.Model;
using DAL_Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RGC_Service.Models.RGC_Service_Project_Model;
using RGC_Service.Models;

namespace RGC_Service.Controllers
{
    public class ProductServiceController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly Global_Function _global_function;

        // GET: ProductService


        public ProductServiceController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
            _global_function = new Global_Function(_unitofwork);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateService(string JobCode)
        {
            if(JobCode==null || JobCode == "")
            {
                JobCode = "Airp21-0001";
            }
            ClaimInfo _claiminfo = _unitofwork.GetSingleClaiminfo_By_JobCode(JobCode);

            ProductServiceViewModel _ProductServiceViewModel = new ProductServiceViewModel();
            _ProductServiceViewModel.JobCode = _claiminfo.JobCode;
            _ProductServiceViewModel.ListofEmployee = _global_function.GetEmployee();


            return View(_ProductServiceViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(ProductServiceViewModel model)
        {

            List<ServiceDetail> _ServiceDetails = new List<ServiceDetail>();
            for(int i=0; i <= model.PartNo.Count; i++)
            {
                ServiceDetail service = new ServiceDetail();
                service.JobCode = model.JobCode;
                service.ProductCode=model.PartNo[i];
                service.ProdName = model.Description[i];
                service.Qty = model.Qty[i];
                service.UnitPrice = model.Qty[i];

                _ServiceDetails.Add(service);

            }


            return View();
        }



        public ActionResult ProductSearch(string term)
        {
            bool isSuccess = true;
            Product _Product = null;

            if (!string.IsNullOrEmpty(term))
            {
                _Product = _unitofwork.Products.Get().FirstOrDefault(m => m.Code.ToLower() == term.ToLower());
            }



            if (_Product == null)
            {
                isSuccess = false;
            }


            return Json(data: new { _Product, isSuccess }, JsonRequestBehavior.AllowGet);

        }
    }
}