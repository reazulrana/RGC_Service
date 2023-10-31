using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Service.Model;
using DAL_Service.Service;
using RGC_Service.Models.BussinessModel;

namespace RGC_Service.Models
{
    public class Global_Function
    {
        private IUnitOfWork _unitOfWork;

        public Global_Function(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<SelectListItem> GetCategoryList()
        {

            List<SelectListItem> _list = (from obj in _unitOfWork.Categories.Get()
                                          select new SelectListItem()
                                          {
                                              Text = obj.cTypeName,
                                              Value = obj.cTypeName
                                          }).ToList();
            return _list;
        }


        public List<SelectListItem> GetBranchList()
        {


            List<SelectListItem> _list = (from obj in _unitOfWork.Branchs.Get()
                                          select new SelectListItem()
                                          {
                                              Text = obj.BranchName,
                                              Value = obj.BranchName
                                          }).ToList();



            return _list;
        }

        public List<SelectListItem> GetEmployee()
        {
            List<SelectListItem> output = (from obj in _unitOfWork.Personals.Get()
                                           orderby obj.EmpName
                                           select new SelectListItem()
                                           {
                                               Text = obj.EmpName,
                                               Value = obj.EmpCode
                                           }
                                         ).ToList();

            return output;
        }


        public List<SelectListItem> GetCustomerGrade()
        {

            List<SelectListItem> CustomerGrade = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text="VIP",
                    Value="VIP",
                    Selected=true
                },

                new SelectListItem
                {
                    Text="Frequent",
                    Value="Frequent"
                },
                   new SelectListItem
                {
                    Text="Top",
                    Value="Top"
                },

                new SelectListItem
                {
                    Text="Special",
                    Value="Special"
                },

                new SelectListItem
                {
                    Text="Others",
                    Value="Others"
                }
            }; //lstCusGrade;

            return CustomerGrade;
        }


        public List<SelectListItem> GetAllBrand
        {
            get
            {
                List<SelectListItem> output = (from obj in _unitOfWork.Brands.Get()
                                               select new SelectListItem()
                                               {
                                                   Text = obj.BrandName,
                                                   Value = obj.BrandName
                                               }).ToList();
                return output;
            }
        }


        public List<SelectListItem> GetBrandList_By_Category(string Category)
        {

            var list = _unitOfWork.Brands.Get().Where(m => m.cType.ToLower() == Category.ToLower()).ToList();

            List<SelectListItem> output = (from obj in list
                                           select new SelectListItem()
                                           {
                                               Text = obj.BrandName,
                                               Value = obj.BrandName


                                           }).ToList();
            return output;

        }

        public List<SelectListItem> GetModelList_By_Category_Brand(string Category, string Brandname)
        {

            var list = _unitOfWork.Brands.Get().FirstOrDefault(m => m.cType.ToLower() == Category.ToLower() && m.BrandName.ToLower() == Brandname.ToLower());

            List<SelectListItem> output = (from obj in _unitOfWork.BrandModels.Get()
                                           where obj.BrdID == list.BrdID
                                           select new SelectListItem()
                                           {
                                               Text = obj.Model,
                                               Value = obj.Model
                                           }).ToList();
            return output;

        }

        public List<SelectListItem> GetAllModel
        {
            get
            {
                List<SelectListItem> output = (from obj in _unitOfWork.BrandModels.Get()
                                               select new SelectListItem()
                                               {
                                                   Text = obj.Model,
                                                   Value = obj.Model
                                               }).ToList();
                return output;
            }
        }
        public List<CustomerClaim> GetCustomerClaim_By_JobCode(string JobCode)
        {

            List<CustomerClaim> output = new List<CustomerClaim>();
            output = _unitOfWork.CustomerClaims.GetWithRawSql("select * from CustomerClaim where JobCode=@JobCode union select * from CustomerClaimOthers where JobCode=@JobCode", new SqlParameter("@JobCode", JobCode)).ToList();

            return output;
        }

        public List<Pending> GetPending_By_JobCode(string JobCode)
        {

            List<Pending> output = new List<Pending>();
            output = _unitOfWork.Pendings.GetWithRawSql("select * from pending where JobCode=@JobCode union select * from pendingOther where JobCode=@JobCode", new SqlParameter("@JobCode", JobCode)).ToList();

            return output;
        }

        public List<PendingModel> GetAllPending()
        {
            List<PendingModel> output = new List<PendingModel>()
          {
              new PendingModel()
              {
                  PenCode="Waiting for Service Manual"
              },
              new PendingModel()
              {
                  PenCode="Technical Problem"
              },
               new PendingModel()
              {
                  PenCode="Waiting for Parts"
              },

                 new PendingModel()
              {
                  PenCode="Technical Help"
              },
                      new PendingModel()
              {
                  PenCode="Under Estimate"
              },
                                 new PendingModel()
              {
                  PenCode="Other"
              }
          };
            return output;
        }


        public List<NRDetailsModel> GetAllNR()
        {
            List<NRDetailsModel> output = new List<NRDetailsModel>()
          {
              new NRDetailsModel()
              {
                   NRCode="PCB Damage"
              },
              new NRDetailsModel()
              {
                  NRCode="Software Problem"
              },
               new NRDetailsModel()
              {
                  NRCode="Drop in ther water"
              },

                 new NRDetailsModel()
              {
                  NRCode="Unavailable Parts"
              },
                      new NRDetailsModel()
              {
                  NRCode="Drop on the floor"
              },
                                 new NRDetailsModel()
              {
                  NRCode="Technical Problem"
              },
                                                    new NRDetailsModel()
              {
                  NRCode="Connect Another Charger"
              },
                                                    new NRDetailsModel()
              {
                  NRCode="Set Lock"
              },
                                                    new NRDetailsModel()
              {
                  NRCode="PCB Crack"
              },
                                                    new NRDetailsModel()
              {
                  NRCode="Open Outside"
              },
                                                    new NRDetailsModel()
              {
                  NRCode="Other"
              }


          };
            return output;
        }



        public string GetFaultOthers(string JobCode)
        {
            string CLaimOther = "";
            CustomerClaimOther output = _unitOfWork.CustomerClaimOthers.Get().FirstOrDefault(m => m.JobCode != null && m.JobCode.ToLower() == JobCode.ToLower());
            if (output != null)
            {

                CLaimOther = output.ClaimCode;
            }
            return CLaimOther;
        }




    }
}