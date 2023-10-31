using DAL_Service.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL_Service.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly string path = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;


        private RELServiceEntities _dbContext;
        private BaseRepository<ClaimInfo> _claimInfos;
        private BaseRepository<Branch> _Branchs;

        private BaseRepository<cType> _Categories;
        private BaseRepository<Product> _Products;
        private BaseRepository<Personal> _Personals;
        private BaseRepository<Brand> _Brands;
        private BaseRepository<tblItemCap> _tblItemCaps;
        private BaseRepository<ClaimList> _ClaimLists;
        private BaseRepository<BrandModel> _BrandModels;
        private BaseRepository<ServiceItem> _ServiceItems;
        private BaseRepository<CustomerClaim> _CustomerClaims;
        private BaseRepository<ServiceDetail> _ServiceDetails;
        private BaseRepository<tbBill_FFC> _tbBill_FFCs;
        private BaseRepository<tbGrade> _tbGrades;
        private BaseRepository<CustomerClaimOther> _CustomerClaimOthers;
        private BaseRepository<Pending> _Pendings;

        private BaseRepository<PendingOther> _PendingOthers;

        private BaseRepository<NRDetail> _NRDetails;
        private BaseRepository<NROther> _NROthers;


        public UnitOfWork(RELServiceEntities dbContext)
        {
            _dbContext = dbContext;

        }


       


        public IRepository<ClaimInfo> ClaimInfos
        {
            get
            {
                return _claimInfos ??
                    (_claimInfos = new BaseRepository<ClaimInfo>(_dbContext));
            }
        }

        public IRepository<Branch> Branchs
        {
            get
            {
                return _Branchs ??
                    (_Branchs = new BaseRepository<Branch>(_dbContext));
            }
        }
        public IRepository<cType> Categories
        {
            get
            {
                return _Categories ??
                    (_Categories = new BaseRepository<cType>(_dbContext));
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return _Products ??
                    (_Products = new BaseRepository<Product>(_dbContext));
            }
        }

        public IRepository<Personal> Personals
        {
            get
            {
                return _Personals ??
                    (_Personals = new BaseRepository<Personal>(_dbContext));
            }
        }


        public IRepository<Brand> Brands
        {
            get
            {
                return _Brands ??
                    (_Brands = new BaseRepository<Brand>(_dbContext));
            }
        }
        //_tblItemCaps

        public IRepository<tblItemCap> tblItemCaps
        {
            get
            {
                return _tblItemCaps ??
                    (_tblItemCaps = new BaseRepository<tblItemCap>(_dbContext));
            }
        }

        public IRepository<ClaimList> ClaimLists
        {
            get
            {
                return _ClaimLists ??
                    (_ClaimLists = new BaseRepository<ClaimList>(_dbContext));
            }
        }

        public IRepository<BrandModel> BrandModels
        {
            get
            {
                return _BrandModels ??
                    (_BrandModels = new BaseRepository<BrandModel>(_dbContext));
            }
        }


        public IRepository<ServiceItem> ServiceItems
        {
            get
            {
                return _ServiceItems ?? (_ServiceItems = new BaseRepository<ServiceItem>(_dbContext));
            }
        }
        public IRepository<CustomerClaim> CustomerClaims
        {
            get
            {
                return _CustomerClaims ??
                    (_CustomerClaims = new BaseRepository<CustomerClaim>(_dbContext));
            }
        }

        public IRepository<ServiceDetail> ServiceDetails
        {
            get
            {
                return _ServiceDetails ??
                    (_ServiceDetails = new BaseRepository<ServiceDetail>(_dbContext));
            }
        }


        public IRepository<tbBill_FFC> tbBill_FFCs
        {
            get
            {
                return _tbBill_FFCs ?? (_tbBill_FFCs = new BaseRepository<tbBill_FFC>(_dbContext));
            }
        }





        public IRepository<tbGrade> tbGrades
        {
            get
            {
                return _tbGrades ??
                    (_tbGrades = new BaseRepository<tbGrade>(_dbContext));
            }
        }


        public IRepository<CustomerClaimOther> CustomerClaimOthers
        {
            get
            {
                return _CustomerClaimOthers ??
                    (_CustomerClaimOthers = new BaseRepository<CustomerClaimOther>(_dbContext));
            }
        }


        public IRepository<Pending> Pendings
        {
            get
            {
                return _Pendings ?? (_Pendings = new BaseRepository<Pending>(_dbContext));
            }
        }

        public IRepository<PendingOther> PendingOthers
        {
            get
            {
                return _PendingOthers ?? (_PendingOthers = new BaseRepository<PendingOther>(_dbContext));
            }
        }

        public IRepository<NRDetail> NRDetails
        {
            get
            {
                return _NRDetails ??
                    (_NRDetails = new BaseRepository<NRDetail>(_dbContext));
            }
        }


        public IRepository<NROther> NROthers
        {
            get
            {
                return _NROthers ??
                    (_NROthers = new BaseRepository<NROther>(_dbContext));
            }
        }


        // Store Procedure Section



        public string GetNewIncrementID(string BranchName)
        {

            List<SqlParameter> param = new List<SqlParameter>();
            int intIncrementValue = 0;
            param.Add(new SqlParameter()
            {
                ParameterName = "@BranchName",
                Value = BranchName
            });
            param.Add(new SqlParameter()
            {
                ParameterName = "@value",
                Value = intIncrementValue,
                Direction = System.Data.ParameterDirection.Output
            });
            int maxvalue = 0;
            string output;
            try
            {

                maxvalue = Convert.ToInt32(GetScalerValue_With_Procedure("spGetIncrementValue", param.ToArray())) + 1;

            }
            catch
            {
                maxvalue = 1;
            }

            output = GenerateID(BranchName, maxvalue);

            return output;


        }


        private string GenerateID(string branchname, int id)
        {

            if (branchname.ToLower() == "Mirpur 10".ToLower())
            {
                branchname = branchname.Substring(0, 2) + "10";
            }
            else
            {
                branchname = branchname.Substring(0, 4);
            }

            branchname += branchname = DateTime.Now.Year.ToString().Substring(2, 2);

            string output = "";
            if (id < 10)
            {
                output = branchname + "-" + "000" + id;
            }
            else if (id < 100)
            {
                output = branchname + "-" + "00" + id;
            }
            else if (id < 1000)
            {
                output = branchname + "-" + "0" + id;
            }
            else
            {
                output = branchname + "-" + id;
            }

            return output;

        }


        public object GetScalerValue_With_Procedure(string procedure, SqlParameter[] param)
        {
            object obj;
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand("spGetIncrementValue", con);



                con.Open();
                cmd.Parameters.AddRange(param.ToArray());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                obj = cmd.ExecuteScalar();
            };
            return obj;


        }






        public List<ClaimListModel> GetFault_by_Category_JobCode(string category = null, string JobCode = null)
        {


            if (category == null)
            {
                category = "";
            }
            if (JobCode == null)
            {
                JobCode = "";
            }
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter()
            {
                ParameterName = "@category",
                Value = category
            });
            parm.Add(new SqlParameter()
            {
                ParameterName = "@JobCode",
                Value = JobCode
            }
           );


            List<ClaimListModel> output = new List<ClaimListModel>();
            output = _dbContext.Database.SqlQuery<ClaimListModel>("Exec spGetCustomerclaim_By_Category_JobCode @category, @JobCode", parm.ToArray()).ToList();

            return output;

        }


       public List<tblItemCapModel> GetAccessories_by_Category_JobCode(string category = null, string JobCode = null)
        {
            if (category == null)
            {
                category = "";
            }
            if (JobCode == null)
            {
                JobCode = "";
            }
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter()
            {
                ParameterName = "@category",
                Value = category
            });
            parm.Add(new SqlParameter()
            {
                ParameterName = "@JobCode",
                Value = JobCode
            }
           );


            List<tblItemCapModel> output = new List<tblItemCapModel>();
            output = _dbContext.Database.SqlQuery<tblItemCapModel>("Exec spGetAccessories_By_Category_JobCode @category, @JobCode", parm.ToArray()).ToList();

            return output;

        }

        public List<string> AutoComplete(string term, string BranchName, int? cflag)
        {

            if (cflag == null)
            {
                cflag = 0;
            }

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter()
            {
                ParameterName="@JobCode",
                Value=term
            });
            param.Add(new SqlParameter()
            {
                ParameterName = "@Branch",
                Value = BranchName
            });
            param.Add(new SqlParameter()
            {
                ParameterName = "@cflag",
                Value = cflag
            });
            List<string> output = new List<string>();
            output = _dbContext.Database.SqlQuery<string>("Exec spAutoComplete @JobCode, @Branch, @cflag", param.ToArray()).ToList();
            return output;
        }


        public ClaimInfo GetSingleClaiminfo_By_JobCode(string JobCode)
        {


            if (JobCode == null)
            {
                JobCode = "";
            }

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter()
            {
                ParameterName = "@JobCode",
                Value = JobCode
            });

            ClaimInfo output = new ClaimInfo();
            output = _dbContext.Database.SqlQuery<ClaimInfo>("Exec spGetSingleClaiminfo @JobCode", param.ToArray()).FirstOrDefault();
            return output;

        }


        public List<Pending> GetPendingList_By_JobCode(string JobCode)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = "@JobCode";
            param.Value = JobCode;
            

            List<Pending> output = new List<Pending>();
            output = _dbContext.Database.SqlQuery<Pending>("Exec spPending_By_JobCode @JobCode", param).ToList();
            return output;
        }

        public PendingOther GetPendingOther_By_JobCode(string JobCode)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = "@JobCode";
            param.Value = JobCode;


            PendingOther output = new PendingOther();
            output = _dbContext.Database.SqlQuery<PendingOther>("Exec spPendingOthers_By_JobCode @JobCode", param).FirstOrDefault();
            return output;
        }
        public List<NRDetail> GetNRList_By_JobCode(string JobCode)
        {
            List<NRDetail> output = new List<NRDetail>();
            SqlParameter param = new SqlParameter();

            param.ParameterName = "@JobCode";
            param.Value = JobCode;
            output = _dbContext.Database.SqlQuery<NRDetail>("Exec spGet_NR_By_JobCode @JobCode", param).ToList();

            return output;
        }


        public NROther GetNROther_By_JobCode(string JobCode)
        {
            NROther output = new NROther();
            SqlParameter param = new SqlParameter();

            param.ParameterName = "@JobCode";
            param.Value = JobCode;
            output = _dbContext.Database.SqlQuery<NROther>("Exec spGet_NROther_By_JobCode @JobCode", param).FirstOrDefault();

            return output;
        }

        public void Delete_NRDetails_JobCode(string JobCode)
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand("spDelete_NR_byJobCode", con);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@JobCode";
                param.Value = JobCode;


                con.Open();
                cmd.Parameters.Add(param);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            };
        }

        public void Delete_NROther_JobCode(string JobCode)
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand("spDelete_NROther_byJobCode", con);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@JobCode";
                param.Value = JobCode;


                con.Open();
                cmd.Parameters.Add(param);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            };
        }


    
        public void Delete_Pending_JobCode(string JobCode)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@JobCode";
            param.Value = JobCode;
            //using (SqlConnection con = new SqlConnection(path))
            //{
            //    SqlCommand cmd = new SqlCommand("spDelete_Pending_byJobCode", con);

             


            //    con.Open();
            //    cmd.Parameters.Add(param);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            //};

            _dbContext.Database.ExecuteSqlCommand("spDelete_PendingOther_byJobCode @JobCode", param);

        }

        public void Delete_PendingOther_JobCode(string JobCode)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@JobCode";
            param.Value = JobCode;
            //using (SqlConnection con = new SqlConnection(path))
            //{
            //    SqlCommand cmd = new SqlCommand("spDelete_PendingOther_byJobCode", con);




            //    con.Open();
            //    cmd.Parameters.Add(param);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();
            //};

            _dbContext.Database.ExecuteSqlCommand("spDelete_PendingOther_byJobCode @JobCode", param);
        }


        public List<SearchProduct> SearchProduct(string code)
        {
            List<SearchProduct> output = new List<SearchProduct>();
            output = _dbContext.Database.SqlQuery<SearchProduct>("Exec SearchProduct @Code", new SqlParameter() { ParameterName = "@Code", Value = code }).ToList();

            return output;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
