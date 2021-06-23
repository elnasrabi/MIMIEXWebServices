using MobileAppServices.Models;
using System;
using System.Collections;
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
    public class OperationTransferController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<OperationTransfer> oneform = new List<OperationTransfer>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ImForms.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}



        // [Route(" api/OperationTransfer/getAllOperationTransfer")]


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




             [Route("api/OperationTransfer/getOperationTransfer")]
    public async Task<IHttpActionResult> GetOperationTransferByCode(string loginname, string password, long transfercode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
               

                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where a.LoginName == loginname && a.Password == password && a.TransferCode == transfercode
                                         select new OperationTransferDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CorrespondentName = a.CorrespondentName,
                                     ClientName = a.ClientName,
                                     CBOSID = a.CBOSID,
                                     CreationDate = a.CreationDate,
                                     CurrencyShortName = a.CurrencyShortName,
                                     Deduction = a.Deduction,
                                     DeductionUSD = a.DeductionUSD,
                                     TransferAmount = a.TransferAmount,
                                     TransferCode = a.TransferCode,
                                     TransferDate = a.TransferDate,
                                     TransferRemaining = a.TransferRemaining,
                                     BankNameAR=a.BankNameAR,
                                     BranchNameAR=a.BranchNameAR


                                         }).ToList();

                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);

            }
          else  if (utype == 2)
            {
             
                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where a.Branch == userbranch && a.Bank == userorg && a.TransferCode == transfercode
                                         select new OperationTransferDTO
                                         {
                                              LoginName = a.LoginName,FullName=a.FullName,
                                             CorrespondentName = a.CorrespondentName,
                                             ClientName = a.ClientName,
                                             CBOSID = a.CBOSID,
                                             CreationDate = a.CreationDate,
                                             CurrencyShortName = a.CurrencyShortName,
                                             Deduction = a.Deduction,
                                             DeductionUSD = a.DeductionUSD,
                                             TransferAmount = a.TransferAmount,
                                             TransferCode = a.TransferCode,
                                             TransferDate = a.TransferDate,
                                             BankNameAR = a.BankNameAR,
                                             BranchNameAR = a.BranchNameAR,
                                             TransferRemaining = a.TransferRemaining

                                         }).ToList();
                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);

            }

            else 
            {

                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where a.TransferCode == transfercode
                                         select new OperationTransferDTO
                                         {
                                             LoginName = a.LoginName,
                                             FullName = a.FullName,
                                             CorrespondentName = a.CorrespondentName,
                                             ClientName = a.ClientName,
                                             CBOSID = a.CBOSID,
                                             CreationDate = a.CreationDate,
                                             CurrencyShortName = a.CurrencyShortName,
                                             Deduction = a.Deduction,
                                             DeductionUSD = a.DeductionUSD,
                                             TransferAmount = a.TransferAmount,
                                             TransferCode = a.TransferCode,
                                             TransferDate = a.TransferDate,
                                             BankNameAR = a.BankNameAR,
                                             BranchNameAR = a.BranchNameAR,
                                             TransferRemaining = a.TransferRemaining

                                         }).ToList();
                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);

            }



        }


        [Route("api/OperationTransfer/getOperationTransferByOperation")]
        public async Task<IHttpActionResult> GetOperationTransferForms(string loginname, string password, long operationcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
              
                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where a.LoginName == loginname && a.Password == password && a.OperationCode == operationcode
                                         select new OperationTransferDTO
                                         {
                                              LoginName = a.LoginName,FullName=a.FullName,
                                             CorrespondentName = a.CorrespondentName,
                                             ClientName = a.ClientName,
                                             CBOSID = a.CBOSID,
                                             CreationDate = a.CreationDate,
                                             CurrencyShortName = a.CurrencyShortName,
                                             Deduction = a.Deduction,
                                             DeductionUSD = a.DeductionUSD,
                                             TransferAmount = a.TransferAmount,
                                             TransferCode = a.TransferCode,
                                             TransferDate = a.TransferDate,
                                             TransferRemaining = a.TransferRemaining,
                                             BankNameAR = a.BankNameAR,
                                             BranchNameAR = a.BranchNameAR

                                         }).ToList();
                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);

            }
            else if (utype == 2)
            {
                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where a.Branch == userbranch && a.Bank == userorg && a.OperationCode == operationcode
                                         select new OperationTransferDTO
                                         {
                                              LoginName = a.LoginName,FullName=a.FullName,
                                             CorrespondentName = a.CorrespondentName,
                                             ClientName = a.ClientName,
                                             CBOSID = a.CBOSID,
                                             CreationDate = a.CreationDate,
                                             CurrencyShortName = a.CurrencyShortName,
                                             Deduction = a.Deduction,
                                             DeductionUSD = a.DeductionUSD,
                                             TransferAmount = a.TransferAmount,
                                             TransferCode = a.TransferCode,
                                             TransferDate = a.TransferDate,
                                             TransferRemaining = a.TransferRemaining,
                                             BankNameAR = a.BankNameAR,
                                             BranchNameAR = a.BranchNameAR

                                         }).ToList();
                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);



            }
            else 
            {
                var OperationTransfer = (from a in dc.vOperationTransfer
                                         where  a.OperationCode == operationcode
                                         select new OperationTransferDTO
                                         {
                                             LoginName = a.LoginName,
                                             FullName = a.FullName,
                                             CorrespondentName = a.CorrespondentName,
                                             ClientName = a.ClientName,
                                             CBOSID = a.CBOSID,
                                             CreationDate = a.CreationDate,
                                             CurrencyShortName = a.CurrencyShortName,
                                             Deduction = a.Deduction,
                                             DeductionUSD = a.DeductionUSD,
                                             TransferAmount = a.TransferAmount,
                                             TransferCode = a.TransferCode,
                                             TransferDate = a.TransferDate,
                                             TransferRemaining = a.TransferRemaining,
                                             BankNameAR = a.BankNameAR,
                                             BranchNameAR = a.BranchNameAR

                                         }).ToList();
                if (OperationTransfer.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationTransfer);



            }


        }


        [Route("api/OperationTransfer/getAllOperationTransfer")]
        public async Task<IHttpActionResult> GetOperationTransferByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                    var OperationTransfer = (from a in dc.vOperationTransfer
                                             where a.LoginName == loginname && a.Password == password 
                                             select new OperationTransferDTO
                                             {
                                                  LoginName = a.LoginName,FullName=a.FullName,
                                                 CorrespondentName = a.CorrespondentName,
                                                 ClientName = a.ClientName,
                                                 CBOSID = a.CBOSID,
                                                 CreationDate = a.CreationDate,
                                                 CurrencyShortName = a.CurrencyShortName,
                                                 Deduction = a.Deduction,
                                                 DeductionUSD = a.DeductionUSD,
                                                 TransferAmount = a.TransferAmount,
                                                 TransferCode = a.TransferCode,
                                                 TransferDate = a.TransferDate,
                                                 TransferRemaining = a.TransferRemaining,
                                                 BankNameAR = a.BankNameAR,
                                                 BranchNameAR = a.BranchNameAR

                                             }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (OperationTransfer.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(OperationTransfer);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }


            }
            else if (utype == 1)
            {
                try
                {
                    var OperationTransfer = (from a in dc.vOperationTransfer
                                             where a.Branch == userbranch && a.Bank == userorg
                                             select new OperationTransferDTO
                                             {
                                                  LoginName = a.LoginName,FullName=a.FullName,
                                                 CorrespondentName = a.CorrespondentName,
                                                 ClientName = a.ClientName,
                                                 CBOSID = a.CBOSID,
                                                 CreationDate = a.CreationDate,
                                                 CurrencyShortName = a.CurrencyShortName,
                                                 Deduction = a.Deduction,
                                                 DeductionUSD = a.DeductionUSD,
                                                 TransferAmount = a.TransferAmount,
                                                 TransferCode = a.TransferCode,
                                                 TransferDate = a.TransferDate,
                                                 TransferRemaining = a.TransferRemaining,
                                                 BankNameAR = a.BankNameAR,
                                                 BranchNameAR = a.BranchNameAR

                                             }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (OperationTransfer.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(OperationTransfer);
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
                    var OperationTransfer = (from a in dc.vOperationTransfer
                                           
                                             select new OperationTransferDTO
                                             {
                                                 LoginName = a.LoginName,
                                                 FullName = a.FullName,
                                                 CorrespondentName = a.CorrespondentName,
                                                 ClientName = a.ClientName,
                                                 CBOSID = a.CBOSID,
                                                 CreationDate = a.CreationDate,
                                                 CurrencyShortName = a.CurrencyShortName,
                                                 Deduction = a.Deduction,
                                                 DeductionUSD = a.DeductionUSD,
                                                 TransferAmount = a.TransferAmount,
                                                 TransferCode = a.TransferCode,
                                                 TransferDate = a.TransferDate,
                                                 TransferRemaining = a.TransferRemaining,
                                                 BankNameAR = a.BankNameAR,
                                                 BranchNameAR = a.BranchNameAR

                                             }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (OperationTransfer.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(OperationTransfer);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





        }





    }


}
