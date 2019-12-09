using Employee_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;
using System;
using System.IO;
using System.Text;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;

namespace Employee_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        public string Employees(int Cmp,int Emp,string filelocation,string filename)
        {
            
                Employee emp = new Employee();
                string[] empName = { "Raghu Sharma",
                                  "Shyam tomar",
                                  "Mohan thakare",
                                  "Ramesh chaudhary",
                                  "Anand Goyal",
                                   "Ankit Patel"};
                emp.CompanyId = 4356;

                string[] cmpName = { "Wipro",
                                  "Bizruntime",
                                  "Infosys",
                                  "IBM",
                                  "Accenture"};
                StringBuilder csvcontent = new StringBuilder();
           
                csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                int empId = 35246;
                for (int j = 1; j <= Cmp; j++)
                {
                    for (int i = 1; i < Emp; i++)
                    {
                        if (i % 2 == 0)
                        {
                            csvcontent.AppendLine(++empId + "," + empName[0] + "," + Designation.Webdeveloper + "," + Department.AccountsandFinance + "," + emp.CompanyId + "," + cmpName[0]);
                        }
                        else if (i % 3 == 0)
                        {
                            csvcontent.AppendLine(++empId + "," + empName[1] + "," + Designation.Networkengineer + "," + Department.HR + "," + emp.CompanyId + "," + cmpName[1]);
                        }
                        else if (i % 4 == 0)
                        {
                            csvcontent.AppendLine(++empId + "," + empName[2] + "," + Designation.Softwareengineer + "," + Department.Salesandmarketing + " ," + emp.CompanyId + "," + cmpName[2]);
                        }
                        else if (i % 5 == 0)
                        {
                            csvcontent.AppendLine(++empId + "," + empName[3] + "," + Designation.Businessanalyst + "," + Department.Infrastructures + "," + emp.CompanyId + "," + cmpName[3]);
                        }
                        else if (i % 5 == 0)
                        {
                            csvcontent.AppendLine(++empId + "," + empName[4] + "," + Designation.Systemsanalyst + "," + Department.Researchanddevelopment + "," + emp.CompanyId + "," + cmpName[4]);
                        }
                        else
                        {
                            csvcontent.AppendLine(++empId + "," + empName[5] + "," + Designation.Technicalsupport + "," + Department.IT + "," + emp.CompanyId + "," + cmpName[0]);
                        }
                    }
                    emp.CompanyId++;

                }
                string csvPath = filelocation+"\\"+filename+".csv";

                System.IO.File.AppendAllText(csvPath, csvcontent.ToString());

               var obj1 = new JObject();
            obj1["Response"] = "File created successfully";
            obj1["methodType"] = "Get";
            return obj1.ToString();
        }

        public List<string> BasedOnSelection(string filelocation, string filename)
        {

            List<string> list1 = new List<string>();
            Employee emp = new Employee();
            string[] empName = { "Raghu Sharma",
                                  "Shyam tomar",
                                  "Mohan thakare",
                                  "Ramesh chaudhary",
                                  "Anand Goyal",
                                   "Ankit Patel"};

            string[] CompanyName = { "Wipro",
                                  "Bizruntime",
                                  "Infosys",
                                  "IBM",
                                  "Accenture",
                                    "Amazon"};

            
            emp.empId = 35246;
            int[] CompanyId = { 4254,5697,8547,2548,9874,3659 };
            if (filename == "empName")
            { 
                for (int j = 0; j <empName.Length; j++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                    if (empName[j] == "Raghu Sharma" || empName[j] == "Shyam tomar" || empName[j] == "Mohan thakare" || empName[j] == "Ramesh chaudhary" || empName[j] == "Anand Goyal" || empName[j] == "Ankit Patel")
                    {
                          if (j % 2 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Webdeveloper + "," + Department.AccountsandFinance + "," + CompanyId[0] + "," + CompanyName[0]);
                            }
                             if (j % 3 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Networkengineer + "," + Department.HR + "," + CompanyId[1] + "," + CompanyName[1]);
                            }
                             if (j % 4 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Softwareengineer + "," + Department.Salesandmarketing + " ," + CompanyId[3] + "," + CompanyName[3]);
                            }
                             if (j % 5 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Businessanalyst + "," + Department.Infrastructures + "," + CompanyId[4] + "," + CompanyName[4]);
                            }
                             if (j % 6 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Systemsanalyst + "," + Department.Researchanddevelopment + "," +CompanyId[2] + "," + CompanyName[2]);
                            }
                            else
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[j] + "," + Designation.Technicalsupport + "," + Department.IT + "," + CompanyId[5] + "," + CompanyName[5]);
                            }
                        string csvPath = filelocation + "\\" + empName[j] + ".csv";
                            System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                            list1.Add(empName[j] + ".csv");
                         
                        }
                    
                }
                    
                }

            else if (filename == "CompanyName")
            {
                for (int j = 0; j < CompanyName.Length; j++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                    if (CompanyName[j] == "Wipro" || CompanyName[j] == "Bizruntime" || CompanyName[j] == "Infosys" || CompanyName[j] == "IBM" || CompanyName[j] == "Accenture" || CompanyName[j] == "Amazon")
                    {
                        if (j % 2 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[1] + "," + Designation.Webdeveloper + "," + Department.AccountsandFinance + "," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        if (j % 3 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[0] + "," + Designation.Networkengineer + "," + Department.HR + "," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        if (j % 4 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[4] + "," + Designation.Softwareengineer + "," + Department.Salesandmarketing + " ," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        if (j % 5 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[3] + "," + Designation.Businessanalyst + "," + Department.Infrastructures + "," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        if (j % 6 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[2] + "," + Designation.Systemsanalyst + "," + Department.Researchanddevelopment + "," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        else
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[5] + "," + Designation.Technicalsupport + "," + Department.IT + "," + CompanyId[j] + "," + CompanyName[j]);
                        }
                        string csvPath = filelocation + "\\" + CompanyName[j] + ".csv";
                        System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                        list1.Add(CompanyName[j] + ".csv");

                    }

                }


            }
            else if (filename == "Designation")
            {
                
                for (int k = 0; k < Enum.GetValues(typeof(Designation)).Length; k++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");

                    if (Enum.GetName(typeof(Designation), k) == "Webdeveloper" || Enum.GetName(typeof(Designation), k) == "Networkengineer" || Enum.GetName(typeof(Designation), k) == "Softwareengineer" || Enum.GetName(typeof(Designation), k) == "Businessanalyst" || Enum.GetName(typeof(Designation), k) == "Systemsanalyst" || Enum.GetName(typeof(Designation), k) == "Technicalsupport")
                    { 
                          if (k % 2 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[0] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.AccountsandFinance + "," + CompanyId[0] + "," + CompanyName[0]);
                            }
                             if (k % 3 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[1] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.HR + "," + CompanyId[1] + "," + CompanyName[1]);
                            }
                             if (k % 4 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[2] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.Salesandmarketing + " ," + CompanyId[2] + "," + CompanyName[2]);
                            }
                             if (k % 5 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[3] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.Infrastructures + "," + CompanyId[3] + "," + CompanyName[3]);
                            }
                             if (k % 5 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[4] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.Researchanddevelopment + "," + CompanyId[4] + "," + CompanyName[4]);
                            }
                            else
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[5] + "," + Enum.GetName(typeof(Designation), k) + "," + Department.IT + "," + CompanyId[5] + "," + CompanyName[5]);
                            }

                        string csvPath = filelocation + "\\" + Enum.GetName(typeof(Designation), k) + ".csv";
                        System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                        list1.Add(Enum.GetName(typeof(Designation), k) + ".csv");
                    }
                    
                    

                }
                
            }

            else if (filename == "Department")
            {

                for (int k = 0; k < Enum.GetValues(typeof(Department)).Length; k++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                    if (Enum.GetName(typeof(Department), k) == "AccountsandFinance" || Enum.GetName(typeof(Department), k) == "HR" || Enum.GetName(typeof(Department), k) == "Salesandmarketing" || Enum.GetName(typeof(Department), k) == "Infrastructures" || Enum.GetName(typeof(Department), k) == "Researchanddevelopment" || Enum.GetName(typeof(Department), k) == "IT")
                    {


                        if (k % 2 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[0] + "," + Designation.Webdeveloper + "," + Enum.GetName(typeof(Department), k) + "," + CompanyId[0] + "," + CompanyName[0]);
                        }
                         if (k % 3 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[1] + "," + Designation.Networkengineer + "," + Enum.GetName(typeof(Department), k) + "," + CompanyId[1] + "," + CompanyName[1]);
                        }
                         if (k % 4 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[2] + "," + Designation.Softwareengineer + "," + Enum.GetName(typeof(Department), k) + " ," + CompanyId[2] + "," + CompanyName[2]);
                        }
                         if (k % 5 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[3] + "," + Designation.Businessanalyst + "," + Enum.GetName(typeof(Department), k) + "," + CompanyId[3] + "," + CompanyName[3]);
                        }
                         if (k % 5 == 0)
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[4] + "," + Designation.Systemsanalyst + "," + Enum.GetName(typeof(Department), k) + "," + CompanyId[4] + "," + CompanyName[4]);
                        }
                        else
                        {
                            csvcontent.AppendLine(++emp.empId + "," + empName[5] + "," + Designation.Technicalsupport + "," + Enum.GetName(typeof(Department), k) + "," + CompanyId[5] + "," + CompanyName[5]);
                        }

                        string csvPath = filelocation + "\\" + Enum.GetName(typeof(Department), k) + ".csv";
                        System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                        list1.Add(Enum.GetName(typeof(Department), k) + ".csv");

                    }
                  
                }
           
          }
      
            else if (filename == "CompanyId")
            {
                for (int k = 0; k < CompanyName.Length; k++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                    if (CompanyId[0] == 4254 || CompanyId[0] == 5697 || CompanyId[0] == 8547 || CompanyId[0] == 2548 || CompanyId[0] == 9874 || CompanyId[0] == 3659)
                    {
                        
                            if (k % 2 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[0] + "," + Designation.Webdeveloper + "," + Department.AccountsandFinance + "," + CompanyId[k] + "," + CompanyName[k]);
                            }
                             if (k % 3 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[1] + "," + Designation.Networkengineer + "," + Department.HR + "," + CompanyId[k] + "," + CompanyName[k]);
                            }
                             if (k % 4 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[2] + "," + Designation.Softwareengineer + "," + Department.Salesandmarketing + " ," +CompanyId[k] + "," + CompanyName[k]);
                            }
                             if (k % 5 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[3] + "," + Designation.Businessanalyst + "," + Department.Infrastructures + "," + CompanyId[k] + "," + CompanyName[k]);
                            }
                             if (k % 5 == 0)
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[4] + "," + Designation.Systemsanalyst + "," + Department.Researchanddevelopment + "," + CompanyId[k] + "," + CompanyName[k]);
                            }
                            else
                            {
                                csvcontent.AppendLine(++emp.empId + "," + empName[5] + "," + Designation.Technicalsupport + "," + Department.IT + "," + CompanyId[k] + "," + CompanyName[k]);
                            }
                        string csvPath = filelocation + "\\" + CompanyId[k] + ".csv";
                        System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                        list1.Add(CompanyId[k] + ".csv");
                        emp.CompanyId++;
                    }
                    
                }
                
            }

            else if (filename == "empId")
            {
                emp.empId = 35246;
                for (int k = 0; k < empName.Length; k++)
                {
                    StringBuilder csvcontent = new StringBuilder();
                    csvcontent.AppendLine("EmpId,EmpName,Designation ,DepartMent,CompanyId,CompanyName");
                    if (emp.empId == emp.empId)
                    {

                        if (k % 2 == 0)
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Webdeveloper + "," + Department.AccountsandFinance + "," + CompanyId[k] + "," + CompanyName[k]);
                            
                        }
                         if (k % 3 == 0)
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Networkengineer + "," + Department.HR + "," + CompanyId[k] + "," + CompanyName[k]);
                        }
                         if (k % 4 == 0)
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Softwareengineer + "," + Department.Salesandmarketing + " ," + CompanyId[k] + "," + CompanyName[k]);
                            
                        }
                         if (k % 5 == 0)
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Businessanalyst + "," + Department.Infrastructures + "," + CompanyId[k] + "," + CompanyName[k]);
                        }
                         if (k % 6 == 0)
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Systemsanalyst + "," + Department.Researchanddevelopment + "," + CompanyId[k] + "," + CompanyName[k]);
                        }
                        else
                        {
                            csvcontent.AppendLine(emp.empId + "," + empName[k] + "," + Designation.Technicalsupport + "," + Department.IT + "," + CompanyId[k] + "," + CompanyName[k]);
                        }
                        string csvPath = filelocation + "\\" + emp.empId + ".csv";
                        System.IO.File.AppendAllText(csvPath, csvcontent.ToString());
                        list1.Add(emp.empId + ".csv");
                        emp.empId++;

                    }

                }
                
            }
            return list1;
        }


        [Route("get")]
        [HttpGet]
        public string Get(int Cmp,int Emp,string filelocation,string filename)
        {
            return Employees(Cmp, Emp,filelocation,filename);
        }

        [Route("post")]
        [HttpPost]
        public List<string> Post(string filelocation, string filename)
        {
            return BasedOnSelection(filelocation, filename);
        }

        [Route("postformdata")]
        [HttpPost]
        public List<byte[]> postformdata( string fileName,string filelocation)
        {
            List<byte[]> list = new List<byte[]>();
            try
            {
                string[] array = fileName.Split(",");
                for (int i = 0; i < array.Length; i++)
                {
                    var currentDirectory = filelocation;
                    var file = Path.Combine(Path.Combine(currentDirectory), array[i]);
                    var result = new FileStream(file, FileMode.Open, FileAccess.Read);
                    list.Add(ReadFully(result));

                }
            }
            catch(Exception e)
            {

            }
  
            return list;


        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}