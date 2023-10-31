using DAL_Service.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Service.Service
{
    public interface IUnitOfWork
    {
        IRepository<ClaimInfo> ClaimInfos { get; }
        IRepository<Branch> Branchs { get; }
        IRepository<cType> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Personal> Personals { get; }
        IRepository<Brand> Brands { get; }
        IRepository<tblItemCap> tblItemCaps { get; }
        IRepository<ClaimList> ClaimLists { get; }
        IRepository<BrandModel> BrandModels { get; }
        IRepository<ServiceItem> ServiceItems { get; }
        IRepository<CustomerClaim> CustomerClaims { get; }
        IRepository<CustomerClaimOther> CustomerClaimOthers { get; }

        IRepository<ServiceDetail> ServiceDetails { get; }
        IRepository<tbBill_FFC> tbBill_FFCs { get; }
        IRepository<tbGrade> tbGrades { get; }
        IRepository<Pending> Pendings { get; }
        IRepository<PendingOther> PendingOthers { get; }

        IRepository<NRDetail> NRDetails { get; }
        IRepository<NROther> NROthers { get; }



        //Store Procedure Section
        //Call Store Procedure from Database
        List<ClaimListModel>GetFault_by_Category_JobCode(string category = null, string JobCode = null);
        List<tblItemCapModel> GetAccessories_by_Category_JobCode(string category = null, string JobCode = null);
        List<string> AutoComplete(string term, string BranchName, int? cflag);
        ClaimInfo GetSingleClaiminfo_By_JobCode(string JobCode);
        List<Pending> GetPendingList_By_JobCode(string JobCode);
        PendingOther GetPendingOther_By_JobCode(string JobCode);
        List<NRDetail> GetNRList_By_JobCode(string JobCode);
        NROther GetNROther_By_JobCode(string JobCode);
        void Delete_NRDetails_JobCode(string JobCode);
        void Delete_NROther_JobCode(string JobCode);
        void Delete_Pending_JobCode(string JobCode);
        void Delete_PendingOther_JobCode(string JobCode);
        List<SearchProduct> SearchProduct(string code);










        object GetScalerValue_With_Procedure(string procedure, SqlParameter[] param);
        string GetNewIncrementID(string BranchName);





        void Commit();
    }
}
