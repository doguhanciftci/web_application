using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Arçelik.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Arçelik.Controllers
{

    public class LoginController : Controller
    {

        public IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ValidLogin(loginModel.Username, loginModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Login");
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidLogin(string username, string password)
        {
            if (username == null || password == null)
                return false;
            bool valid = false;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Select * From Applicant Where Username = @0";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@0", username);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (password.Equals(MyConvertString(dataReader["Password"])))
                            valid = true;
                    }
                }
                connection.Close();
            }
            return valid;
        }


        public string MyConvertString(object str)
        {
            if (str.GetType().Name.CompareTo("DBNull") == 0)
                return "";
            else
                return Convert.ToString(str);
        }

        public int MyConvertInt(object str)
        {

            if (str.GetType().Name.CompareTo("DBNull") == 0)
                return -1;
            else
                return Convert.ToInt32(str);
        }

    }

}