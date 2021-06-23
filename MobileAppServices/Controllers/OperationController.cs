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
    public class OperationController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<Operation> oneform = new List<Operation>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ImForms.Where(a => a.FormNo.Equals(formno)).ToList();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}



        // [Route(" api/Operation/getAllOperation")]


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




             [Route("api/Operation/getOperation")]
    public async Task<IHttpActionResult> GetOperationByCode(string loginname, string password, long operationcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
               
                var Operation = (from a in dc.vOperation
                                 where a.LoginName == loginname && a.Password == password && a.OperationCode == operationcode
                             select new OperationDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 CreationTime = a.CreationTime,
                                 CurrencyName = a.CurrencyName,
                                 CBOSID = a.CBOSID,
                                 DataEntereerName = a.DataEntereerName,
                                 DocArrivalDate = a.DocArrivalDate,
                                 ExporterCountry = a.ExporterCountry,
                                 ExporterCountryName = a.ExporterCountryName,
                                 FirstApprovalName = a.FirstApprovalName,
                                 FullNameArabic = a.FullNameArabic,
                                 OperationAmountRemaining = a.OperationAmountRemaining,
                                 PaymentTypeName = a.PaymentTypeName,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 CurrencyShortName=a.CurrencyName,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 RefNumber = a.RefNumber,
                                 OperationCode = a.OperationCode,
                                 OperationDate = a.OperationDate,
                                 Notes = a.Notes,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 ImportPurposeName = a.ImportPurposeName,
                                 TaxNo = a.TaxNo,
                                 Currency = a.Currency,
                                 ImportPurpose = a.ImportPurpose,
                                 PaymentType = a.PaymentType,
                                 SecondApprovalName = a.SecondApprovalName,
                                 Bank = a.Bank,
                                 Branch = a.Branch,
                                 RejectionNotes = a.RejectionNotes
                             }).ToList();
                if (Operation.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Operation);

            }
            else if (utype == 2)
            {
           

                var Operation = (from a in dc.vOperation
                                 where a.Branch == userbranch && a.Bank == userorg && a.OperationCode == operationcode
                                 select new OperationDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CreationTime = a.CreationTime,
                                     CurrencyName = a.CurrencyName,
                                     CBOSID = a.CBOSID,
                                     DataEntereerName = a.DataEntereerName,
                                     DocArrivalDate = a.DocArrivalDate,
                                     ExporterCountry = a.ExporterCountry,
                                     ExporterCountryName = a.ExporterCountryName,
                                     FirstApprovalName = a.FirstApprovalName,
                                     FullNameArabic = a.FullNameArabic,
                                     OperationAmountRemaining = a.OperationAmountRemaining,
                                     PaymentTypeName = a.PaymentTypeName,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     CurrencyShortName = a.CurrencyName,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     RefNumber = a.RefNumber,
                                     OperationCode = a.OperationCode,
                                     OperationDate = a.OperationDate,
                                     Notes = a.Notes,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     ImportPurposeName = a.ImportPurposeName,
                                     TaxNo = a.TaxNo,
                                     Currency = a.Currency,
                                     ImportPurpose = a.ImportPurpose,
                                     PaymentType = a.PaymentType,
                                     SecondApprovalName = a.SecondApprovalName,
                                     Bank = a.Bank,
                                     Branch = a.Branch,
                                     RejectionNotes = a.RejectionNotes
                                 }).ToList();
                if (Operation.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Operation);

            }
            else
            {


                var Operation = (from a in dc.vOperation
                                 where  a.OperationCode == operationcode
                                 select new OperationDTO
                                 {
                                     LoginName = a.LoginName,
                                     FullName = a.FullName,
                                     CreationTime = a.CreationTime,
                                     CurrencyName = a.CurrencyName,
                                     CBOSID = a.CBOSID,
                                     DataEntereerName = a.DataEntereerName,
                                     DocArrivalDate = a.DocArrivalDate,
                                     ExporterCountry = a.ExporterCountry,
                                     ExporterCountryName = a.ExporterCountryName,
                                     FirstApprovalName = a.FirstApprovalName,
                                     FullNameArabic = a.FullNameArabic,
                                     OperationAmountRemaining = a.OperationAmountRemaining,
                                     PaymentTypeName = a.PaymentTypeName,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     CurrencyShortName = a.CurrencyName,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     RefNumber = a.RefNumber,
                                     OperationCode = a.OperationCode,
                                     OperationDate = a.OperationDate,
                                     Notes = a.Notes,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     ImportPurposeName = a.ImportPurposeName,
                                     TaxNo = a.TaxNo,
                                     Currency = a.Currency,
                                     ImportPurpose = a.ImportPurpose,
                                     PaymentType = a.PaymentType,
                                     SecondApprovalName = a.SecondApprovalName,
                                     Bank = a.Bank,
                                     Branch = a.Branch,
                                     RejectionNotes = a.RejectionNotes
                                 }).ToList();
                if (Operation.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Operation);

            }


        }




        [Route("api/Operation/getAllOperation")]
        public async Task<IHttpActionResult> GetOperationByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                  
                var Operation = (from a in dc.vOperation
                                 where a.LoginName == loginname && a.Password == password 
                                 select new OperationDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CreationTime = a.CreationTime,
                                     CurrencyName = a.CurrencyName,
                                     CBOSID = a.CBOSID,
                                     DataEntereerName = a.DataEntereerName,
                                     DocArrivalDate = a.DocArrivalDate,
                                     ExporterCountry = a.ExporterCountry,
                                     ExporterCountryName = a.ExporterCountryName,
                                     FirstApprovalName = a.FirstApprovalName,
                                     FullNameArabic = a.FullNameArabic,
                                     OperationAmountRemaining = a.OperationAmountRemaining,
                                     PaymentTypeName = a.PaymentTypeName,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     CurrencyShortName = a.CurrencyName,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     RefNumber = a.RefNumber,
                                     OperationCode = a.OperationCode,
                                     OperationDate = a.OperationDate,
                                     Notes = a.Notes,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     ImportPurposeName = a.ImportPurposeName,
                                     TaxNo = a.TaxNo,
                                     Currency = a.Currency,
                                     ImportPurpose = a.ImportPurpose,
                                     PaymentType = a.PaymentType,
                                     SecondApprovalName = a.SecondApprovalName,
                                     Bank = a.Bank,
                                     Branch = a.Branch,
                                     RejectionNotes = a.RejectionNotes
                                 }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (Operation.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Operation);
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
                        var Operation = (from a in dc.vOperation
                                         where a.Branch == userbranch && a.Bank == userorg
                                         select new OperationDTO
                                         {
                                              LoginName = a.LoginName,FullName=a.FullName,
                                             CreationTime = a.CreationTime,
                                             CurrencyName = a.CurrencyName,
                                             CBOSID = a.CBOSID,
                                             DataEntereerName = a.DataEntereerName,
                                             DocArrivalDate = a.DocArrivalDate,
                                             ExporterCountry = a.ExporterCountry,
                                             ExporterCountryName = a.ExporterCountryName,
                                             FirstApprovalName = a.FirstApprovalName,
                                             FullNameArabic = a.FullNameArabic,
                                             OperationAmountRemaining = a.OperationAmountRemaining,
                                             PaymentTypeName = a.PaymentTypeName,
                                             ExporterName = a.ExporterName,
                                             BankNameAR = a.BankNameAR,
                                             CurrencyShortName = a.CurrencyName,
                                             BranchNameAR = a.BranchNameAR,
                                             ImportersRegister = a.ImportersRegister,
                                             RefNumber = a.RefNumber,
                                             OperationCode = a.OperationCode,
                                             OperationDate = a.OperationDate,
                                             Notes = a.Notes,
                                             TotalValue = a.TotalValue,
                                             TotalValueUSD = a.TotalValueUSD,
                                             FlowStatus = a.FlowStatus,
                                             ImportPurposeName = a.ImportPurposeName,
                                             TaxNo = a.TaxNo,
                                             Currency = a.Currency,
                                             ImportPurpose = a.ImportPurpose,
                                             PaymentType = a.PaymentType,
                                             SecondApprovalName = a.SecondApprovalName,
                                             Bank = a.Bank,
                                             Branch = a.Branch,
                                             RejectionNotes = a.RejectionNotes
                                         }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (Operation.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Operation);
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
                    var Operation = (from a in dc.vOperation
                                    
                                     select new OperationDTO
                                     {
                                         LoginName = a.LoginName,
                                         FullName = a.FullName,
                                         CreationTime = a.CreationTime,
                                         CurrencyName = a.CurrencyName,
                                         CBOSID = a.CBOSID,
                                         DataEntereerName = a.DataEntereerName,
                                         DocArrivalDate = a.DocArrivalDate,
                                         ExporterCountry = a.ExporterCountry,
                                         ExporterCountryName = a.ExporterCountryName,
                                         FirstApprovalName = a.FirstApprovalName,
                                         FullNameArabic = a.FullNameArabic,
                                         OperationAmountRemaining = a.OperationAmountRemaining,
                                         PaymentTypeName = a.PaymentTypeName,
                                         ExporterName = a.ExporterName,
                                         BankNameAR = a.BankNameAR,
                                         CurrencyShortName = a.CurrencyName,
                                         BranchNameAR = a.BranchNameAR,
                                         ImportersRegister = a.ImportersRegister,
                                         RefNumber = a.RefNumber,
                                         OperationCode = a.OperationCode,
                                         OperationDate = a.OperationDate,
                                         Notes = a.Notes,
                                         TotalValue = a.TotalValue,
                                         TotalValueUSD = a.TotalValueUSD,
                                         FlowStatus = a.FlowStatus,
                                         ImportPurposeName = a.ImportPurposeName,
                                         TaxNo = a.TaxNo,
                                         Currency = a.Currency,
                                         ImportPurpose = a.ImportPurpose,
                                         PaymentType = a.PaymentType,
                                         SecondApprovalName = a.SecondApprovalName,
                                         Bank = a.Bank,
                                         Branch = a.Branch,
                                         RejectionNotes = a.RejectionNotes
                                     }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (Operation.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Operation);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





        }





    }


}
