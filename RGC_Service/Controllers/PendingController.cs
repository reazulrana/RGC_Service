using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RGC_Service.Models.RGC_Service_Project_Model;
using DAL_Service.Service;
using DAL_Service.Model;
using RGC_Service.Models;
using RGC_Service.Models.BussinessModel;
using System.Data.SqlClient;
using System.Transactions;
namespace RGC_Service.Controllers
{
    public class PendingController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly Global_Function _global_function;
        // GET: Pending

        public PendingController(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
            _global_function = new Global_Function(_unitofwork);
        }

        [HttpGet]
        public ActionResult Create(string JobCode)
        {
            ClaimInfo _claiminfo = _unitofwork.GetSingleClaiminfo_By_JobCode(JobCode);

            PendingViewModel _pendingViewModel = new PendingViewModel();
            _pendingViewModel.AllPending = _global_function.GetAllPending(); //get All Hard Code pending list
            _pendingViewModel.LisofEmployee = _global_function.GetEmployee();
            _pendingViewModel.JobCode = _claiminfo.JobCode;
            _pendingViewModel.PendingBy = _claiminfo.ServiceBy;
            _pendingViewModel.PendingDate = _claiminfo.SDate;




            if (_claiminfo.cFlag!=null && _claiminfo.cFlag == 9)
            { 
            _pendingViewModel.ListPending = _unitofwork.GetPendingList_By_JobCode(JobCode); //get pending list from database if found
            //PendingOthers
            PendingOther _po = _unitofwork.GetPendingOther_By_JobCode(JobCode);

            if (_pendingViewModel.ListPending.Count > 0)
            {
                //check pending reason from all pending list if match then IsSelected true
                foreach (PendingModel pending in _pendingViewModel.AllPending)
                {

                    if (pending.PenCode.ToLower() == "Other".ToLower())
                    {
                        if (_po != null)
                        {
                            _pendingViewModel.PenCodeOthers = _po.PenCode;
                            pending.IsSelected = true;
                        }
                    }
                    
                    foreach (Pending p in _pendingViewModel.ListPending)
                    {




                        if (p.PenCode.ToLower() == pending.PenCode.ToLower())
                        {


                            pending.IsSelected = true;


                        }

                    }

                }
            }
                else
                {
                    foreach (PendingModel pending in _pendingViewModel.AllPending)
                    {
                        if (pending.PenCode.ToLower() == "Other".ToLower())
                        {
                            if (_po != null)
                            {
                                _pendingViewModel.PenCodeOthers = _po.PenCode;
                                pending.IsSelected = true;
                            }
                        }
                    }
                    }
            }

            return View(_pendingViewModel);
        }

        [HttpPost]
        public ActionResult Create(PendingViewModel model)
        {

            model.AllPending = _global_function.GetAllPending(); //get All Hard Code pending list
            model.ListPending = _global_function.GetPending_By_JobCode(model.JobCode); //get pending list from database if found
            model.LisofEmployee = _global_function.GetEmployee();
            //PendingOthers
            //PendingOther _po = _unitofwork.PendingOthers.Get().FirstOrDefault(m => m.JobCode.ToLower() == model.JobCode.ToLower());


            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if (model.PenCode == null && string.IsNullOrEmpty(model.PenCodeOthers))
            {
                model.IsModelValid = false;
                model.ValidationMessage = "Pending Reason Is Reuired";
                return View(model);

            }
            ClaimInfo _claiminfo = _unitofwork.ClaimInfos.Get().FirstOrDefault(m => m.JobCode.ToLower() == model.JobCode.ToLower());


            //Call Below Code if Job Is Deliverd
            if (_claiminfo.cFlag==100 || _claiminfo.cFlag==0 || _claiminfo.cFlag == 2)
            {
                model.IsModelValid = false;
                model.ValidationMessage = "Product is already Delivered";
                return View(model);
            }

            if (_claiminfo.cFlag == 1)
            {
                model.IsModelValid = false;
                model.ValidationMessage = "Product is already Repaired";
                return View(model);
            }

            if (_claiminfo.cFlag == 99)
            {

                _unitofwork.Delete_NRDetails_JobCode(model.JobCode);
                _unitofwork.Delete_NROther_JobCode(model.JobCode);
                


            }

            _claiminfo.ServiceBy = model.PendingBy;
            _claiminfo.SDate = model.PendingDate;
            _claiminfo.cFlag = 9;


            List<Pending> PendingList = _unitofwork.Pendings.Get().Where(m => m.JobCode.ToLower() == model.JobCode.ToLower()).ToList();
            PendingOther _PendingOther = _unitofwork.PendingOthers.Get().FirstOrDefault(m => m.JobCode.ToLower() == model.JobCode.ToLower());


            if (PendingList.Count > 0)
            {
                foreach (Pending p in PendingList)
                {
                    _unitofwork.Pendings.Delete(p.ClaimID);
                    _unitofwork.Commit();
                }
            }

            if (_PendingOther != null)
            {
                _unitofwork.PendingOthers.Delete(_PendingOther.ClaimID);
                _unitofwork.Commit();
            }


            List<Pending> Pendings = new List<Pending>();
            PendingOther po = null;
            foreach (string p in model.PenCode)
            {

                if (p.ToLower() == "Other".ToLower())
                {
                    po = new PendingOther();
                    po.JobCode = model.JobCode;
                    po.PenCode = model.PenCodeOthers;
                }
                else
                {
                    Pendings.Add(new Pending()
                    {
                        JobCode = model.JobCode,
                        PenCode = p
                    }

                    );
                }

            }

   
            using (TransactionScope scope = new TransactionScope())
            {
                    _unitofwork.ClaimInfos.Update(_claiminfo);
                    _unitofwork.Commit();

                foreach (Pending p in Pendings)
                {
                    _unitofwork.Pendings.Insert(p);
                    _unitofwork.Commit();

                }
                if (po != null)
                {
                    _unitofwork.PendingOthers.Insert(po);
                    _unitofwork.Commit();
                }
                scope.Complete();
            }
            
         
            return View(model);
        }
    }
}