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
    public class LicenseController : ApiController
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





        [Route("api/License/getLicense")]
        public async Task<IHttpActionResult> GetLicenseRequestByCode(string loginname, string password, long licensecode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var LicenseRequest = (from a in dc.vLicense
                                where a.LoginName == loginname && a.Password == password && a.LicenseCode == licensecode
                                select new LicenseDTO
                                {
                                     LoginName = a.LoginName,FullName=a.FullName,
                                    CBOSID = a.CBOSID,
                                    LicenseCode = a.LicenseCode,
                                    TotalValueUSD = a.TotalValueUSD,
                                    FlowStatusNameLicense = a.FlowStatusNameLicense,
                                    FullNameArabic = a.FullNameArabic,
                                    CountryNameAR = a.CountryNameAR,
                                    LoadingPortNameAr = a.LoadingPortNameAr,
                                    LicensePurposeNameAr = a.LicensePurposeNameAr,
                                    CreationTime = a.CreationTime,
                                    RejectionNotes = a.RejectionNotes,
                                    ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                    ExpirationDate = a.ExpirationDate,
                                    BankNameAR = a.BankNameAR,
                                    BranchNameAR = a.BranchNameAR,
                                    DataEnterer = a.DataEnterer,
                                    RegistrationNumber = a.RegistrationNumber,
                                    TotalValue = a.TotalValue,
                                }).ToList();


                if (LicenseRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(LicenseRequest);

            }
            else if (utype == 2)
            {

                var LicenseRequest = (from a in dc.vLicense
                                      where a.BankBranch == userbranch && a.Bank == userorg && a.LicenseCode == licensecode
                                      select new LicenseDTO
                                      {
                                           LoginName = a.LoginName,FullName=a.FullName,
                                          CBOSID = a.CBOSID,
                                          LicenseCode = a.LicenseCode,
                                          TotalValueUSD = a.TotalValueUSD,
                                          FlowStatusNameLicense = a.FlowStatusNameLicense,
                                          FullNameArabic = a.FullNameArabic,
                                          CountryNameAR = a.CountryNameAR,
                                          LoadingPortNameAr = a.LoadingPortNameAr,
                                          LicensePurposeNameAr = a.LicensePurposeNameAr,
                                          CreationTime = a.CreationTime,
                                          RejectionNotes = a.RejectionNotes,
                                          ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                          ExpirationDate = a.ExpirationDate,
                                          BankNameAR = a.BankNameAR,
                                          BranchNameAR = a.BranchNameAR,
                                          DataEnterer = a.DataEnterer,
                                          RegistrationNumber = a.RegistrationNumber,
                                          TotalValue = a.TotalValue,
                                      }).ToList();
                if (LicenseRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(LicenseRequest);

            }
            else 
            {

                var LicenseRequest = (from a in dc.vLicense
                                      where a.LicenseCode == licensecode
                                      select new LicenseDTO
                                      {
                                          LoginName = a.LoginName,
                                          FullName = a.FullName,
                                          CBOSID = a.CBOSID,
                                          LicenseCode = a.LicenseCode,
                                          TotalValueUSD = a.TotalValueUSD,
                                          FlowStatusNameLicense = a.FlowStatusNameLicense,
                                          FullNameArabic = a.FullNameArabic,
                                          CountryNameAR = a.CountryNameAR,
                                          LoadingPortNameAr = a.LoadingPortNameAr,
                                          LicensePurposeNameAr = a.LicensePurposeNameAr,
                                          CreationTime = a.CreationTime,
                                          RejectionNotes = a.RejectionNotes,
                                          ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                          ExpirationDate = a.ExpirationDate,
                                          BankNameAR = a.BankNameAR,
                                          BranchNameAR = a.BranchNameAR,
                                          DataEnterer = a.DataEnterer,
                                          RegistrationNumber = a.RegistrationNumber,
                                          TotalValue = a.TotalValue,
                                      }).ToList();
                if (LicenseRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(LicenseRequest);

            }


        }

        [Route("api/License/getAllLicense")]
        public async Task<IHttpActionResult> GetLicenseRequestByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                  
                         var LicenseRequest = (from a in dc.vLicense
                                               where a.LoginName == loginname && a.Password == password 
                                               select new LicenseDTO
                                               {
                                                    LoginName = a.LoginName,FullName=a.FullName,
                                                   CBOSID = a.CBOSID,
                                                   LicenseCode = a.LicenseCode,
                                                   TotalValueUSD = a.TotalValueUSD,
                                                   FlowStatusNameLicense = a.FlowStatusNameLicense,
                                                   FullNameArabic = a.FullNameArabic,
                                                   CountryNameAR = a.CountryNameAR,
                                                   LoadingPortNameAr = a.LoadingPortNameAr,
                                                   LicensePurposeNameAr = a.LicensePurposeNameAr,
                                                   CreationTime = a.CreationTime,
                                                   RejectionNotes = a.RejectionNotes,
                                                   ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                                   ExpirationDate = a.ExpirationDate,
                                                   BankNameAR = a.BankNameAR,
                                                   BranchNameAR = a.BranchNameAR,
                                                   DataEnterer = a.DataEnterer,
                                                   RegistrationNumber = a.RegistrationNumber,
                                                   TotalValue = a.TotalValue,
                                               }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (LicenseRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(LicenseRequest);
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

                         var LicenseRequest = (from a in dc.vLicense
                                               where a.BankBranch == userbranch && a.Bank == userorg
                                               select new LicenseDTO
                                               {
                                                    LoginName = a.LoginName,FullName=a.FullName,
                                                   CBOSID = a.CBOSID,
                                                   LicenseCode = a.LicenseCode,
                                                   TotalValueUSD = a.TotalValueUSD,
                                                   FlowStatusNameLicense = a.FlowStatusNameLicense,
                                                   FullNameArabic = a.FullNameArabic,
                                                   CountryNameAR = a.CountryNameAR,
                                                   LoadingPortNameAr = a.LoadingPortNameAr,
                                                   LicensePurposeNameAr = a.LicensePurposeNameAr,
                                                   CreationTime = a.CreationTime,
                                                   RejectionNotes = a.RejectionNotes,
                                                   ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                                   ExpirationDate = a.ExpirationDate,
                                                   BankNameAR = a.BankNameAR,
                                                   BranchNameAR = a.BranchNameAR,
                                                   DataEnterer = a.DataEnterer,
                                                   RegistrationNumber = a.RegistrationNumber,
                                                   TotalValue = a.TotalValue,
                                               }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (LicenseRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(LicenseRequest);
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

                    var LicenseRequest = (from a in dc.vLicense
                                        
                                          select new LicenseDTO
                                          {
                                              LoginName = a.LoginName,
                                              FullName = a.FullName,
                                              CBOSID = a.CBOSID,
                                              LicenseCode = a.LicenseCode,
                                              TotalValueUSD = a.TotalValueUSD,
                                              FlowStatusNameLicense = a.FlowStatusNameLicense,
                                              FullNameArabic = a.FullNameArabic,
                                              CountryNameAR = a.CountryNameAR,
                                              LoadingPortNameAr = a.LoadingPortNameAr,
                                              LicensePurposeNameAr = a.LicensePurposeNameAr,
                                              CreationTime = a.CreationTime,
                                              RejectionNotes = a.RejectionNotes,
                                              ValidityPeriodNameAR = a.ValidityPeriodNameAR,
                                              ExpirationDate = a.ExpirationDate,
                                              BankNameAR = a.BankNameAR,
                                              BranchNameAR = a.BranchNameAR,
                                              DataEnterer = a.DataEnterer,
                                              RegistrationNumber = a.RegistrationNumber,
                                              TotalValue = a.TotalValue,
                                          }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo).Take(20);
                    if (LicenseRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(LicenseRequest);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }




        }



    }


}
