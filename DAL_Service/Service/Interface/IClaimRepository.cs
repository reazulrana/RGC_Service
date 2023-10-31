using DAL_Service.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity; 

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Service.Service
{
    interface IClaimRepository
    {
        IEnumerable<ClaimInfo> GetClaimInfos();
        ClaimInfo GetClaimInfoByID(int claimId);
        void InsertClaimInfo(ClaimInfo claim);
        void DeleteClaimInfo(int claimId);
        void UpdateClaimInfo(ClaimInfo claim);
        void Save();
    }
}
