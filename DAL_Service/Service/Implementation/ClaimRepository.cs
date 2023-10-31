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
    public class ClaimRepository : IClaimRepository
    {
        private RELServiceEntities context;

        public ClaimRepository(RELServiceEntities context)
        {
            this.context = context;
        }

        public IEnumerable<ClaimInfo> GetClaimInfos()
        {
            return context.ClaimInfoes.ToList();
        }
        public ClaimInfo GetClaimInfoByID(int ClaimInfoId)
        {
            return context.ClaimInfoes.Find(ClaimInfoId);
        }

        public void InsertClaimInfo(ClaimInfo ClaimInfo)
        {
            context.ClaimInfoes.Add(ClaimInfo);
        }

        public void DeleteClaimInfo(int ClaimInfoId)
        {
            ClaimInfo ClaimInfo = context.ClaimInfoes.Find(ClaimInfoId);
            context.ClaimInfoes.Remove(ClaimInfo);
        }

        public void UpdateClaimInfo(ClaimInfo ClaimInfo)
        {
            context.Entry(ClaimInfo).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
