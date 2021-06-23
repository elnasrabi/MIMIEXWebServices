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
    public class PaymentController : ApiController
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




        [Route("api/Payment/getPayment")]
        public async Task<IHttpActionResult> GetPaymentByCode(string loginname, string password,long paymentcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var payment = (from a in dc.vPayment
                               where a.LoginName == loginname && a.Password == password && a.PaymentCode == paymentcode
                               select new PaymentDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                   CurrencyShortName = a.CurrencyShortName,
                                   Amount = a.Amount,
                                 AmountUSD = a.AmountUSD,
                                 CBOSID = a.CBOSID,
                                 CorrespondentAccount = a.CorrespondentAccount,
                                 CorrespondentName = a.CorrespondentName,
                                 Discounts = a.Discounts,
                                 Notes = a.Note,
                                 PaymentDate = a.PaymentDate,
                                 CreationTime = a.CreationTime,
                                 PaymentCode = a.PaymentCode,
                                 PaymentRemaining = a.PaymentRemaining,
                                 PaymentType = a.PaymentType,
                                 RejectionNotes = a.RejectionNotes,
                                 Rate = a.Rate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FlowStatusNamePayment = a.FlowStatusNamePayment
                               }).ToList();
                if (payment.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(payment);

            }
            else if (utype == 2)
            {
               
                var payment = (from a in dc.vPayment
                               where a.BankBranch == userbranch && a.Bank == userorg && a.PaymentCode == paymentcode
                               select new PaymentDTO
                               {
                                    LoginName = a.LoginName,FullName=a.FullName,
                                   CurrencyShortName = a.CurrencyShortName,
                                   Amount = a.Amount,
                                   AmountUSD = a.AmountUSD,
                                   CBOSID = a.CBOSID,
                                   CorrespondentAccount = a.CorrespondentAccount,
                                   CorrespondentName = a.CorrespondentName,
                                   Discounts = a.Discounts,
                                   Notes = a.Note,
                                   PaymentDate = a.PaymentDate,
                                   CreationTime = a.CreationTime,
                                   PaymentCode = a.PaymentCode,
                                   PaymentRemaining = a.PaymentRemaining,
                                   PaymentType = a.PaymentType,
                                   RejectionNotes = a.RejectionNotes,
                                   Rate = a.Rate,
                                   BankNameAR = a.BankNameAR,
                                   BranchNameAR = a.BranchNameAR,
                                   FlowStatusNamePayment = a.FlowStatusNamePayment
                               }).ToList();
                if (payment.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(payment);

            }
            else 
            {

                var payment = (from a in dc.vPayment
                               where  a.PaymentCode == paymentcode
                               select new PaymentDTO
                               {
                                   LoginName = a.LoginName,
                                   FullName = a.FullName,
                                   CurrencyShortName = a.CurrencyShortName,
                                   Amount = a.Amount,
                                   AmountUSD = a.AmountUSD,
                                   CBOSID = a.CBOSID,
                                   CorrespondentAccount = a.CorrespondentAccount,
                                   CorrespondentName = a.CorrespondentName,
                                   Discounts = a.Discounts,
                                   Notes = a.Note,
                                   PaymentDate = a.PaymentDate,
                                   CreationTime = a.CreationTime,
                                   PaymentCode = a.PaymentCode,
                                   PaymentRemaining = a.PaymentRemaining,
                                   PaymentType = a.PaymentType,
                                   RejectionNotes = a.RejectionNotes,
                                   Rate = a.Rate,
                                   BankNameAR = a.BankNameAR,
                                   BranchNameAR = a.BranchNameAR,
                                   FlowStatusNamePayment = a.FlowStatusNamePayment
                               }).ToList();
                if (payment.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(payment);

            }





        }



        [Route("api/Payment/GetAllPayment")]
        public async Task<IHttpActionResult> GetPaymentByDate(string loginname, string password, DateTime fromdate , DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                    var payment = (from a in dc.vPayment
                                   where a.LoginName == loginname && a.Password == password
                                   select new PaymentDTO
                                   {
                                        LoginName = a.LoginName,FullName=a.FullName,
                                       CurrencyShortName = a.CurrencyShortName,
                                       Amount = a.Amount,
                                       AmountUSD = a.AmountUSD,
                                       CBOSID = a.CBOSID,
                                       CorrespondentAccount = a.CorrespondentAccount,
                                       CorrespondentName = a.CorrespondentName,
                                       Discounts = a.Discounts,
                                       Notes = a.Note,
                                       PaymentDate = a.PaymentDate,
                                       CreationTime = a.CreationTime,
                                       PaymentCode = a.PaymentCode,
                                       PaymentRemaining = a.PaymentRemaining,
                                       PaymentType = a.PaymentType,
                                       RejectionNotes = a.RejectionNotes,
                                       Rate = a.Rate,
                                       BankNameAR = a.BankNameAR,
                                       BranchNameAR = a.BranchNameAR,
                                       FlowStatusNamePayment = a.FlowStatusNamePayment
                                   }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (payment.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(payment);
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
                    var payment = (from a in dc.vPayment
                                   where a.BankBranch == userbranch && a.Bank == userorg
                                   select new PaymentDTO
                                   {
                                        LoginName = a.LoginName,FullName=a.FullName,
                                       CurrencyShortName = a.CurrencyShortName,
                                       Amount = a.Amount,
                                       AmountUSD = a.AmountUSD,
                                       CBOSID = a.CBOSID,
                                       CorrespondentAccount = a.CorrespondentAccount,
                                       CorrespondentName = a.CorrespondentName,
                                       Discounts = a.Discounts,
                                       Notes = a.Note,
                                       PaymentDate = a.PaymentDate,
                                       CreationTime = a.CreationTime,
                                       PaymentCode = a.PaymentCode,
                                       PaymentRemaining = a.PaymentRemaining,
                                       PaymentType = a.PaymentType,
                                       RejectionNotes = a.RejectionNotes,
                                       Rate = a.Rate,
                                       BankNameAR=a.BankNameAR,
                                       BranchNameAR=a.BranchNameAR,
                                       FlowStatusNamePayment=a.FlowStatusNamePayment
                                   }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (payment.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(payment);
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
                    var payment = (from a in dc.vPayment
                               
                                   select new PaymentDTO
                                   {
                                       LoginName = a.LoginName,
                                       FullName = a.FullName,
                                       CurrencyShortName = a.CurrencyShortName,
                                       Amount = a.Amount,
                                       AmountUSD = a.AmountUSD,
                                       CBOSID = a.CBOSID,
                                       CorrespondentAccount = a.CorrespondentAccount,
                                       CorrespondentName = a.CorrespondentName,
                                       Discounts = a.Discounts,
                                       Notes = a.Note,
                                       PaymentDate = a.PaymentDate,
                                       CreationTime = a.CreationTime,
                                       PaymentCode = a.PaymentCode,
                                       PaymentRemaining = a.PaymentRemaining,
                                       PaymentType = a.PaymentType,
                                       RejectionNotes = a.RejectionNotes,
                                       Rate = a.Rate,
                                       BankNameAR = a.BankNameAR,
                                       BranchNameAR = a.BranchNameAR,
                                       FlowStatusNamePayment = a.FlowStatusNamePayment
                                   }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (payment.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(payment);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }


            }

        }





     




    }
}
