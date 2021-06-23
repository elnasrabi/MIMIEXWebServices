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
    public class MaturityController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<Maturity> oneform = new List<Maturity>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.Maturitys.Where(a => a.FormNo.Equals(formno)).ToList();
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



        [Route("api/Maturity/getMaturity")]
        public async Task<IHttpActionResult> GetMaturityByCode(string loginname, string password, long maturitycode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
              


                var Maturity = (from a in dc.vMaturityStatus
                             where a.LoginName == loginname && a.Password == password && a.MaturityCode == maturitycode
                                select new MaturityDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 ActionTime = a.ActionTime,
                                 Amount = a.Amount,
                                    MaturityStatus = a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                 CurrnecyNameAR = a.CurrnecyNameAR,
                                 FormCode = a.FormCode,
                                 MaturityRemaining = a.MaturityRemaining,
                                 MaturityCode = a.MaturityCode,
                                 MaturityDate = a.MaturityDate,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FlowStatus = a.FlowStatus
                             }).ToList();


                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }
            else if (utype == 2)
            {
                var Maturity = (from a in dc.vMaturityStatus
                                where a.Branch == userbranch && a.Bank == userorg && a.MaturityCode == maturitycode
                                select new MaturityDTO
                                {
                                     LoginName = a.LoginName,FullName=a.FullName,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    MaturityStatus=a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                    CurrnecyNameAR = a.CurrnecyNameAR,
                                    FormCode = a.FormCode,
                                    MaturityRemaining = a.MaturityRemaining,
                                    MaturityCode = a.MaturityCode,
                                    MaturityDate = a.MaturityDate,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    FlowStatus = a.FlowStatus
                                }).ToList();


                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }
            else
            {
                var Maturity = (from a in dc.vMaturityStatus
                                where  a.MaturityCode == maturitycode
                                select new MaturityDTO
                                {
                                    LoginName = a.LoginName,
                                    FullName = a.FullName,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    MaturityStatus = a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                    CurrnecyNameAR = a.CurrnecyNameAR,
                                    FormCode = a.FormCode,
                                    MaturityRemaining = a.MaturityRemaining,
                                    MaturityCode = a.MaturityCode,
                                    MaturityDate = a.MaturityDate,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    FlowStatus = a.FlowStatus
                                }).ToList();


                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }


        }


        [Route("api/Maturity/getMaturityByForm")]
        public async Task<IHttpActionResult> GetFormMaturity(string loginname, string password, long formcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var Maturity = (from a in dc.vMaturityStatus
                                where a.LoginName == loginname && a.Password == password && a.FormCode == formcode
                                select new MaturityDTO
                                {
                                     LoginName = a.LoginName,FullName=a.FullName,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    MaturityStatus = a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                    CurrnecyNameAR = a.CurrnecyNameAR,
                                    FormCode = a.FormCode,
                                    MaturityRemaining = a.MaturityRemaining,
                                    MaturityCode = a.MaturityCode,
                                    MaturityDate = a.MaturityDate,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    FlowStatus = a.FlowStatus
                                }).ToList();



                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }
            else if (utype == 2)
            {
              

                var Maturity = (from a in dc.vMaturityStatus
                                where a.Branch == userbranch && a.Bank == userorg && a.FormCode == formcode
                                select new MaturityDTO
                                {
                                     LoginName = a.LoginName,FullName=a.FullName,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    MaturityStatus = a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                    CurrnecyNameAR = a.CurrnecyNameAR,
                                    FormCode = a.FormCode,
                                    MaturityRemaining = a.MaturityRemaining,
                                    MaturityCode = a.MaturityCode,
                                    MaturityDate = a.MaturityDate,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    FlowStatus = a.FlowStatus
                                }).ToList();


                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }
            else 
            {


                var Maturity = (from a in dc.vMaturityStatus
                                where  a.FormCode == formcode
                                select new MaturityDTO
                                {
                                    LoginName = a.LoginName,
                                    FullName = a.FullName,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    MaturityStatus = a.MaturityStatus,
                                    AmountUSD = a.AmountUSD,
                                    CurrnecyNameAR = a.CurrnecyNameAR,
                                    FormCode = a.FormCode,
                                    MaturityRemaining = a.MaturityRemaining,
                                    MaturityCode = a.MaturityCode,
                                    MaturityDate = a.MaturityDate,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    FlowStatus = a.FlowStatus
                                }).ToList();


                if (Maturity.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Maturity);

            }


        }

        [Route("api/Maturity/getAllMaturity")]
        public async Task<IHttpActionResult> Getmaturitybydate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                try
                {
        

                    var Maturity = (from a in dc.vMaturityStatus
                                    where a.LoginName == loginname && a.Password == password 
                                    select new MaturityDTO
                                    {
                                         LoginName = a.LoginName,FullName=a.FullName,
                                        ActionTime = a.ActionTime,
                                        Amount = a.Amount,
                                        MaturityStatus = a.MaturityStatus,
                                        AmountUSD = a.AmountUSD,
                                        CurrnecyNameAR = a.CurrnecyNameAR,
                                        FormCode = a.FormCode,
                                        MaturityRemaining = a.MaturityRemaining,
                                        MaturityCode = a.MaturityCode,
                                        MaturityDate = a.MaturityDate,
                                        FlowStatusNameIM = a.FlowStatusNameIM,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        FlowStatus = a.FlowStatus
                                    }).ToList().Where(x => x.MaturityDate >= dtFrom && x.MaturityDate <= dtTo).Take(20);



                    if (Maturity.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Maturity);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }
            else if (utype == 2)
            {

                try
                {
                    

                    var Maturity = (from a in dc.vMaturityStatus
                                    where a.Branch == userbranch && a.Bank == userorg
                                    select new MaturityDTO
                                    {
                                         LoginName = a.LoginName,FullName=a.FullName,
                                        ActionTime = a.ActionTime,
                                        Amount = a.Amount,
                                        MaturityStatus = a.MaturityStatus,
                                        AmountUSD = a.AmountUSD,
                                        CurrnecyNameAR = a.CurrnecyNameAR,
                                        FormCode = a.FormCode,
                                        MaturityRemaining = a.MaturityRemaining,
                                        MaturityCode = a.MaturityCode,
                                        MaturityDate = a.MaturityDate,
                                        FlowStatusNameIM = a.FlowStatusNameIM,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        FlowStatus = a.FlowStatus
                                    }).ToList().Where(x => x.MaturityDate >= dtFrom && x.MaturityDate <= dtTo).Take(20);

                    if (Maturity.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Maturity);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }




            }

            else 
            {

                try
                {


                    var Maturity = (from a in dc.vMaturityStatus
                                   
                                    select new MaturityDTO
                                    {
                                        LoginName = a.LoginName,
                                        FullName = a.FullName,
                                        ActionTime = a.ActionTime,
                                        Amount = a.Amount,
                                        MaturityStatus = a.MaturityStatus,
                                        AmountUSD = a.AmountUSD,
                                        CurrnecyNameAR = a.CurrnecyNameAR,
                                        FormCode = a.FormCode,
                                        MaturityRemaining = a.MaturityRemaining,
                                        MaturityCode = a.MaturityCode,
                                        MaturityDate = a.MaturityDate,
                                        FlowStatusNameIM = a.FlowStatusNameIM,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        FlowStatus = a.FlowStatus
                                    }).ToList().Where(x => x.MaturityDate >= dtFrom && x.MaturityDate <= dtTo).Take(20);

                    if (Maturity.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Maturity);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }




            }

        }





    }
}
