using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebApi.Models
{
    public enum Designation
    {
        Webdeveloper,
        Networkengineer,
        Softwareengineer,
        Businessanalyst,
        Systemsanalyst,
        Technicalsupport

    }

    public enum Department
    {
        AccountsandFinance,
        HR,
        Salesandmarketing,
        Infrastructures,
        Researchanddevelopment,
        IT

    }
    public class Employee
    {
        public int  CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int empId { get; set; }
        public string empName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

    }
}
