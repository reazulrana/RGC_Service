using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RGC_Service.Models.BussinessModel
{
    public class PersonalModel
    {
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public string UserName { get; set; }
        public string EmpName { get; set; }
        public string Passward { get; set; }
        public string FathersName { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<System.DateTime> DateOfJoin { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string EduQua { get; set; }
        public string MaritalStatus { get; set; }
        public string PreAdd { get; set; }
        public string PrePO { get; set; }
        public string PreDist { get; set; }
        public string PrePhone { get; set; }
        public string PerAdd { get; set; }
        public string PerPO { get; set; }
        public string PerDist { get; set; }
        public string PerPhone { get; set; }
        public Nullable<double> Amount { get; set; }
        public string Payscale { get; set; }
        public string JobType { get; set; }
        public Nullable<bool> status { get; set; }
    }
}