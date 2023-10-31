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
using System.Transactions;

namespace RGC_Service.Controllers
{
    public class NRController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Global_Function _global_function;

        public NRController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _global_function = new Global_Function(_unitOfWork);
        }


        [HttpGet]
        public ActionResult Create(string JobCode)
        {

            NRViewModel _nrviewmodel = new NRViewModel();
            _nrviewmodel.GetAllNR = _global_function.GetAllNR();
            _nrviewmodel.ListofEmployee = _global_function.GetEmployee();
            ClaimInfo _claiminfo = _unitOfWork.GetSingleClaiminfo_By_JobCode(JobCode);
           


            if (_claiminfo != null)
            {
                _nrviewmodel.JobCode = _claiminfo.JobCode;
                _nrviewmodel.NRDate = _claiminfo.SDate;
                _nrviewmodel.NRBy = _claiminfo.ServiceBy;
                if (_claiminfo.cFlag==99 || _claiminfo.cFlag == 100)
                {
                    List<NRDetail> NRList = _unitOfWork.GetNRList_By_JobCode(JobCode);
                    NROther _NRO= _unitOfWork.GetNROther_By_JobCode(JobCode);

                    if (NRList.Count > 0)
                    {
                        foreach(NRDetailsModel nrd in _nrviewmodel.GetAllNR)
                        {
                            if (nrd.NRCode.ToLower() == "Other".ToLower())
                            {
                                if (_NRO != null)
                                {
                                    _nrviewmodel.NRCodeOthers = _NRO.NRCode;
                                    nrd.IsSelected = true;
                                }

                            }

                            foreach(NRDetail nr in NRList)
                            {
                                if (nr.NRCode.ToLower() == nrd.NRCode.ToLower())
                                {
                                    nrd.IsSelected = true;
                                }
                            }

                        }


                    }
                    else
                    {
                        if (_NRO != null) { }
                        foreach (NRDetailsModel nrd in _nrviewmodel.GetAllNR)
                        {
                            if (nrd.NRCode.ToLower() == "Other".ToLower())
                            {
                                _nrviewmodel.NRCodeOthers = _NRO.NRCode;
                                nrd.IsSelected = true;
                            }

                        }
                    }
                }
            }
            return View(_nrviewmodel);
        }


        [HttpPost]
        public ActionResult Create(NRViewModel model)
        {
            model.ListofEmployee = _global_function.GetEmployee();
            model.GetAllNR = _global_function.GetAllNR();
            if (model.NRCode.Count == 0 && model.NRCodeOthers == null)
            {
                model.blnNRValidation = false;
                model.NRValidationMessage = "Require One Or More NR";
                return View(model);
            }

            if (ModelState.IsValid)
            {

         
             

            List<NRDetail> NRList = _unitOfWork.GetNRList_By_JobCode(model.JobCode);
            NROther _NRO = _unitOfWork.GetNROther_By_JobCode(model.JobCode);

            if (NRList.Count > 0)
            {
                _unitOfWork.Delete_NRDetails_JobCode(model.JobCode);

            }
            if (_NRO != null)
            {
                _unitOfWork.Delete_NROther_JobCode(model.JobCode);
            }

            using(TransactionScope scope=new TransactionScope())
            {
                    ClaimInfo _claiminfo = _unitOfWork.GetSingleClaiminfo_By_JobCode(model.JobCode);

                    //if Job is Deliverd Or Customer Return Execute Code
                    if (_claiminfo.cFlag==100 || _claiminfo.cFlag==0 || _claiminfo.cFlag == 2)
                    {
                        model.blnNRValidation = false;
                        model.NRValidationMessage = "The Job Cannot Be NR Because Product Is 'Deliverd Or Return To The Customer'";
                        return View(model);
                    }
                    //if Job is Deliverd Or Customer Return Execute Code
                    if (_claiminfo.cFlag == 1 )
                    {
                        model.blnNRValidation = false;
                        model.NRValidationMessage = "The Job Cannot Be NR Because Product Is already 'Repair Condition'";
                        return View(model);
                    }




                    if (_claiminfo.cFlag == 9)
                    {
                        _unitOfWork.Delete_Pending_JobCode(model.JobCode);
                        _unitOfWork.Delete_PendingOther_JobCode(model.JobCode);


                    }


                    _claiminfo.SDate = model.NRDate;
                    _claiminfo.ServiceBy = model.NRBy;
                    _claiminfo.cFlag = 99;

                    _unitOfWork.ClaimInfos.Update(_claiminfo);
                    _unitOfWork.Commit();



                    foreach (string nr in model.NRCode)
                    {

                        NRDetail nrd = new NRDetail()
                        {
                            JobCode = model.JobCode,
                             NRCode= nr

                        };
                        _unitOfWork.NRDetails.Insert(nrd);
                        _unitOfWork.Commit();
                    }

                    if(model.NRCodeOthers!=null && model.NRCodeOthers != "")
                    {
                        NROther nro = new NROther();
                        nro.JobCode = model.JobCode;
                        nro.NRCode = model.NRCodeOthers;
                        _unitOfWork.NROthers.Insert(nro);
                        _unitOfWork.Commit();

                    }
                    scope.Complete();
            }
                }
         
        

            return View(model);
        }
    }
}