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
    public class ClaimSettlementController : ApiController
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





        [Route("api/ClaimSettlement/getClaimSettlement")]
        public async Task<IHttpActionResult> GetClaimSettlementByCode(string loginname, string password, long claimsettlementcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
               

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.LoginName == loginname && a.Password == password && a.ClaimSettlementCode == claimsettlementcode
                                       select new ClaimSettlementDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 Bank = a.Bank,
                                 BankBranch = a.BankBranch,
                                 ClaimSettlementCode = a.ClaimSettlementCode,
                                 CreationDate = a.CreationDate,
                                 FormCode = a.FormCode,
                                 Deduction = a.Deduction,
                                 DeductionUSD = a.DeductionUSD,
                                 FlowStatus = a.FlowStatus,
                                 PaymentCode = a.PaymentCode,
                                 RejectionNotes = a.RejectionNotes,
                                 ClaimCode = a.ClaimCode,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                
                             }).ToList();

                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else if (utype == 2)
            {
              

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.ClaimSettlementCode == claimsettlementcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else 
            {


                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where  a.ClaimSettlementCode == claimsettlementcode
                                       select new ClaimSettlementDTO
                                       {
                                           LoginName = a.LoginName,
                                           FullName = a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }


        }

        [Route("api/ClaimSettlement/getClaimSettlementByClaim")]
        public async Task<IHttpActionResult> GetClaimSettlementByClaim(string loginname, string password, long claimcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.LoginName == loginname && a.Password == password && a.ClaimCode == claimcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();

                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else if (utype == 2)
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.ClaimCode == claimcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else 
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where  a.ClaimCode == claimcode
                                       select new ClaimSettlementDTO
                                       {
                                           LoginName = a.LoginName,
                                           FullName = a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }


        }


        [Route("api/ClaimSettlement/getClaimSettlementByForm")]
        public async Task<IHttpActionResult> GetClaimSettlementByForm(string loginname, string password, long formcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
              

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.LoginName == loginname && a.Password == password && a.FormCode == formcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else if (utype == 2)
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }

            else 
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formcode
                                       select new ClaimSettlementDTO
                                       {
                                           LoginName = a.LoginName,
                                           FullName = a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();
                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }


        }


        [Route("api/ClaimSettlement/getClaimSettlementByPayment")]
        public async Task<IHttpActionResult> GetClaimSettlementByPayment(string loginname, string password, long paymentcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
          

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.LoginName == loginname && a.Password == password && a.PaymentCode == paymentcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();

                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }
            else if (utype == 2)
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.PaymentCode == paymentcode
                                       select new ClaimSettlementDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();

                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }

            else
            {

                var ClaimSettlement = (from a in dc.vClaimSettlement
                                       where  a.PaymentCode == paymentcode
                                       select new ClaimSettlementDTO
                                       {
                                           LoginName = a.LoginName,
                                           FullName = a.FullName,
                                           Bank = a.Bank,
                                           BankBranch = a.BankBranch,
                                           ClaimSettlementCode = a.ClaimSettlementCode,
                                           CreationDate = a.CreationDate,
                                           FormCode = a.FormCode,
                                           Deduction = a.Deduction,
                                           DeductionUSD = a.DeductionUSD,
                                           FlowStatus = a.FlowStatus,
                                           PaymentCode = a.PaymentCode,
                                           RejectionNotes = a.RejectionNotes,
                                           ClaimCode = a.ClaimCode,
                                           FlowStatusNameEX = a.FlowStatusNameEX,

                                       }).ToList();

                if (ClaimSettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ClaimSettlement);

            }



        }

        [Route("api/ClaimSettlement/getAllClaimSettlement")]
        public async Task<IHttpActionResult> GetClaimSettlementByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {


                    var ClaimSettlement = (from a in dc.vClaimSettlement
                                           where a.LoginName == loginname && a.Password == password 
                                           select new ClaimSettlementDTO
                                           {
                                                LoginName = a.LoginName,FullName=a.FullName,
                                               Bank = a.Bank,
                                               BankBranch = a.BankBranch,
                                               ClaimSettlementCode = a.ClaimSettlementCode,
                                               CreationDate = a.CreationDate,
                                               FormCode = a.FormCode,
                                               Deduction = a.Deduction,
                                               DeductionUSD = a.DeductionUSD,
                                               FlowStatus = a.FlowStatus,
                                               PaymentCode = a.PaymentCode,
                                               RejectionNotes = a.RejectionNotes,
                                               ClaimCode = a.ClaimCode,
                                               FlowStatusNameEX = a.FlowStatusNameEX,

                                           }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);

                    if (ClaimSettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ClaimSettlement);
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

                    var ClaimSettlement = (from a in dc.vClaimSettlement
                                           where a.BankBranch == userbranch && a.Bank == userorg
                                           select new ClaimSettlementDTO
                                           {
                                                LoginName = a.LoginName,FullName=a.FullName,
                                               Bank = a.Bank,
                                               BankBranch = a.BankBranch,
                                               ClaimSettlementCode = a.ClaimSettlementCode,
                                               CreationDate = a.CreationDate,
                                               FormCode = a.FormCode,
                                               Deduction = a.Deduction,
                                               DeductionUSD = a.DeductionUSD,
                                               FlowStatus = a.FlowStatus,
                                               PaymentCode = a.PaymentCode,
                                               RejectionNotes = a.RejectionNotes,
                                               ClaimCode = a.ClaimCode,
                                               FlowStatusNameEX = a.FlowStatusNameEX,

                                           }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20); 
                    if (ClaimSettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ClaimSettlement);
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

                    var ClaimSettlement = (from a in dc.vClaimSettlement
                                           
                                           select new ClaimSettlementDTO
                                           {
                                               LoginName = a.LoginName,
                                               FullName = a.FullName,
                                               Bank = a.Bank,
                                               BankBranch = a.BankBranch,
                                               ClaimSettlementCode = a.ClaimSettlementCode,
                                               CreationDate = a.CreationDate,
                                               FormCode = a.FormCode,
                                               Deduction = a.Deduction,
                                               DeductionUSD = a.DeductionUSD,
                                               FlowStatus = a.FlowStatus,
                                               PaymentCode = a.PaymentCode,
                                               RejectionNotes = a.RejectionNotes,
                                               ClaimCode = a.ClaimCode,
                                               FlowStatusNameEX = a.FlowStatusNameEX,

                                           }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (ClaimSettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ClaimSettlement);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





       





    }




















}


}
