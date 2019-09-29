using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    // TODO: Add your service operations here


    [OperationContract]
    List<Applicant_History> SelectAllHistory();

    [OperationContract]
    List<Applicant_History> SelectHistoryWithId(int id);
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

[DataContract]
public class Applicant_History
{
    [DataMember]
    public int H_Applicant_Id { get; set; }

    [DataMember]
    public int Applicant_Id { get; set; }

    [DataMember]
    public string H_FName { get; set; }

    [DataMember]
    public string H_LName { get; set; }

    [DataMember]
    public string H_Username { get; set; }

    [DataMember]
    public string H_Password { get; set; }

    [DataMember]
    public int H_Age { get; set; }

    [DataMember]
    public string H_Phone { get; set; }

    [DataMember]
    public string H_Extra { get; set; }

    [DataMember]
    public DateTime H_ModificationDate { get; set; }

}
