using MobileAppServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MobileAppServices.Controllers
{
    public class LicenseRequestCommodityController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<ImForm> oneform = new List<ImForm>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ImForms.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}

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


        [Route("api/LicenseRequestCommodity/getLicenseRequestCommodityByCode")]
        public async Task<IHttpActionResult> GetLicenseCommodityByCode(string loginname, string password,long licenserequestcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
              


                var LicenseRequestComm = (from a in dc.vLicenseRequestCommodity
                                           where a.LoginName == loginname && a.Password == password && a.LicenseRequestCode == licenserequestcode
                                          select new LicenseRequestCommodityDTO
                                           {
                                               CommodityNameAR = a.CommodityNameAR,
                                               LoginName = a.LoginName,
                                               CommodityCode = a.CommodityCode,
                                               MeasurementUnitNameEN = a.MeasurementUnitNameEN,
                                               Qty = a.Qty,
                                               UnitPrice = a.UnitPrice,
                                           }).ToList();

                if (LicenseRequestComm.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(LicenseRequestComm);

            }
            else
            {

                var LicenseRequestComm = (from a in dc.vLicenseRequestCommodity
                                           where a.BankBranch == userbranch && a.Bank == userorg && a.LicenseRequestCode == licenserequestcode
                                           select new LicenseRequestCommodityDTO
                                           {
                                               CommodityNameAR = a.CommodityNameAR,
                                               LoginName = a.LoginName,
                                               CommodityCode = a.CommodityCode,
                                               MeasurementUnitNameEN = a.MeasurementUnitNameEN,
                                               Qty = a.Qty,
                                               UnitPrice = a.UnitPrice,
                                           }).ToList();

                if (LicenseRequestComm.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(LicenseRequestComm);

               

            }

           
        }


   



    }
}
