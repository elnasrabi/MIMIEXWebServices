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
    public class ClaimController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<Claim> oneform = new List<Claim>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.Claims.Where(a => a.FormNo.Equals(formno)).ToList();
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
                          select new IMEXUserDto {  LoginName = a.LoginName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList();


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




        [Route("api/Claim/GetClaimByForm")]
        public async Task<IHttpActionResult> Get(string loginname, string password,long formno)
        {
          
            MIMEXEntities dc = new MIMEXEntities();
                int utype = GetUserType(loginname, password);

                if (utype == 1)

                {
                    var Claim = (from a in dc.vClaimForTrader
                                 where a.LoginName == loginname && a.Password == password && a.FormCode == formno
                                 select new ClaimDTO
                                 {
                                     LoginName = a.LoginName,
                                     FullName = a.FullName,
                                     FullNameEnglish = a.FullNameEnglish,
                                     AmountUSD = a.AmountUSD,
                                     CBOSID = a.CBOSID,
                                     ClaimRemaining = a.ClaimRemaining,
                                     FormCode = a.FormCode,
                                     CommodityNameAR = a.CommodityNameAR,
                                     Measurement = a.Measurement,
                                     PaymentMethodNameAR = a.PaymentMethodNameAR
                                 ,
                                     DueDate = a.DueDate,
                                     PaymentPercent = a.PaymentPercent,
                                     ClaimCode = a.ClaimCode,
                                     ClaimDeduction = a.ClaimDeduction,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ClaimStatus = a.ClaimStatus
                                 }).ToList();

                    if (Claim.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Claim);

                }
                else if (utype == 2)
                {
                    var Claim = (from a in dc.vClaimForBank
                                 where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formno
                                 select new ClaimDTO
                                 {
                                     FullNameEnglish = a.FullNameEnglish,
                                     AmountUSD = a.AmountUSD,
                                     CBOSID = a.CBOSID,
                                     ClaimRemaining = a.ClaimRemaining,
                                     FormCode = a.FormCode,
                                     CommodityNameAR = a.CommodityNameAR,
                                     Measurement = Convert.ToInt32(a.Measurement),
                                     PaymentMethodNameAR = a.PaymentMethodNameAR
                                 ,
                                     DueDate = a.DueDate,
                                     PaymentPercent = a.PaymentPercent,
                                     ClaimCode = a.ClaimCode,
                                     ClaimDeduction = a.ClaimDeduction,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ClaimStatus = a.ClaimStatus
                                 }).ToList();
                    if (Claim.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Claim);

                }
                else
                {
                    var Claim = (from a in dc.vClaimForBank
                                 where a.FormCode == formno
                                 select new ClaimDTO
                                 {
                                     FullNameEnglish = a.FullNameEnglish,
                                     AmountUSD = a.AmountUSD,
                                     CBOSID = a.CBOSID,
                                     ClaimRemaining = a.ClaimRemaining,
                                     FormCode = a.FormCode,
                                     CommodityNameAR = a.CommodityNameAR,
                                     Measurement = Convert.ToInt32(a.Measurement),
                                     PaymentMethodNameAR = a.PaymentMethodNameAR
                                 ,
                                     DueDate = a.DueDate,
                                     PaymentPercent = a.PaymentPercent,
                                     ClaimCode = a.ClaimCode,
                                     ClaimDeduction = a.ClaimDeduction,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ClaimStatus = a.ClaimStatus
                                 }).ToList();
                    if (Claim.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Claim);

                }

         

        }

        [Route("api/Claim/getClaimsbyClaimCode")]
        public async Task<IHttpActionResult> GetByCLaimCode(string loginname, string password, long claimcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                var Claim = (from a in dc.vClaimForTrader
                             where a.LoginName == loginname && a.Password == password && a.ClaimCode == claimcode
                             select new ClaimDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 Measurement = a.Measurement,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus
                             }).ToList();

                if (Claim.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Claim);

            }
            else if (utype == 2)
            {
                var Claim = (from a in dc.vClaimForBank
                             where a.BankBranch == userbranch && a.Bank == userorg && a.ClaimCode == claimcode
                             select new ClaimDTO
                             {
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 FullName = a.FullName,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus
                                 
                             }).ToList();
                if (Claim.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Claim);

            }
            else 
            {
                var Claim = (from a in dc.vClaimForBank
                             where  a.ClaimCode == claimcode
                             select new ClaimDTO
                             {
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 FullName = a.FullName,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus

                             }).ToList();
                if (Claim.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Claim);

            }


        }

        [Route("api/Claim/getAllClaims")]
        public async Task<IHttpActionResult> GetAllClaim(string loginname, string password, DateTime fromdate , DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var Claim = (from a in dc.vClaimForTrader
                             where a.LoginName.Equals(loginname.Trim()) && a.Password.Equals(password.Trim())
                             select new ClaimDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 Measurement = a.Measurement,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus
                             }).ToList().Where(x => x.DueDate >= dtFrom && x.DueDate <= dtTo).Take(20);

                if (Claim.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Claim);
               
              


            }
            else if (utype == 2)
            {

                var Claim = (from a in dc.vClaimForBank
                             where a.BankBranch == userbranch && a.Bank == userorg
                             select new ClaimDTO
                             {
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 FullName = a.FullName,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus
                             }).ToList().Where(x => x.DueDate >= dtFrom && x.DueDate <= dtTo).Take(20); 
                    if (Claim.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Claim);
               

               

            }
            else 
            {

                var Claim = (from a in dc.vClaimForBank
                           
                             select new ClaimDTO
                             {
                                 FullNameEnglish = a.FullNameEnglish,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 ClaimRemaining = a.ClaimRemaining,
                                 FormCode = a.FormCode,
                                 CommodityNameAR = a.CommodityNameAR,
                                 FullName = a.FullName,
                                 PaymentMethodNameAR = a.PaymentMethodNameAR
                             ,
                                 DueDate = a.DueDate,
                                 PaymentPercent = a.PaymentPercent,
                                 ClaimCode = a.ClaimCode,
                                 ClaimDeduction = a.ClaimDeduction,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ClaimStatus = a.ClaimStatus
                             }).ToList().Where(x => x.DueDate >= dtFrom && x.DueDate <= dtTo).Take(20);
                if (Claim.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Claim);




            }

        }





        public async Task<IHttpActionResult> Get(string loginname)
        {
            MIMEXEntities dc = new MIMEXEntities();

            var Claim = (from a in dc.vClaimForTrader
                         where a.LoginName == loginname
                         select new ClaimDTO
                         {
                              LoginName = a.LoginName,FullName=a.FullName,
                             FullNameEnglish = a.FullNameEnglish,
                             AmountUSD = a.AmountUSD,
                             CBOSID = a.CBOSID,
                             ClaimRemaining = a.ClaimRemaining,
                             FormCode = a.FormCode,
                             CommodityNameAR = a.CommodityNameAR,
                             Measurement = a.Measurement,
                             PaymentMethodNameAR = a.PaymentMethodNameAR
                         ,
                             DueDate = a.DueDate,
                             PaymentPercent = a.PaymentPercent,
                             ClaimCode = a.ClaimCode,
                             ClaimDeduction = a.ClaimDeduction,
                             BankNameAR = a.BankNameAR,
                             BranchNameAR = a.BranchNameAR,
                             ClaimStatus=a.ClaimStatus
                         }).ToList();
            if (Claim.Count() ==0)
            {
                return NotFound();
            }

            return Ok(Claim);
        }




    }
}
