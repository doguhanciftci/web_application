using DAL.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ApplyRepository
    {

        public IConfiguration Configuration { get; }

        public string connectionString;

        ServiceReference1.ServiceClient wcf;

        DAL.ServiceConnector.ApiClient api;

        public ApplyRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            //WCF SERVICE
            wcf = new ServiceReference1.ServiceClient();

            //WEB API
            api = new DAL.ServiceConnector.ApiClient();
        }

        public List<DAL_Applicant_History> GetAllHistoryWCF()
        {
            List<DAL_Applicant_History> histList;
            try
            {
                var hist = wcf.SelectAllHistory();
                histList = hist.Select(x => new DAL_Applicant_History
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
                }).ToList();
            }
            catch (Exception ex)
            {
                histList = new List<DAL_Applicant_History>();
                var msg = ex.Message;
            }
            return histList;
        }

        public List<DAL_Applicant_History> GetAllHistoryAPI()
        {
            string json = api.GetMethod<string>("https://localhost:44399/api/values");
            return JsonConvert.DeserializeObject<List<DAL_Applicant_History>>(json);
        }

        public List<DAL_MyApplication> GetAllMyApplication(String CurrentUser)
        {
            List<DAL_MyApplication> DAL_MyAppList = new List<DAL_MyApplication>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"Select * From Apply " +
                    $"JOIN Department on Apply.Department_Id = Department.Department_Id " +
                    $"JOIN Location on Department.Location_Id = Location.Location_Id " +
                    $"Where Applicant_Id = (Select Applicant_Id From Applicant Where Username = @0)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@0", CurrentUser);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DAL_MyApplication DAL_MyApp = new DAL_MyApplication();
                        DAL_MyApp.Apply_Id = MyConvertInt(dataReader["Apply_Id"]);
                        DAL_MyApp.Department_Name = MyConvertString(dataReader["Department_Name"]);
                        DAL_MyApp.Location_Name = MyConvertString(dataReader["Location_Name"]);
                        DAL_MyApp.Company_Name = MyConvertString(dataReader["Company_Name"]);
                        DAL_MyApp.Address = MyConvertString(dataReader["Address"]);
                        DAL_MyApp.Application_Date = Convert.ToDateTime(dataReader["ApplyDate"]);
                        DAL_MyAppList.Add(DAL_MyApp);
                    }
                }
                connection.Close();
            }
            return DAL_MyAppList;
        }

        public List<DAL_Applicant> GetAllApplicant()
        {
            List<DAL_Applicant> DAL_ApplicantList = new List<DAL_Applicant>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Applicant";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DAL_Applicant DAL_app = new DAL_Applicant();
                        DAL_app.Id = MyConvertInt(dataReader["Applicant_Id"]);
                        DAL_app.Fname = MyConvertString(dataReader["FName"]);
                        DAL_app.Lname = MyConvertString(dataReader["LName"]);
                        DAL_app.Username = MyConvertString(dataReader["Username"]);
                        DAL_app.Password = MyConvertString(dataReader["Password"]);
                        DAL_app.Age = MyConvertInt(dataReader["Age"]);
                        DAL_app.Phone = MyConvertString(dataReader["Phone"]);
                        DAL_app.ExtraInfo = MyConvertString(dataReader["Extra"]);
                        DAL_app.AddedOn = Convert.ToDateTime(dataReader["ApplyDate"]);
                        DAL_ApplicantList.Add(DAL_app);
                    }
                }
                connection.Close();
            }
            return DAL_ApplicantList;
        }

        public List<DAL_Offer> GetAllOffer()
        {
            List<DAL_Offer> DAL_OfferList = new List<DAL_Offer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Department Join Location On Department.Location_Id = Location.Location_Id";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        DAL_Offer off = new DAL_Offer();
                        off.Department_Id = MyConvertInt(dataReader["Department_Id"]);
                        off.Department_Name = MyConvertString(dataReader["Department_Name"]);
                        off.Location_Id = MyConvertInt(dataReader["Location_Id"]);
                        off.Location_Name = MyConvertString(dataReader["Location_Name"]);
                        off.Company_Name = MyConvertString(dataReader["Company_Name"]);
                        off.Address = MyConvertString(dataReader["Address"]);
                        DAL_OfferList.Add(off);
                    }
                }
                connection.Close();
            }

            return DAL_OfferList;
        }

        public void InsertIntoApply(string username, int department_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Insert Into Apply  (Applicant_Id, Department_Id) Values ( (Select Applicant_Id From Applicant Where username = @0), @1)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@0", username);
                    command.Parameters.AddWithValue("@1", department_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void InsertIntoApplicant(string fname, string lname, string username, string password, int age, string phone, string extra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Insert Into Applicant (FName, LName, Username, Password, Age, Phone, Extra) Values (@0, @1, @2, @3, @4, @5, @6)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@0", fname);
                    command.Parameters.AddWithValue("@1", lname);
                    command.Parameters.AddWithValue("@2", username);
                    command.Parameters.AddWithValue("@3", password);
                    command.Parameters.AddWithValue("@4", age);
                    command.Parameters.AddWithValue("@5", phone);
                    command.Parameters.AddWithValue("@6", extra);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
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

        public DAL_Applicant SelectFromApplicant(string username)
        {
            DAL_Applicant DAL_app = new DAL_Applicant();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "Select * From Applicant Where Username = @0";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@0", username);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            DAL_app.Id = MyConvertInt(dataReader["Applicant_Id"]);
                            DAL_app.Fname = MyConvertString(dataReader["FName"]);
                            DAL_app.Lname = MyConvertString(dataReader["LName"]);
                            DAL_app.Username = MyConvertString(dataReader["Username"]);
                            DAL_app.Password = MyConvertString(dataReader["Password"]);
                            DAL_app.Age = MyConvertInt(dataReader["Age"]);
                            DAL_app.Phone = MyConvertString(dataReader["Phone"]);
                            DAL_app.ExtraInfo = MyConvertString(dataReader["Extra"]);
                            DAL_app.AddedOn = Convert.ToDateTime(dataReader["ApplyDate"]);
                        }
                    }
                }
                connection.Close();
            }
            return DAL_app;
        }

    }
}
