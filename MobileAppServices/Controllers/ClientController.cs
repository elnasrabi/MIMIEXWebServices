using MobileAppServices.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MobileAppServices.Controllers
{
    public class ClientController : ApiController
    {


        int? userorg = 0;
        int? userbranch = 0;
        public int GetUserType(string loginname, string password)
        {
            int usertype = 1; //bank

            MIMEXEntities dc = new MIMEXEntities();


            var result = (from a in dc.IMEXUser
                          where a.LoginName == loginname && a.Password == password
                          select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList();


            if (result.FirstOrDefault().UserType == "Trader")
            {
                usertype = 1;

            }
            else if (result.FirstOrDefault().UserType == "Bank")
            {
                usertype = 2;

                var bankuser = dc.vIMEXUser.Where(a => a.LoginName == loginname && a.Password == password);

                userorg = bankuser.FirstOrDefault().OrgCode;
                userbranch = bankuser.FirstOrDefault().BranchCode;

            }
            else
            {
                usertype = 3;
            }

            return usertype;
        }





        [Route("api/Client/getClientInfo")]
        public async Task<IHttpActionResult> GetClientByCode(string loginname, string password,long? cbosid)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
            
                var Client = (from a in dc.vClientInquery
                              where a.LoginName == loginname && a.Password == password 
                                       select new ClientInqueryDTO
                                       {
                                           LoginName = a.LoginName,
                                           CBOSID = a.CBOSID,
                                           ClientStatusNameAR = a.ClientStatusNameAR,
                                           FullNameArabic = a.FullNameArabic,
                                           RequiredClaim = a.RequiredClaims,
                                           RequiredMaturity=a.RequiredMaturity,
                                           RequiredTransfers=a.DefaultedTransfers,
                                           Status = a.Status,

                                       }).ToList();

                if (Client.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Client);

            }
            else
            {
             
                var Client = (from a in dc.vClientInquery
                              where a.CBOSID == cbosid 
                              select new ClientInqueryDTO
                              {
                                  LoginName = a.LoginName,
                                  CBOSID = a.CBOSID,
                                  ClientStatusNameAR = a.ClientStatusNameAR,
                                  FullNameArabic = a.FullNameArabic,
                                  RequiredClaim = a.RequiredClaims,
                                  RequiredMaturity = a.RequiredMaturity,
                                  RequiredTransfers = a.DefaultedTransfers,
                                  Status = a.Status,

                              }).ToList();
                if (Client.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Client);

            }


        }


    }


}
