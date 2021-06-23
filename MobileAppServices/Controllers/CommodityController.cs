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
    public class CommodityController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<Commodity> oneform = new List<Commodity>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.Commoditys.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}


        int? userorg = 0;
        int? userbranch = 0;
        internal int GetUserType(string loginname, string password)
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



 

        public async Task<IHttpActionResult> Get(string loginname, string password)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                var result = (from a in dc.vExCommodity
                              select new CommodityDTO { id = a.id, name = a.name }).ToList();

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            else
            {
                var result = (from a in dc.vExCommodity
                              select new CommodityDTO { id = a.id, name = a.name}).ToList();

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }

          
        }

        public async Task<IHttpActionResult> GetCommodity(string loginname, string password,string searchword)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                List<CommodityDTO> result ;
                if (searchword.Trim()=="ALL")
                {
                     result = (from a in dc.vExCommodity
                                  select new CommodityDTO { id = a.id, name = a.name }).ToList();
                }
                else
                {
                    result = (from a in dc.vExCommodity
                              where a.name.Contains(searchword)
                              select new CommodityDTO { id = a.id, name = a.name }).ToList();

                }

              


                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            else
            {
                var result = (from a in dc.vExCommodity
                              where a.name.Contains(searchword)
                              select new CommodityDTO { id = a.id, name = a.name }).ToList();

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }


        }




    }
}
