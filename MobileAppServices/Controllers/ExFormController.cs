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
    public class ExFormController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<ExForm> oneform = new List<ExForm>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ExForms.Where(a => a.FormNo.Equals(formno)).ToList().Distinct();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}


        static int? userorg = 0;
        static int? userbranch = 0;
        public int GetUserType(string loginname, string password)
        {
            int usertype = 1; //bank

            MIMEXEntities dc = new MIMEXEntities();


            var result = (from a in dc.IMEXUser
                          where a.LoginName == loginname && a.Password == password
                          select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList().Distinct();


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




  

        [Route("api/ExForm/getExform")]
        public async Task<IHttpActionResult> getExform(string loginname, string password,long formno)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                var forms = (from a in dc.vExForm
                             where a.LoginName == loginname && a.Password == password && a.FormCode == formno
                             select new ExFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();

                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }
            else if(utype==2)
            {

                var forms = (from a in dc.vExForm
                             where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formno
                             select new ExFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);
                
            }
            else 
            {

                var forms = (from a in dc.vExForm
                             where  a.FormCode == formno
                             select new ExFormDTO
                             {
                                 LoginName = a.LoginName,
                                 FullName = a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }


        }



        [Route("api/ExForm/getContractForms")]
        public async Task<IHttpActionResult> GetContractForms(string loginname, string password, long contractcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {


                var forms = (from a in dc.vExForm
                             where a.LoginName == loginname && a.Password == password && a.Contract == contractcode
                             select new ExFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();

                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }
            else if(utype==2)
            {



                var forms = (from a in dc.vExForm
                             where a.BankBranch == userbranch && a.Bank == userorg && a.Contract == contractcode
                             select new ExFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);



            }
            else 
            {



                var forms = (from a in dc.vExForm
                             where  a.Contract == contractcode
                             select new ExFormDTO
                             {
                                 LoginName = a.LoginName,
                                 FullName = a.FullName,
                                 ArrivalPort = a.ArrivalPort,
                                 BankSerial = a.BankSerial,
                                 CBOSID = a.CBOSID,
                                 Contract = a.Contract,
                                 FormCode = a.FormCode,
                                 CurrencyShortName = a.CurrencyShortName,
                                 CountryNameAR = a.CountryNameAR,
                                 ContractTotal = a.ContractTotal,
                                 CreationDate = a.CreationDate,
                                 CreationTime = a.CreationTime,
                                 Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                 DataEntereerName = a.DataEntereerName,
                                 ExpirationDate = a.ExpirationDate,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 FullNameAR = a.FullNameAR,
                                 FlowStatusNameEX = a.FlowStatusNameEX,
                                 ImporterAddress = a.ImporterAddress,
                                 ImporterName = a.ImporterName,
                                 RegistrationNumber = a.RegistrationNumber,
                                 SecondApprovalName = a.SecondApprovalName,
                                 ShipingTypeNameAR = a.ShipingTypeNameAR,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus,
                                 FirstApprovalName = a.FirstApprovalName
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);



            }


        }


        [Route("api/ExForm/getAllExForm")]
        public async Task<IHttpActionResult> getAllExForm(string loginname, string password, DateTime fromdate , DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                    var forms = (from a in dc.vExForm
                                 where a.LoginName == loginname && a.Password == password 
                                 select new ExFormDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     ArrivalPort = a.ArrivalPort,
                                     BankSerial = a.BankSerial,
                                     CBOSID = a.CBOSID,
                                     Contract = a.Contract,
                                     FormCode = a.FormCode,
                                     CurrencyShortName=a.CurrencyShortName,
                                     CountryNameAR = a.CountryNameAR,
                                     ContractTotal = a.ContractTotal,
                                     CreationDate = a.CreationDate,
                                     CreationTime = a.CreationTime,
                                     Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                     DataEntereerName = a.DataEntereerName,
                                     ExpirationDate = a.ExpirationDate,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     FullNameAR = a.FullNameAR,
                                     FlowStatusNameEX = a.FlowStatusNameEX,
                                     ImporterAddress = a.ImporterAddress,
                                     ImporterName = a.ImporterName,
                                     RegistrationNumber = a.RegistrationNumber,
                                     SecondApprovalName = a.SecondApprovalName,
                                     ShipingTypeNameAR = a.ShipingTypeNameAR,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     FirstApprovalName = a.FirstApprovalName
                                 }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (forms.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(forms);
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
                   
                    var forms = (from a in dc.vExForm
                                 where a.BankBranch == userbranch && a.Bank == userorg
                                 select new ExFormDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     ArrivalPort = a.ArrivalPort,
                                     BankSerial = a.BankSerial,
                                     CBOSID = a.CBOSID,
                                     Contract = a.Contract,
                                     FormCode = a.FormCode,
                                     CurrencyShortName = a.CurrencyShortName,
                                     CountryNameAR = a.CountryNameAR,
                                     ContractTotal = a.ContractTotal,
                                     CreationDate = a.CreationDate,
                                     CreationTime = a.CreationTime,
                                     Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                     DataEntereerName = a.DataEntereerName,
                                     ExpirationDate = a.ExpirationDate,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     FullNameAR = a.FullNameAR,
                                     FlowStatusNameEX = a.FlowStatusNameEX,
                                     ImporterAddress = a.ImporterAddress,
                                     ImporterName = a.ImporterName,
                                     RegistrationNumber = a.RegistrationNumber,
                                     SecondApprovalName = a.SecondApprovalName,
                                     ShipingTypeNameAR = a.ShipingTypeNameAR,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     FirstApprovalName = a.FirstApprovalName
                                 }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (forms.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(forms);
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

                    var forms = (from a in dc.vExForm
                             
                                 select new ExFormDTO
                                 {
                                     LoginName = a.LoginName,
                                     FullName = a.FullName,
                                     ArrivalPort = a.ArrivalPort,
                                     BankSerial = a.BankSerial,
                                     CBOSID = a.CBOSID,
                                     Contract = a.Contract,
                                     FormCode = a.FormCode,
                                     CurrencyShortName = a.CurrencyShortName,
                                     CountryNameAR = a.CountryNameAR,
                                     ContractTotal = a.ContractTotal,
                                     CreationDate = a.CreationDate,
                                     CreationTime = a.CreationTime,
                                     Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                     DataEntereerName = a.DataEntereerName,
                                     ExpirationDate = a.ExpirationDate,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     FullNameAR = a.FullNameAR,
                                     FlowStatusNameEX = a.FlowStatusNameEX,
                                     ImporterAddress = a.ImporterAddress,
                                     ImporterName = a.ImporterName,
                                     RegistrationNumber = a.RegistrationNumber,
                                     SecondApprovalName = a.SecondApprovalName,
                                     ShipingTypeNameAR = a.ShipingTypeNameAR,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus,
                                     FirstApprovalName = a.FirstApprovalName
                                 }).ToList().Where(x => x.CreationDate >= dtFrom && x.CreationDate <= dtTo).Take(20);
                    if (forms.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(forms);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }

        }





      


    }
}
