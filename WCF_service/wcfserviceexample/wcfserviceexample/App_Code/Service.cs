using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public List<Applicant_History> SelectAllHistory()
    {
        List<Applicant_History> ApplicantList = new List<Applicant_History>();
        using (SqlConnection connection = new SqlConnection("Data Source=A00101996\\SQLEXPRESS;Initial Catalog=Applicant;Integrated Security=True"))
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

    public List<Applicant_History> SelectHistoryWithId(int id)
    {

        List<Applicant_History> ApplicantList = new List<Applicant_History>();
        using (SqlConnection connection = new SqlConnection("Data Source=A00101996\\SQLEXPRESS;Initial Catalog=Applicant;Integrated Security=True"))
        {
            connection.Open();
            string sql = "EXEC SelectApplicantHistoryWithId @Applicant_Id = " + id;
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
