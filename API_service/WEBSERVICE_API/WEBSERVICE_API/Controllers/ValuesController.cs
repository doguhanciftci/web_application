using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DAL;
using WEBSERVICE_API.Models;

namespace WEBSERVICE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public Access DataAccess;

        public ValuesController(IConfiguration configuration)
        {
            DataAccess = new Access(configuration);
        }

        [HttpGet]
        public IEnumerable<Applicant_History> Get()
        {
            return DataAccess.GetAllHistory().Select(x => new Applicant_History
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

        [HttpGet("{id}")]
        public IEnumerable<Applicant_History> Get(int id)
        {
            return DataAccess.GetHistory(id).Select(x => new Applicant_History
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


        /*

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
