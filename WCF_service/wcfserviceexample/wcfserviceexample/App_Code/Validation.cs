using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for Validation
/// </summary>


public class Validation : UserNamePasswordValidator
{

    public override void Validate(string userName, string password)
    {
        if (userName == null || password == null)
        {
            throw new ArgumentNullException();
        }

        if (!(userName == "u1" && password == "p1") && !(userName == "u2" && password == "p2"))
        {
            throw new FaultException("Unknown Username or Incorrect Password");
        }
    }
}
