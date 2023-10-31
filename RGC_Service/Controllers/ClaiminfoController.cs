using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Service;
using DAL_Service.Model;
using DAL_Service.Service;
using RGC_Service.Models;
using RGC_Service.Models.BussinessModel;
using RGC_Service.Models.RGC_Service_Project_Model;

using System.Transactions;

namespace RGC_Service.Controllers
{
    public class ClaiminfoController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Global_Function _global_function;

        public ClaiminfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _global_function = new Global_Function(_unitOfWork);
        }


        // GET: Claiminfo
        [HttpGet]
        public ActionResult NewJob()
        {
            CreateJobViewModel _claiminfoViewModel = new CreateJobViewModel();

            //_claiminfoViewModel.JobCode = _unitOfWork.GetNewIncrementID("Airport Road");

            //_claiminfoViewModel.JobCode = _unitOfWork.GetNewIncrementID("Mirpur1");




            _claiminfoViewModel.ServiceType = "CTV";
            _claiminfoViewModel.Brand = "SONY";

            _claiminfoViewModel.listofCustomerGrade = _global_function.GetCustomerGrade();
            _claiminfoViewModel.listofBranch = _global_function.GetBranchList();
            _claiminfoViewModel.listofCategory = _global_function.GetCategoryList();
            _claiminfoViewModel.listofEmployee = _global_function.GetEmployee();
            _claiminfoViewModel.listofBrand = _global_function.GetBrandList_By_Category(_claiminfoViewModel.ServiceType);
            _claiminfoViewModel.listofModel = _global_function.GetModelList_By_Category_Brand(_claiminfoViewModel.ServiceType, _claiminfoViewModel.Brand);
            return View(_claiminfoViewModel);
        }

        [HttpPost]
        public ActionResult NewJob(CreateJobViewModel model)
        {



            if (model.WCondition == 0 && model.PDate != null)
            {


                //Hit Tables ServiceItem, CustomerClaim,CustomerClaimOthers,tbGrade,Caliminfo
                if (ModelState.IsValid)
                {


                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            ClaimInfo _claiminfo = new ClaimInfo();
                            _claiminfo.Branch = model.Branch;
                            _claiminfo.CustServiceType = model.CustServiceType;
                            /// Generate new Job Code
                            _claiminfo.JobCode = _unitOfWork.GetNewIncrementID(model.Branch);

                            _claiminfo.ReceptDate = model.ReceptDate;
                            _claiminfo.CustName = model.CustName;
                            _claiminfo.CustAddress2 = model.CustAddress2;
                            _claiminfo.CustAddress1 = model.CustAddress1;
                            _claiminfo.CustEmail = model.CustEmail;
                            _claiminfo.PDate = model.PDate;
                            _claiminfo.MRNO = model.MRNO;
                            _claiminfo.cFlag = -1;
                            _claiminfo.WCondition = model.WCondition;
                            _claiminfo.AppDelDate = model.AppDelDate;
                            _claiminfo.LastJobNO = model.LastJobNO;
                            _claiminfo.ReceptBy = model.ReceptBy;
                            _claiminfo.ServiceType = model.ServiceType;
                            _claiminfo.Brand = model.Brand;
                            _claiminfo.ModelNo = model.ModelNo;
                            _claiminfo.SLNo = model.SLNo;
                            _claiminfo.ESN = model.ESN;
                            _claiminfo.PhyCond = model.PhyCond;
                            _claiminfo.ReturnedItems = model.ReturnedItems;
                            _claiminfo.Remk = model.Remk;



                            _unitOfWork.ClaimInfos.Insert(_claiminfo);
                            _unitOfWork.Commit();


                            foreach (string item in model.btlItemCap)
                            {
                                ServiceItem _item = new ServiceItem()
                                {
                                    JobCode = _claiminfo.JobCode,
                                    Item = item,

                                };

                                _unitOfWork.ServiceItems.Insert(_item);
                                _unitOfWork.Commit();
                            }


                            //if Customer Complain Field Is Not Blank 
                            //Then Execute Below Code
                            if (model.CustomerClaimsOthers != null)
                            {
                                CustomerClaimOther _cso = new CustomerClaimOther();
                                _cso.JobCode = _claiminfo.JobCode;
                                _cso.ClaimCode = model.CustomerClaimsOthers;

                                _unitOfWork.CustomerClaimOthers.Insert(_cso);
                                _unitOfWork.Commit();
                            }

                            foreach (string _fault in model.Fault)
                            {

                                CustomerClaim _cs = new CustomerClaim()
                                {
                                    JobCode = _claiminfo.JobCode,
                                    ClaimCode = _fault
                                };
                                _unitOfWork.CustomerClaims.Insert(_cs);
                                _unitOfWork.Commit();
                            }

                            tbGrade _tbGrade = new tbGrade();
                            _tbGrade.JobCode = _claiminfo.JobCode;
                            _tbGrade.cGrade = model.CustomerGrade;
                            _tbGrade.cRemarks = model.CustomerReference;

                            _unitOfWork.tbGrades.Insert(_tbGrade);
                            _unitOfWork.Commit();





                            scope.Complete();
                        }
                        catch
                        {

                        }

                        RedirectToAction("NewJob", "Claiminfo");
                    }

                }
            }
            model.listofCustomerGrade = _global_function.GetCustomerGrade();
            model.listofBranch = _global_function.GetBranchList();
            model.listofCategory = _global_function.GetCategoryList();
            model.listofEmployee = _global_function.GetEmployee();
            return View(model);
        }






        [HttpGet]
        public ActionResult EditJob(string JobCode)
        {


            ClaimInfo _claiminfo = _unitOfWork.ClaimInfos.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == JobCode.ToLower());
            CreateJobViewModel _createJobviewmodel = new CreateJobViewModel();
            tbGrade _tbGrade = _unitOfWork.tbGrades.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == JobCode.ToLower());
            // Get Brand List by filterd Category wise
            _createJobviewmodel.listofBrand = _global_function.GetBrandList_By_Category(_claiminfo.ServiceType);
            // Get Model List by filterd Category And Brand wise

            _createJobviewmodel.listofModel = _global_function.GetModelList_By_Category_Brand(_claiminfo.ServiceType, _claiminfo.Brand);
            //_createJobviewmodel.ListofCustomerClaims = _global_function.GetClaimListBy_Category_JobCode(_claiminfo.ServiceType, JobCode);
            _createJobviewmodel.Branch = _claiminfo.Branch;
            _createJobviewmodel.CustServiceType = _claiminfo.CustServiceType;
            /// Generate new Job Code
            _createJobviewmodel.JobCode = _claiminfo.JobCode;
            _createJobviewmodel.isEditable = 1;     // 1 set for edit and 0 for New  Job
            _createJobviewmodel.ReceptDate = _claiminfo.ReceptDate;
            _createJobviewmodel.CustName = _claiminfo.CustName;
            _createJobviewmodel.CustAddress2 = _claiminfo.CustAddress2;
            _createJobviewmodel.CustAddress1 = _claiminfo.CustAddress1;
            _createJobviewmodel.CustEmail = _claiminfo.CustEmail;
            _createJobviewmodel.PDate = _claiminfo.PDate;
            _createJobviewmodel.MRNO = _claiminfo.MRNO;
            _createJobviewmodel.cFlag = _claiminfo.cFlag;
            _createJobviewmodel.WCondition = _claiminfo.WCondition;
            _createJobviewmodel.AppDelDate = _claiminfo.AppDelDate;
            _createJobviewmodel.LastJobNO = _claiminfo.LastJobNO;
            _createJobviewmodel.ReceptBy = _claiminfo.ReceptBy;
            _createJobviewmodel.ServiceType = _claiminfo.ServiceType;
            _createJobviewmodel.Brand = _claiminfo.Brand;
            _createJobviewmodel.ModelNo = _claiminfo.ModelNo;
            _createJobviewmodel.SLNo = _claiminfo.SLNo;
            _createJobviewmodel.ESN = _claiminfo.ESN;
            _createJobviewmodel.PhyCond = _claiminfo.PhyCond;
            _createJobviewmodel.ReturnedItems = _claiminfo.ReturnedItems;
            _createJobviewmodel.Remk = _claiminfo.Remk;
            _createJobviewmodel.CustomerClaimsOthers = _global_function.GetFaultOthers(JobCode);
            if (_tbGrade != null)
            {
                _createJobviewmodel.CustomerGrade = _tbGrade.cGrade;
                _createJobviewmodel.CustomerReference = _tbGrade.cRemarks;
            }



            // Enable CustomerType And  Warranty Radio Button Checked To True to True 
            _createJobviewmodel.EnableRadioButton();

            _createJobviewmodel.listofBranch = _global_function.GetBranchList();
            _createJobviewmodel.listofEmployee = _global_function.GetEmployee();
            _createJobviewmodel.listofCustomerGrade = _global_function.GetCustomerGrade();
            _createJobviewmodel.listofCategory = _global_function.GetCategoryList();




            return View(_createJobviewmodel);
        }




        [HttpPost]
        public ActionResult EditJob(CreateJobViewModel model)
        {
            //ServiceItem, CustomerClaim,CustomerClaimOthers,tbGrade,Caliminfo
            if (ModelState.IsValid)
            {


                using (TransactionScope scope = new TransactionScope())
                {
                    //try
                    //{


                    ClaimInfo _claiminfo = _unitOfWork.GetSingleClaiminfo_By_JobCode(model.JobCode);
                    _claiminfo.Branch = model.Branch;
                    _claiminfo.CustServiceType = model.CustServiceType;
                    /// Generate new Job Code
                    _claiminfo.JobCode = model.JobCode;

                    _claiminfo.ReceptDate = model.ReceptDate;
                    _claiminfo.CustName = model.CustName;
                    _claiminfo.CustAddress2 = model.CustAddress2;
                    _claiminfo.CustAddress1 = model.CustAddress1;
                    _claiminfo.CustEmail = model.CustEmail;
                    _claiminfo.PDate = model.PDate;
                    _claiminfo.MRNO = model.MRNO;
                    _claiminfo.cFlag = model.cFlag;
                    _claiminfo.WCondition = model.WCondition;
                    _claiminfo.AppDelDate = model.AppDelDate;
                    _claiminfo.LastJobNO = model.LastJobNO;
                    _claiminfo.ReceptBy = model.ReceptBy;
                    _claiminfo.ServiceType = model.ServiceType;
                    _claiminfo.Brand = model.Brand;
                    _claiminfo.ModelNo = model.ModelNo;
                    _claiminfo.SLNo = model.SLNo;
                    _claiminfo.ESN = model.ESN;
                    _claiminfo.PhyCond = model.PhyCond;
                    _claiminfo.ReturnedItems = model.ReturnedItems;
                    _claiminfo.Remk = model.Remk;



                    _unitOfWork.ClaimInfos.Update(_claiminfo);
                    _unitOfWork.Commit();



                    #region "Accessries Section"


                    //Get accessories List by JobCode from ServiceItem Table

                    List<ServiceItem> ItemList = _unitOfWork.ServiceItems.Get().Where(m => m.JobCode != null && m.JobCode.ToLower() == model.JobCode.ToLower()).ToList();

                    //check if list not null and found accessories then deleted by (SrvID) id in serviceItem Table

                    if (model.btlItemCap.Count() != ItemList.Count())
                        if (ItemList != null && ItemList.Count > 0)
                        {

                            foreach (ServiceItem item in ItemList)
                            {
                                _unitOfWork.ServiceItems.Delete(item.SrvID);
                                _unitOfWork.Commit();

                            }



                            foreach (string item in model.btlItemCap)
                            {
                                ServiceItem _item = new ServiceItem()
                                {
                                    JobCode = _claiminfo.JobCode,
                                    Item = item,

                                };

                                _unitOfWork.ServiceItems.Insert(_item);
                                _unitOfWork.Commit();
                            }
                        }

                    #endregion


                    // if record not found in customerClaimOthers Table Then Insert New Record 
                    // If Record Found in customerClaimOthers Table Then Update  Record

                    if (model.CustomerClaimsOthers != null)
                    {
                        CustomerClaimOther _cso = new CustomerClaimOther();
                        _cso.JobCode = _claiminfo.JobCode;
                        _cso.ClaimCode = model.CustomerClaimsOthers;


                        CustomerClaimOther _chechCSO = null;
                        _chechCSO = _unitOfWork.CustomerClaimOthers.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == model.JobCode.ToLower());
                        if (_chechCSO == null)
                        {
                            _unitOfWork.CustomerClaimOthers.Insert(_cso);
                        }
                        else
                        {
                            _chechCSO.JobCode = _cso.JobCode;
                            _chechCSO.ClaimCode = _cso.ClaimCode;
                            _unitOfWork.CustomerClaimOthers.Update(_chechCSO);
                        }
                        _unitOfWork.Commit();
                    }



                    #region "Fault Section"
                    //Get FaultList by JobCode from CustomerClaim Table if Found
                    List<CustomerClaim> FaultList = _unitOfWork.CustomerClaims.Get().Where(m => m.JobCode != null && m.JobCode.ToLower() == model.JobCode.ToLower()).ToList();

                    //check if list not null and found Fault in serviceItem Table
                    // deleted by (ClaimID) id in serviceItem Table

                    if (FaultList.Count() != model.Fault.Count)
                    {

                        if (FaultList != null && FaultList.Count > 0)
                        {
                            foreach (CustomerClaim item in FaultList)
                            {
                                _unitOfWork.CustomerClaims.Delete(item.ClaimID);
                                _unitOfWork.Commit();

                            }

                        }


                        // After Deleting All Record found by JobCode from CustomerClaim Table
                        //Insert New Fault in the CustomerClaim Table

                        foreach (string _fault in model.Fault)
                        {

                            CustomerClaim _cs = new CustomerClaim()
                            {
                                JobCode = _claiminfo.JobCode,
                                ClaimCode = _fault
                            };
                            _unitOfWork.CustomerClaims.Insert(_cs);
                            _unitOfWork.Commit();
                        }
                    }
                    #endregion

                    tbGrade _tbGrade = new tbGrade();
                    _tbGrade.JobCode = model.JobCode;
                    _tbGrade.cGrade = model.CustomerGrade;
                    _tbGrade.cRemarks = model.CustomerReference;



                    tbGrade _tmptbGrade = null;
                    // Check and Get Record From TbGrade Table
                    _tmptbGrade = _unitOfWork.tbGrades.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == model.JobCode.ToLower());

                    if (_tmptbGrade == null)
                    {
                        _unitOfWork.tbGrades.Insert(_tbGrade);
                    }
                    else
                    {
                        _tmptbGrade.JobCode = model.JobCode;
                        _tmptbGrade.cGrade = model.CustomerGrade;
                        _tmptbGrade.cRemarks = model.CustomerReference;


                        _unitOfWork.tbGrades.Update(_tmptbGrade);

                    }
                    _unitOfWork.Commit();





                    scope.Complete();
                    //}
                    //catch(Exception ex)
                    //{

                    //}


                    RedirectToAction("NewJob", "Claiminfo");
                }

            }
            else
            {
                model.blnPdateValidation = false;
            }

            model.listofCustomerGrade = _global_function.GetCustomerGrade();
            model.listofBranch = _global_function.GetBranchList();
            model.listofCategory = _global_function.GetCategoryList();
            model.listofEmployee = _global_function.GetEmployee();



            return View(model);
        }





        [HttpGet]
        public ActionResult OpenClaim(string claimStatus)
        {

            OpenClaim _openClaim = new OpenClaim();

            _openClaim.ClaimStatus = claimStatus;
            _openClaim.ListofBranch = _global_function.GetBranchList();

            //if (_openClaim.ClaimStatus.ToLower() == "pending".ToLower())
            //{
            //    _openClaim.cFlag = 9;
            //}



            return View(_openClaim);
        }

        //[HttpGet]
        //public ActionResult EditClaiminfo(CreateJobModel model)
        //{
        //    model.listofBranch = GetBranchList();

        //    return View(model);
        //}



        [HttpPost]
        public ActionResult OpenClaim(OpenClaim _OpenClaim)
        {

            _OpenClaim.ListofBranch = _global_function.GetBranchList();

            if (ModelState.IsValid == true)
            {
                ClaimInfo _claiminfo = _unitOfWork.GetSingleClaiminfo_By_JobCode(_OpenClaim.JobCode);
                if (_claiminfo != null)
                {

                    if (_OpenClaim.ClaimStatus.ToLower() == "jobstatus".ToLower())
                    {
                        return RedirectToAction("JobStatus", "Claiminfo", new { JobCode = _OpenClaim.JobCode });

                    }
                    else if (_OpenClaim.ClaimStatus.ToLower() == "jobassign")
                    {
                        return RedirectToAction("JobAssign", "Claiminfo", new { JobCode = _OpenClaim.JobCode });
                    }
                    else if (_OpenClaim.ClaimStatus.ToLower() == "jobedit")
                    {
                        return RedirectToAction("EditJob", "Claiminfo", new { JobCode = _OpenClaim.JobCode });

                    }
                    else if (_OpenClaim.ClaimStatus.ToLower() == "pending")
                    {
                        return RedirectToAction("Create", "Pending", new { JobCode = _OpenClaim.JobCode });

                    }
                    else if (_OpenClaim.ClaimStatus.ToLower() == "nr")
                    {
                        return RedirectToAction("Create", "NR", new { JobCode = _OpenClaim.JobCode });

                    }
                    else if (_OpenClaim.ClaimStatus.ToLower() == "createservice")
                    {
                        return RedirectToAction("CreateService", "ProductService", new { JobCode = _OpenClaim.JobCode });

                    }


                    //return RedirectToAction("JobDelivery", "Claiminfo", _OpenClaim ); //jobCode = _OpenClaim.JobCode, BranchName = _OpenClaim.BranchName });
                }
                else
                {
                    _OpenClaim.isFound = false;
                }
            }



            return View(_OpenClaim);



        }

        [HttpGet]
        public ActionResult JobAssign(string JobCode)
        {
            JobAssignViewModel model = new JobAssignViewModel();
            ClaimInfo _claiminfo = _unitOfWork.ClaimInfos.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == JobCode.ToLower());
            model.jobstatus = GetJobStatus(JobCode); //GetJobStatus returns  JobAssignViewModel 
            model.IsssueDate = _claiminfo.IsssueDate;
            model.JobCode = _claiminfo.JobCode;
            model.IssueTo = _claiminfo.IssueTo;
            model.listEmployee = _global_function.GetEmployee();
            return View(model);
        }


        [HttpPost]
        public ActionResult JobAssign(JobAssignViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                ClaimInfo _claiminfo = _unitOfWork.ClaimInfos.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == model.JobCode.ToLower());
                _claiminfo.IsssueDate = model.IsssueDate;
                _claiminfo.IssueTo = model.IssueTo;
                _claiminfo.cFlag = -1;
                model.listEmployee = _global_function.GetEmployee();
                _unitOfWork.ClaimInfos.Update(_claiminfo);
                _unitOfWork.Commit();

                RedirectToAction("JobAssign", "Claiminfo", new { JobCode = model.JobCode });
            }

            return View(model);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult JobDelivery(OpenClaim _OpenClaim)//string jobCode, string BranchName)
        {

            JobDeliveryViewModel _jobstatus = new JobDeliveryViewModel();
            tbBill_FFC _tbbill = null;
            ClaimInfo model = _unitOfWork.ClaimInfos.Get().FirstOrDefault(m => m.JobCode.ToLower() == _OpenClaim.JobCode.ToLower() && m.Branch.ToLower() == _OpenClaim.BranchName.ToLower());

            _tbbill = _unitOfWork.tbBill_FFCs.Get().FirstOrDefault(m => m.JobNO.ToLower() == model.JobCode.ToLower());

            _jobstatus.JobCode = model.JobCode;
            _jobstatus.CustName = model.CustName;
            _jobstatus.CustAddress1 = model.CustAddress1;
            _jobstatus.CustAddress2 = model.CustAddress2;
            _jobstatus.CustEmail = model.CustEmail;
            _jobstatus.ReceptDate = model.ReceptDate;
            _jobstatus.ReceptBy = model.ReceptBy;
            _jobstatus.SDate = model.SDate;
            _jobstatus.ServiceBy = model.ServiceBy;
            _jobstatus.AppDelDate = model.AppDelDate;
            _jobstatus.ServiceType = model.ServiceType;
            _jobstatus.Brand = model.Brand;
            _jobstatus.ModelNo = model.ModelNo;
            _jobstatus.SLNo = model.SLNo;
            _jobstatus.cFlag = model.cFlag;
            _jobstatus.MRNO = model.MRNO;
            _jobstatus.LastJobNO = model.LastJobNO;
            _jobstatus.PrdAmt = model.PrdAmt;
            _jobstatus.VatAmnt = model.VatAmnt;
            _jobstatus.Dis = model.Dis;
            _jobstatus.AdvanceAmnt = model.AdvanceAmnt;
            _jobstatus.OtherAmt = model.OtherAmt;

            _jobstatus.DDate = model.DDate;
            _jobstatus.DeliverBy = model.DeliverBy;




            _jobstatus.Remk = model.Remk;
            _jobstatus.Branch = model.Branch;
            _jobstatus.ESN = model.ESN;
            _jobstatus.WCondition = model.WCondition;
            _jobstatus.PDate = model.PDate;
            if (_tbbill != null)
            {
                _jobstatus.FaultFindingCharge = _tbbill.FaultCharge;
                _jobstatus.RepairCharge = _tbbill.ServiceCharge;

            }







            if (_jobstatus.WCondition == 0)
            {
                _jobstatus.isSalesWarr = true;
            }
            else if (_jobstatus.WCondition == 1)
            {
                _jobstatus.isNonWarr = true;
            }
            else
            {
                _jobstatus.isNonWarr = false;
            }

            _jobstatus.ListofItem = _unitOfWork.ServiceItems.Get().Where(m => m.JobCode.ToLower() == _jobstatus.JobCode.ToLower()).ToList();
            _jobstatus.ListofComplain = _global_function.GetCustomerClaim_By_JobCode(_jobstatus.JobCode);
            _jobstatus.ListofParts = _unitOfWork.ServiceDetails.Get().Where(m => m.JobCode.ToLower() == _jobstatus.JobCode.ToLower()).ToList();

            return View(_jobstatus);

        }



        // Job Status View call

        [HttpGet]
        public ActionResult JobStatus(string JobCode)  //string jobid)
        {
            JobStatusViewModel _jobstatus = GetJobStatus(JobCode);

            return View(_jobstatus);
        }


        [HttpGet]
        private JobStatusViewModel GetJobStatus(string JobCode)
        {

            JobStatusViewModel _jobstatus = new JobStatusViewModel();
            tbBill_FFC _tbbill = null;
            ClaimInfo model = _unitOfWork.ClaimInfos.GetWithRawSql("Select * from Claiminfo where claiminfo.JobCode=@JobCode", new SqlParameter("@JobCode", JobCode)).ToList().FirstOrDefault();
            _tbbill = _unitOfWork.tbBill_FFCs.Get().FirstOrDefault(m => m.JobNO.ToLower() == model.JobCode.ToLower());

            _jobstatus.JobCode = model.JobCode;
            _jobstatus.CustName = model.CustName;
            _jobstatus.CustAddress1 = model.CustAddress1;
            _jobstatus.CustAddress2 = model.CustAddress2;
            _jobstatus.CustEmail = model.CustEmail;
            _jobstatus.ReceptDate = model.ReceptDate;
            _jobstatus.ReceptBy = model.ReceptBy;
            _jobstatus.SDate = model.SDate;
            _jobstatus.ServiceBy = model.ServiceBy;
            _jobstatus.AppDelDate = model.AppDelDate;
            _jobstatus.ServiceType = model.ServiceType;
            _jobstatus.Brand = model.Brand;
            _jobstatus.ModelNo = model.ModelNo;
            _jobstatus.SLNo = model.SLNo;
            _jobstatus.cFlag = model.cFlag;
            _jobstatus.MRNO = model.MRNO;
            _jobstatus.LastJobNO = model.LastJobNO;
            _jobstatus.PrdAmt = model.PrdAmt;
            _jobstatus.VatAmnt = model.VatAmnt;
            _jobstatus.Dis = model.Dis;
            _jobstatus.AdvanceAmnt = model.AdvanceAmnt;
            _jobstatus.OtherAmt = model.OtherAmt;

            _jobstatus.DDate = model.DDate;
            _jobstatus.DeliverBy = model.DeliverBy;




            _jobstatus.Remk = model.Remk;
            _jobstatus.Branch = model.Branch;
            _jobstatus.ESN = model.ESN;
            _jobstatus.WCondition = model.WCondition;
            _jobstatus.PDate = model.PDate;
            if (_tbbill != null)
            {
                _jobstatus.FaultFindingCharge = _tbbill.FaultCharge;
                _jobstatus.RepairCharge = _tbbill.ServiceCharge;

            }







            if (_jobstatus.WCondition == 0)
            {
                _jobstatus.isSalesWarr = true;
            }
            else if (_jobstatus.WCondition == 1)
            {
                _jobstatus.isNonWarr = true;
            }
            else
            {
                _jobstatus.isNonWarr = false;
            }

            _jobstatus.ListofItem = _unitOfWork.ServiceItems.Get().Where(m => m.JobCode != null && m.JobCode.ToLower() == _jobstatus.JobCode.ToLower()).ToList();
            _jobstatus.ListofComplain = _unitOfWork.CustomerClaims.GetWithRawSql("select * from CustomerClaim where JobCode=@JobCode union select * from CustomerClaimOthers where JobCode=@JobCode", new SqlParameter("@JobCode", _jobstatus.JobCode)).ToList();
            _jobstatus.ListofParts = _unitOfWork.ServiceDetails.Get().Where(m => m.JobCode != null && m.JobCode.ToLower() == _jobstatus.JobCode.ToLower()).ToList();
            return _jobstatus;

        }


        ////Methos uses to load brand list category wise 

        //public JsonResult GetBrandList(string category)
        //{

        //    List<Brand> listbrand = _unitOfWork.Brands.GetWithRawSql("Select * from Brand where ctype=@ctype",new SqlParameter("@ctype", category)).ToList();




        //    return Json(listbrand, JsonRequestBehavior.AllowGet);
        //}

        // Methos uses to load Model list Brand wise
        public ActionResult GetModelList(int BrandId)
        {

            List<BrandModel> output = _unitOfWork.BrandModels.GetWithRawSql("Select * from BrandModel where brdid=@brdid", new SqlParameter("@brdid", BrandId)).ToList();



            return Json(output, JsonRequestBehavior.AllowGet);
        }





        //public ActionResult GetAccessoriesByCategory(string category,string JobCode=null)
        //{

        //    List<tblItemCap> output = _unitOfWork.tblItemCaps.Get().Where(m => m.cType.ToLower() == category.ToLower()).ToList();



        //    return PartialView("_PartialReturnItem", output);
        //}








    }
}