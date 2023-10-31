using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Service.Model
{
   public class ClaimListModel
    {
        public int ClaimCode { get; set; }
        public string cType { get; set; }
        public string Claim { get; set; }
        public bool IsSelected{ get; set; }


    }
}
