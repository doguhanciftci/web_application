using Arçelik.Models;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace Arçelik.Controllers
{
    public class HomeController : Controller
    {

        public IConfiguration Configuration { get; }

        public ApplyRepository applyRepository;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;

            //DATA ACCESS LAYER
            applyRepository = new ApplyRepository(configuration);
        }

        public IActionResult Index()
        {
            List<Applicant> ApplicantList = new List<Applicant>();

            ApplicantList = applyRepository.GetAllApplicant().Select(x => new Applicant
            {
                Id = x.Id,
                Fname = x.Fname,
                Lname = x.Lname,
                LoginModel = new LoginModel(x.Username, x.Password),
                Age = x.Age,
                Phone = x.Phone,
                ExtraInfo = x.ExtraInfo,
                AddedOn = x.AddedOn
            }).ToList();

            return View(ApplicantList);
        }

        [Authorize]
        public IActionResult WCF()
        {
            return View(applyRepository.GetAllHistoryWCF().Select(x => new Applicant_History
            {
                H_Applicant_Id = x.H_Applicant_Id,
                Applicant_Id = x.Applicant_Id,
                H_FName = x.H_FName,
                H_LName = x.H_LName,
                H_Username = x.H_Username,
                H_Password = x.H_Password,
                H_Age = x.H_Age,
                H_Phone = x.H_Phone,
                H_Extra = x.H_Extra,
                H_ModificationDate = x.H_ModificationDate
            }).ToList());
        }

        [Authorize]
        public IActionResult API()
        {
            return View(applyRepository.GetAllHistoryAPI().Select(x => new Applicant_History
            {
                H_Applicant_Id = x.H_Applicant_Id,
                Applicant_Id = x.Applicant_Id,
                H_FName = x.H_FName,
                H_LName = x.H_LName,
                H_Username = x.H_Username,
                H_Password = x.H_Password,
                H_Age = x.H_Age,
                H_Phone = x.H_Phone,
                H_Extra = x.H_Extra,
                H_ModificationDate = x.H_ModificationDate
            }).ToList());
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult List()
        {
            List<MyApplication> MyAppList = new List<MyApplication>();

            MyAppList = applyRepository.GetAllMyApplication(CurrentUser()).Select(x => new MyApplication
            {
                Apply_Id = x.Apply_Id,
                Department_Name = x.Department_Name,
                Location_Name = x.Location_Name,
                Company_Name = x.Company_Name,
                Application_Date = x.Application_Date,
                Address = x.Address
            }).ToList();

            return View(MyAppList);
        }

        [Authorize]
        public IActionResult Apply2()
        {
            List<Offer> OfferList = new List<Offer>();

            OfferList = applyRepository.GetAllOffer().Select(x => new Offer
            {
                Department_Id = x.Department_Id,
                Department_Name = x.Department_Name,
                Location_Id = x.Location_Id,
                Location_Name = x.Location_Name,
                Company_Name = x.Company_Name,
                Address = x.Address
            }).ToList();

            return View(OfferList);
        }

        [HttpPost]
        [ActionName("Apply2")]
        public IActionResult Apply2(int id)
        {
            applyRepository.InsertIntoApply(CurrentUser(), id);
            return RedirectToAction("Apply2");
        }

        public string CurrentUser()
        {
            return User.Claims.Where(c => c.Type == ClaimTypes.Name)
               .Select(c => c.Value).SingleOrDefault();
        }

        public IActionResult SignUp()
        {
            return View(new Applicant());
        }

        [HttpPost]
        [ActionName("SignUp")]
        public IActionResult SignUp_Post(Applicant app)
        {
            applyRepository.InsertIntoApplicant(app.Fname, app.Lname, app.LoginModel.Username, app.LoginModel.Password, app.Age, app.Phone, app.ExtraInfo);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var CurrentUser = User.Claims.Where(c => c.Type == ClaimTypes.Name)
               .Select(c => c.Value).SingleOrDefault();
            if (CurrentUser == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                Applicant app = new Applicant();
                bool InvalidUser = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Select * From Applicant Where Username='{CurrentUser}'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (!dataReader.HasRows)
                        {
                            InvalidUser = true;
                        }
                        while (dataReader.Read())
                        {
                            app.Id = MyConvertInt(dataReader["Applicant_Id"]);
                            app.Fname = MyConvertString(dataReader["FName"]);
                            app.Lname = MyConvertString(dataReader["LName"]);
                            app.LoginModel.Username = MyConvertString(dataReader["Username"]);
                            app.LoginModel.Password = MyConvertString(dataReader["Password"]);
                            app.Age = MyConvertInt(dataReader["Age"]);
                            app.Phone = MyConvertString(dataReader["Phone"]);
                            app.ExtraInfo = MyConvertString(dataReader["Extra"]);
                            app.AddedOn = Convert.ToDateTime(dataReader["ApplyDate"]);
                        }
                    }
                    connection.Close();
                }
                if (InvalidUser)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    return View(app);
                }
            }
        }

        [HttpPost]
        [ActionName("Profile")]
        public IActionResult Profile_Update_Post(Applicant app, string cmd)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            if (cmd.Equals("Update"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Update Applicant Set " +
                        $"FName='{app.Fname}', LName='{app.Lname}', " +
                        $"Username='{app.LoginModel.Username}', Password='{app.LoginModel.Password}', " +
                        $"Age='{app.Age}', Phone='{app.Phone}', Extra='{app.ExtraInfo}' " +
                        $"Where Applicant_Id='{app.Id}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else if (cmd.Equals("Delete"))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Delete From Apply Where Applicant_Id='{app.Id}' Delete From Applicant Where Applicant_Id='{app.Id}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            ViewBag.Result = ex.Message;
                        }
                        connection.Close();
                    }
                }
                return RedirectToAction("LogOut", "Login");
            }
            return RedirectToAction("Index", "Home");
        }

        public int MyConvertInt(object str)
        {

            if (str.GetType().Name.CompareTo("DBNull") == 0)
                return -1;
            else
                return Convert.ToInt32(str);
        }

        public string MyConvertString(object str)
        {
            if (str.GetType().Name.CompareTo("DBNull") == 0)
                return "";
            else
                return Convert.ToString(str);
        }
    }

}
