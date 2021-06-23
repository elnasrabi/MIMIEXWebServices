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
    public class IssueController : ApiController
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


        int? userorg = 0;
        int? userbranch = 0;
        public int GetUserType(string loginname, string password)
        {
            int usertype = 1; //bank

            MIMEXEntities dc = new MIMEXEntities();


            var result = (from a in dc.IMEXUser
                          where a.LoginName == loginname && a.Password == password
                          select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList();


            if (result.First().UserType == "Trader")
            {
                usertype = 1;

            }
            else if (result.First().UserType == "Bank")
            {
                usertype = 2;

                var bankuser = dc.vIMEXUser.Where(a => a.LoginName == loginname && a.Password == password);

                userorg = bankuser.First().OrgCode;
                userbranch = bankuser.First().BranchCode;

            }
            else
            {
                usertype = 3;
            }

            return usertype;
        }

        public async Task<IHttpActionResult> Get(long issueno, string loginname,string password)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var issue = dc.vIssue.Where(a => a.LoginName == loginname && a.Id == issueno);
                if (issue.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(issue);

            }
            else
            {
                var issue = dc.vIssue.Where(a => a.BankBranch == userbranch && a.Bank == userorg || a.BranchEX == userbranch && a.BankEX == userorg && a.Id == issueno);
                if (issue.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(issue);

            }

           
        }



        public async Task<IHttpActionResult> Get(string loginname,string password)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var issue = dc.vIssue.Where(a => a.LoginName == loginname);
                if (issue.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(issue);

            }
            else
            {
                var issue = dc.vIssue.Where(a => a.BankBranch == userbranch && a.Bank == userorg || a.BranchEX == userbranch && a.BankEX == userorg);
                if (issue.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(issue);

            }



           
        }


        [Route("api/Issue/DeleteIssue/")]
        [HttpPost]
        public IHttpActionResult DeleteIssue(long Issuecode)
        {


            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spDeleteIssue") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@IssueCode", Issuecode));


            try
            {
                locConn.Open();
                cmd.ExecuteNonQuery();
                return StatusCode(HttpStatusCode.OK);


            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }



            locConn.Close();

        }


        [HttpPost]
   
        public async Task<IHttpActionResult> NewIssue(string LoginName, long FormNo,string Type,int IssueObject,string IssueDesc)
        {
           
            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spNewIssue") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@Type", Type));
            cmd.Parameters.Add(new SqlParameter("@IssueObject", IssueObject));
            cmd.Parameters.Add(new SqlParameter("@FormNo", FormNo));
            cmd.Parameters.Add(new SqlParameter("@LoginName", LoginName));
            cmd.Parameters.Add(new SqlParameter("@IssueDesc", IssueDesc));
            try
            {
                locConn.Open();
                cmd.ExecuteNonQuery();
                return StatusCode(HttpStatusCode.OK);
               

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }
         

          
            locConn.Close();

        }

        public SqlConnection getConnection()
        {

            const string serverName = "AFS-SQL01-DEV\\AFS_SQL01_DEV";
            const string dbName = "MIMEX";
            SqlConnection conn = null;
           conn = new SqlConnection("Server = tcp:mimex.database.windows.net,1433; Initial Catalog = MIMEX; Persist Security Info = False; User ID = mimex; Password = Mangooli@25; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ; MultipleActiveResultSets = True");
            //   conn.Open();
            return conn;




            //   SqlConnection con = new SqlConnection("Data Source= DEVSRV\DEVSQL;Initial Catalog=CMS;Integrated Security=True");
            //  return con;
        }

    }


}
