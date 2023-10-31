using DAL_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Service.Service;
using RGC_Service.Models.BussinessModel;
using RGC_Service.Models;
using System.Data.SqlClient;

namespace RGC_Service.Controllers
{
    public class OthersController : Controller
    {

       private readonly IUnitOfWork  _unitOfWork;
       private readonly Global_Function  _globalfunction;
        public OthersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _globalfunction = new Global_Function(_unitOfWork);
        }
        // GET: Others
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAccessoriesByCategory(string category=null, string JobCode = null)
        {

            List<tblItemCapModel> output = _unitOfWork.GetAccessories_by_Category_JobCode(category, JobCode);

       
          

            return PartialView("_PartialReturnItem", output);
        }



        //Methos uses to load brand list category wise 

        public JsonResult GetBrandList(string category)
        {

            List<Brand> listbrand = _unitOfWork.Brands.GetWithRawSql("Select * from Brand where ctype=@ctype", new SqlParameter("@ctype", category)).ToList();




            return Json(listbrand, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetModelList(int BrandId)
        {

            List<BrandModel> output = _unitOfWork.BrandModels.GetWithRawSql("Select * from BrandModel where brdid=@brdid", new SqlParameter("@brdid", BrandId)).ToList();



            return Json(output, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFaultByCategory(string category=null, string JobCode=null)
        {

      

            //List<ClaimList> outputs = _unitOfWork.ClaimLists.Get().Where(m => m.cType.ToLower() == category.ToLower()).ToList();
            List<ClaimListModel> output = _unitOfWork.GetFault_by_Category_JobCode(category, JobCode);
                //_unitOfWork.(category, JobCode);






            return PartialView("_PartialFault", output);
        }




        //Autocomplete Function
        [HttpPost]
        public JsonResult GetJobCodeList(string term, string BranchName, int? cflag)
        {

            //List<string> JobList = new List<string>();
            //if(cflag==null || cflag == 0)
            //{ 
            //JobList = _unitOfWork.ClaimInfos.Get().Where(m => m.JobCode!=null && m.JobCode.ToLower().StartsWith(term.ToLower()) && m.Branch.ToLower() == BranchName.ToLower()).Select(m => m.JobCode).ToList();
            //}
            //else
            //{
            //    JobList = _unitOfWork.ClaimInfos.Get().Where(m => m.JobCode != null && m.JobCode.ToLower().StartsWith(term.ToLower()) && m.Branch.ToLower() == BranchName.ToLower() && m.cFlag == cflag).Select(m => m.JobCode).ToList();

            //}
            List<string> JobList = new List<string>();
            JobList = _unitOfWork.AutoComplete(term,BranchName,cflag);

            return Json(JobList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SearchProduct(string term)
        {
            List<SearchProduct> Output1 = _unitOfWork.SearchProduct(term);
            List<string> Output = (from obj in Output1 select obj.Code).ToList();
            return Json(Output, JsonRequestBehavior.AllowGet);
        }


        //Get Single product with Part No;
        [HttpPost]
        public JsonResult GetProduct(string term)
        {
            List<SearchProduct> Output = _unitOfWork.SearchProduct(term);
            //List<string> Output = (from obj in Output1 select obj.Code).ToList();
            return Json(Output, JsonRequestBehavior.AllowGet);
        }
    }
}