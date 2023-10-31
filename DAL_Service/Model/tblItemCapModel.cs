using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Service.Model
{
    public class tblItemCapModel
    {
        public int ItemCode { get; set; }
        public string cType { get; set; }
        public string cItem { get; set; }
        public bool IsSelected { get; set; }

    }
}
