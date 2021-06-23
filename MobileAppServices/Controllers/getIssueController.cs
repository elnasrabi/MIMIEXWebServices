using MobileAppServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MobileAppServices.Controllers
{
    public class getIssueController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<issue> oneform = new List<issue>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ImForms.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}



       // [Route("api/Issue/{issueno}/{loginname}")]
        public async Task<IHttpActionResult> Get(long issueno, string loginname)
        {
            MIMEXEntities dc = new MIMEXEntities();

            var issue = dc.vIssue.Where(a => a.LoginName == loginname && a.Id == issueno).OrderByDescending(a=> a.IssueDate);
            if (issue.Count() == 0)
            {
                return NotFound();
            }

            return Ok(issue);
        }



       
        public async Task<IHttpActionResult> Get(string loginname)
        {
            MIMEXEntities dc = new MIMEXEntities();

            var issue = dc.vIssue.Where(a => a.LoginName == loginname).OrderByDescending(a => a.IssueDate); ;
            if (issue.Count() == 0)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        public async Task<IHttpActionResult> GetHelp(string isbank)
        {
            MIMEXEntities dc = new MIMEXEntities();

            int UsrClass = 0;

            if(isbank.Trim()=="Bank")
            {
                UsrClass = 2;
            }
            else
            {
                UsrClass = 1;
            }

            var result = (from a in dc.HelpAnswers
                          where a.UserType== UsrClass
                          select new HelpDTO { Question = a.Question, Answer = a.Answer}).ToList();


            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }



    }


}
