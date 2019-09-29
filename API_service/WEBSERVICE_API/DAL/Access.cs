using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Access
    {

        public IConfiguration Configuration { get; }

        public Access(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<Applicant_History> GetAllHistory()
        {
            List<Applicant_History> ApplicantList = new List<Applicant_History>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string sql = "Select * From Applicant_History";
                string sql = "EXEC SelectAllApplicantHistory";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Applicant_History app = new Applicant_History();
                        app.H_Applicant_Id = MyConvertInt(dataReader["H_Applicant_Id"]);
                        app.Applicant_Id = MyConvertInt(dataReader["Applicant_Id"]);
                        app.H_FName = MyConvertString(dataReader["H_FName"]);
                        app.H_LName = MyConvertString(dataReader["H_LName"]);
                        app.H_Username = MyConvertString(dataReader["H_Username"]);
                        app.H_Password = MyConvertString(dataReader["H_Password"]);
                        app.H_Age = MyConvertInt(dataReader["H_Age"]);
                        app.H_Phone = MyConvertString(dataReader["H_Phone"]);
                        app.H_Extra = MyConvertString(dataReader["H_Extra"]);
                        app.H_ModificationDate = Convert.ToDateTime(dataReader["H_ModificationDate"]);
                        ApplicantList.Add(app);
                    }
                }
                connection.Close();
            }
            return ApplicantList;
        }

        public IEnumerable<Applicant_History> GetHistory(int id)
        {

            List<Applicant_History> ApplicantList = new List<Applicant_History>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string sql = $"Select * From Applicant_History Where Applicant_Id = '{id}'";
                string sql = $"EXEC SelectApplicantHistoryWithId @Applicant_Id = '{id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Applicant_History app = new Applicant_History();
                        app.H_Applicant_Id = MyConvertInt(dataReader["H_Applicant_Id"]);
                        app.Applicant_Id = MyConvertInt(dataReader["Applicant_Id"]);
                        app.H_FName = MyConvertString(dataReader["H_FName"]);
                        app.H_LName = MyConvertString(dataReader["H_LName"]);
                        app.H_Username = MyConvertString(dataReader["H_Username"]);
                        app.H_Password = MyConvertString(dataReader["H_Password"]);
                        app.H_Age = MyConvertInt(dataReader["H_Age"]);
                        app.H_Phone = MyConvertString(dataReader["H_Phone"]);
                        app.H_Extra = MyConvertString(dataReader["H_Extra"]);
                        app.H_ModificationDate = Convert.ToDateTime(dataReader["H_ModificationDate"]);
                        ApplicantList.Add(app);
                    }
                }
                connection.Close();
            }
            return ApplicantList;
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