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
    public class ContractController : ApiController
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


       



        [Route("api/Contract/getContract")]
        public async Task<IHttpActionResult> GetContractByCode(string loginname, string password, long contractcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var Contract = (from a in dc.vContract
                             where a.LoginName == loginname && a.Password == password && a.ContractCode == contractcode
                                select new ContractDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullNameArabic,
                                 ArrivalPort = a.ArrivalPort,
                                 ContractCode = a.ContractCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 FlowStatusNameContract = a.FlowStatusNameContract,
                                 FullNameArabic = a.FullNameArabic,
                                 CountryNameAR = a.CountryNameAR,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 Notes = a.Notes,
                                 CreationTime = a.CreationTime,
                                 RejectionNotes = a.RejectionNotes,
                                 CreationDateString = a.CreationDateString,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 DataEntereer = a.DataEntereer,
                                 FirstApproval = a.FirstApproval,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApproval = a.SecondApproval,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 TaxNo = a.TaxNo,
                                 TotalValue = a.TotalValue,
                                 ExpirationDateString = a.ExpirationDateString,
                                 LoadingPortShortName = a.LoadingPortShortName,
                                 FullNameEnglish = a.FullNameEnglish
                                }).ToList();

                if (Contract.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Contract);

            }
            else if ( utype == 2)
            {
              


                var Contract = (from a in dc.vContract
                                where a.BankBranch == userbranch && a.Bank == userorg && a.ContractCode == contractcode
                                select new ContractDTO
                                {
                                     LoginName = a.LoginName,FullName=a.FullNameArabic,
                                    ArrivalPort = a.ArrivalPort,
                                    ContractCode = a.ContractCode,
                                    CurrencyShortName = a.CurrencyShortName,
                                    FlowStatusNameContract = a.FlowStatusNameContract,
                                    FullNameArabic = a.FullNameArabic,
                                    CountryNameAR = a.CountryNameAR,
                                    LoadingPortNameAr = a.LoadingPortNameAr,
                                    Notes = a.Notes,
                                    CreationTime = a.CreationTime,
                                    RejectionNotes = a.RejectionNotes,
                                    CreationDateString = a.CreationDateString,
                                    ExpirationDate = a.ExpirationDate,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    DataEntereer = a.DataEntereer,
                                    FirstApproval = a.FirstApproval,
                                    ImporterAddress = a.ImporterAddress,
                                    ImporterName = a.ImporterName,
                                    RegistrationNumber = a.RegistrationNumber,
                                    SecondApproval = a.SecondApproval,
                                    ShipingTypeNameAR = a.ShipingTypeNameAR,
                                    TaxNo = a.TaxNo,
                                    TotalValue = a.TotalValue,
                                    ExpirationDateString = a.ExpirationDateString,
                                    LoadingPortShortName = a.LoadingPortShortName,
                                    FullNameEnglish = a.FullNameEnglish
                                }).ToList();

                if (Contract.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Contract);

            }
            else 
            {



                var Contract = (from a in dc.vContract
                                where  a.ContractCode == contractcode
                                select new ContractDTO
                                {
                                    LoginName = a.LoginName,
                                    FullName = a.FullNameArabic,
                                    ArrivalPort = a.ArrivalPort,
                                    ContractCode = a.ContractCode,
                                    CurrencyShortName = a.CurrencyShortName,
                                    FlowStatusNameContract = a.FlowStatusNameContract,
                                    FullNameArabic = a.FullNameArabic,
                                    CountryNameAR = a.CountryNameAR,
                                    LoadingPortNameAr = a.LoadingPortNameAr,
                                    Notes = a.Notes,
                                    CreationTime = a.CreationTime,
                                    RejectionNotes = a.RejectionNotes,
                                    CreationDateString = a.CreationDateString,
                                    ExpirationDate = a.ExpirationDate,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    DataEntereer = a.DataEntereer,
                                    FirstApproval = a.FirstApproval,
                                    ImporterAddress = a.ImporterAddress,
                                    ImporterName = a.ImporterName,
                                    RegistrationNumber = a.RegistrationNumber,
                                    SecondApproval = a.SecondApproval,
                                    ShipingTypeNameAR = a.ShipingTypeNameAR,
                                    TaxNo = a.TaxNo,
                                    TotalValue = a.TotalValue,
                                    ExpirationDateString = a.ExpirationDateString,
                                    LoadingPortShortName = a.LoadingPortShortName,
                                    FullNameEnglish = a.FullNameEnglish
                                }).ToList();

                if (Contract.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(Contract);

            }


        }

        [Route("api/Contract/getAllContract")]
        public async Task<IHttpActionResult> GetContractByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {



                    var Contract = (from a in dc.vContract
                                    where a.LoginName == loginname && a.Password == password
                                    select new ContractDTO
                                    {
                                        LoginName = a.LoginName,
                                        FullName = a.FullNameArabic,
                                        ArrivalPort = a.ArrivalPort,
                                        ContractCode = a.ContractCode,
                                        CurrencyShortName = a.CurrencyShortName,
                                        FlowStatusNameContract = a.FlowStatusNameContract,
                                        FullNameArabic = a.FullNameArabic,
                                        CountryNameAR = a.CountryNameAR,
                                        LoadingPortNameAr = a.LoadingPortNameAr,
                                        Notes = a.Notes,
                                        CreationTime = a.CreationTime,
                                        RejectionNotes = a.RejectionNotes,
                                        CreationDateString = a.CreationDateString,
                                        ExpirationDate = a.ExpirationDate,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        DataEntereer = a.DataEntereer,
                                        FirstApproval = a.FirstApproval,
                                        ImporterAddress = a.ImporterAddress,
                                        ImporterName = a.ImporterName,
                                        RegistrationNumber = a.RegistrationNumber,
                                        SecondApproval = a.SecondApproval,
                                        ShipingTypeNameAR = a.ShipingTypeNameAR,
                                        TaxNo = a.TaxNo,
                                        TotalValue = a.TotalValue,
                                        ExpirationDateString = a.ExpirationDateString,
                                        LoadingPortShortName = a.LoadingPortShortName,
                                        FullNameEnglish = a.FullNameEnglish
                                    }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);

                    if (Contract.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Contract);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }


            }
            else if(utype==2)
            {
                try
                {

                    var Contract = (from a in dc.vContract
                                    where a.BankBranch == userbranch && a.Bank == userorg
                                    select new ContractDTO
                                    {
                                        LoginName = a.LoginName,
                                        FullName = a.FullNameArabic,
                                        ArrivalPort = a.ArrivalPort,
                                        ContractCode = a.ContractCode,
                                        CurrencyShortName = a.CurrencyShortName,
                                        FlowStatusNameContract = a.FlowStatusNameContract,
                                        FullNameArabic = a.FullNameArabic,
                                        CountryNameAR = a.CountryNameAR,
                                        LoadingPortNameAr = a.LoadingPortNameAr,
                                        Notes = a.Notes,
                                        CreationTime = a.CreationTime,
                                        RejectionNotes = a.RejectionNotes,
                                        CreationDateString = a.CreationDateString,
                                        ExpirationDate = a.ExpirationDate,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        DataEntereer = a.DataEntereer,
                                        FirstApproval = a.FirstApproval,
                                        ImporterAddress = a.ImporterAddress,
                                        ImporterName = a.ImporterName,
                                        RegistrationNumber = a.RegistrationNumber,
                                        SecondApproval = a.SecondApproval,
                                        ShipingTypeNameAR = a.ShipingTypeNameAR,
                                        TaxNo = a.TaxNo,
                                        TotalValue = a.TotalValue,
                                        ExpirationDateString = a.ExpirationDateString,
                                        LoadingPortShortName = a.LoadingPortShortName,
                                        FullNameEnglish = a.FullNameEnglish
                                    }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (Contract.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Contract);
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

                    var Contract = (from a in dc.vContract
                                 
                                    select new ContractDTO
                                    {
                                        LoginName = a.LoginName,
                                        FullName = a.FullNameArabic,
                                        ArrivalPort = a.ArrivalPort,
                                        ContractCode = a.ContractCode,
                                        CurrencyShortName = a.CurrencyShortName,
                                        FlowStatusNameContract = a.FlowStatusNameContract,
                                        FullNameArabic = a.FullNameArabic,
                                        CountryNameAR = a.CountryNameAR,
                                        LoadingPortNameAr = a.LoadingPortNameAr,
                                        Notes = a.Notes,
                                        CreationTime = a.CreationTime,
                                        RejectionNotes = a.RejectionNotes,
                                        CreationDateString = a.CreationDateString,
                                        ExpirationDate = a.ExpirationDate,
                                        BankNameAR = a.BankNameAR,
                                        BranchNameAR = a.BranchNameAR,
                                        DataEntereer = a.DataEntereer,
                                        FirstApproval = a.FirstApproval,
                                        ImporterAddress = a.ImporterAddress,
                                        ImporterName = a.ImporterName,
                                        RegistrationNumber = a.RegistrationNumber,
                                        SecondApproval = a.SecondApproval,
                                        ShipingTypeNameAR = a.ShipingTypeNameAR,
                                        TaxNo = a.TaxNo,
                                        TotalValue = a.TotalValue,
                                        ExpirationDateString = a.ExpirationDateString,
                                        LoadingPortShortName = a.LoadingPortShortName,
                                        FullNameEnglish = a.FullNameEnglish
                                    }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (Contract.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(Contract);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





        }



    }


}
