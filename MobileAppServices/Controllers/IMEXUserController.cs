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
    public class IMEXUserController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<IMEXUser> oneform = new List<IMEXUser>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.IMEXUsers.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}
       


      
        public async Task<IHttpActionResult> Get(string loginname,string password)
        {
            try
            {
                MIMEXEntities dc = new MIMEXEntities();


                var result = (from a in dc.IMEXUser
                              where a.LoginName == loginname && a.Password == password && a.IsActive == true && a.IsExpired == false
                              select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType, IsFirstLogin = a.IsFirstLogin, IsActive = a.IsActive, IsExpired = a.IsExpired, IsMobileVerified = a.IsMobileVerified }).ToList();


                if (result == null || result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

  
        public async Task<IHttpActionResult> GetIMEXUserDetail(string loginname)
        {
            MIMEXEntities dc = new MIMEXEntities();

            var result = (from a in dc.IMEXUser 
                          where a.LoginName ==loginname && a.IsActive == true && a.IsExpired == false
                          select  new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName ,MobileNo=a.MobileNo,CBOSID=a.CBOSID ,UserType=a.UserType,IsMobileVerified=a.IsMobileVerified}).ToList();

          
            if (result == null || result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]

        public async Task<IHttpActionResult> Post(string loginname, string password)
        {

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spVerifyUser") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LoginName", loginname));
            cmd.Parameters.Add(new SqlParameter("@Password", password));
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

        public async Task<IHttpActionResult> ChangePassword(string loginname, string newpassword)
        {

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spChangePassword") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LoginName", loginname));
            cmd.Parameters.Add(new SqlParameter("@NewPassword", newpassword));
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


        //public async Task<IHttpActionResult> OTPChangePassword(string loginname, string newpassword)
        //{

        //    MIMEXEntities dc = new MIMEXEntities();
        //    try
        //    {
        //        var result = (from a in dc.IMEXUser 
        //                      where a.LoginName == loginname && a.IsActive == true && a.IsExpired == false && a.IsMobileVerified == true
        //                      select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList();


        //        if (result == null || result.Count() == 0)
        //        {
        //            return NotFound();
        //        }
        //      }
        //    catch (Exception)
        //    {

        //        return NotFound();
        //    }
           
        //    SqlConnection locConn = getConnection();
        //    var cmd = new SqlCommand("spChangePassword") { Connection = locConn, CommandType = CommandType.StoredProcedure };
        //    cmd.Parameters.Add(new SqlParameter("@LoginName", loginname));
        //    cmd.Parameters.Add(new SqlParameter("@NewPassword", newpassword));
        //    try
        //    {
        //        locConn.Open();
        //        cmd.ExecuteNonQuery();
        //        return StatusCode(HttpStatusCode.OK);


        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(HttpStatusCode.BadRequest);
        //    }



        //    locConn.Close();

        //}

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
