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
    public class ImFormController : ApiController
    {

        //public HttpResponseMessage Get(long formno)
        //{
        //    List<ImForm> oneform = new List<ImForm>();
        //    using (MIMEXEntities dc = new MIMEXEntities())
        //    {
        //        oneform = dc.ImForms.Where(a => a.FormNo.Equals(formno)).ToList().Distinct();
        //        HttpResponseMessage oneformresult;
        //        oneformresult = Request.CreateResponse(HttpStatusCode.OK, oneform);
        //        return oneformresult;
        //    }
        //}





        //[Route("api/ImForm/getAll/{loginname}/{password}")]
        public async Task<IHttpActionResult> Get(string loginname, string password)
        {
            MIMEXEntities dc = new MIMEXEntities();


            var result = (from a in dc.IMEXUser
                          where a.LoginName == loginname && a.Password == password
                          select new IMEXUserDto { LoginName = a.LoginName, FullName = a.FullName, MobileNo = a.MobileNo, CBOSID = a.CBOSID, UserType = a.UserType }).ToList().Distinct();


            if (result.Count() ==0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        int? userorg = 0;
        int? userbranch = 0;
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



        [Route("api/ImForm/getImform")]
        public async Task<IHttpActionResult> getImform(string loginname, string password,long formno)
        {
            MIMEXEntities dc = new MIMEXEntities();

            int utype = GetUserType(loginname, password);

            if(utype==1)
            {

                var forms = (from a in dc.vImForm
                             where a.LoginName == loginname && a.Password == password && a.FormCode == formno
                             select new ImFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }
            else if(utype==2)
            {

                var forms = (from a in dc.vImForm
                             where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formno
                             select new ImFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();

                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }
            else 
            {

                var forms = (from a in dc.vImForm
                             where  a.FormCode == formno
                             select new ImFormDTO
                             {
                                 LoginName = a.LoginName,
                                 FullName = a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();

                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }


        }


        [Route("api/ImForm/getOperationForms")]
        public async Task<IHttpActionResult> getOperationForms(string loginname, string password, long operationcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {


                var forms = (from a in dc.vImForm
                             where a.LoginName == loginname && a.Password == password && a.Operation == operationcode
                             select new ImFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();

                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);

            }
            else if(utype==2)
            {



                var forms = (from a in dc.vImForm
                             where a.BankBranch == userbranch && a.Bank == userorg && a.Operation == operationcode
                             select new ImFormDTO
                             {
                                  LoginName = a.LoginName,FullName=a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);



            }

            else 
            {



                var forms = (from a in dc.vImForm
                             where  a.Operation == operationcode
                             select new ImFormDTO
                             {
                                 LoginName = a.LoginName,
                                 FullName = a.FullName,
                                 CarrierTypeNameAr = a.CarrierTypeNameAr,
                                 FullNameAr = a.DataEntererName,
                                 CBOSID = a.CBOSID,
                                 Operation = a.Operation,
                                 FormCode = a.FormCode,
                                 CountryNameAR = a.CountryNameAR,
                                 BillOfLading = a.BillOfLading,
                                 CreationDate = a.CreationDate,
                                 CurrencyShortName = a.CurrencyShortName,
                                 LoadingPortNameAr = a.LoadingPortNameAr,
                                 FlowStatusNameIM = a.FlowStatusNameIM,
                                 ExporterName = a.ExporterName,
                                 BankNameAR = a.BankNameAR,
                                 BranchNameAR = a.BranchNameAR,
                                 ImportersRegister = a.ImportersRegister,
                                 TaxNumber = a.TaxNumber,
                                 UserType = a.UserType,
                                 LoadingPort = a.LoadingPort,
                                 Note = a.Note,
                                 TotalValue = a.TotalValue,
                                 TotalValueUSD = a.TotalValueUSD,
                                 FlowStatus = a.FlowStatus
                             }).ToList().Distinct();
                if (forms.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(forms);



            }


        }

        [Route("api/ImForm/getAllImForm")]
        public async Task<IHttpActionResult> getAllImForm(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                    var forms = (from a in dc.vImForm
                                 where a.LoginName == loginname && a.Password == password
                                 select new ImFormDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CarrierTypeNameAr = a.CarrierTypeNameAr,
                                     FullNameAr = a.DataEntererName,
                                     CBOSID = a.CBOSID,
                                     Operation = a.Operation,
                                     FormCode = a.FormCode,
                                     CountryNameAR = a.CountryNameAR,
                                     BillOfLading = a.BillOfLading,
                                     CreationDate = a.CreationDate,
                                     CurrencyShortName = a.CurrencyShortName,
                                     LoadingPortNameAr = a.LoadingPortNameAr,
                                     FlowStatusNameIM = a.FlowStatusNameIM,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     TaxNumber = a.TaxNumber,
                                     UserType = a.UserType,
                                     LoadingPort = a.LoadingPort,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus
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

                    var forms = (from a in dc.vImForm
                                 where a.BankBranch == userbranch && a.Bank == userorg
                                 select new ImFormDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CarrierTypeNameAr = a.CarrierTypeNameAr,
                                     FullNameAr = a.DataEntererName,
                                     CBOSID = a.CBOSID,
                                     Operation = a.Operation,
                                     FormCode = a.FormCode,
                                     CountryNameAR = a.CountryNameAR,
                                     BillOfLading = a.BillOfLading,
                                     CreationDate = a.CreationDate,
                                     CurrencyShortName = a.CurrencyShortName,
                                     LoadingPortNameAr = a.LoadingPortNameAr,
                                     FlowStatusNameIM = a.FlowStatusNameIM,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     TaxNumber = a.TaxNumber,
                                     UserType = a.UserType,
                                     LoadingPort = a.LoadingPort,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus
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

                    var forms = (from a in dc.vImForm
                                
                                 select new ImFormDTO
                                 {
                                     LoginName = a.LoginName,
                                     FullName = a.FullName,
                                     CarrierTypeNameAr = a.CarrierTypeNameAr,
                                     FullNameAr = a.DataEntererName,
                                     CBOSID = a.CBOSID,
                                     Operation = a.Operation,
                                     FormCode = a.FormCode,
                                     CountryNameAR = a.CountryNameAR,
                                     BillOfLading = a.BillOfLading,
                                     CreationDate = a.CreationDate,
                                     CurrencyShortName = a.CurrencyShortName,
                                     LoadingPortNameAr = a.LoadingPortNameAr,
                                     FlowStatusNameIM = a.FlowStatusNameIM,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     TaxNumber = a.TaxNumber,
                                     UserType = a.UserType,
                                     LoadingPort = a.LoadingPort,
                                     Note = a.Note,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatus = a.FlowStatus
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
