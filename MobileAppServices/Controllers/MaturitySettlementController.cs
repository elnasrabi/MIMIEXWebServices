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
    public class MaturitySettlementController : ApiController
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





        [Route("api/MaturitySettlement/getMaturitySettlement")]
        public async Task<IHttpActionResult> GetMaturitySettlementByCode(string loginname, string password, long maturitysettlementcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.LoginName == loginname && a.Password == password && a.MaturitySettlementCode == maturitysettlementcode
                                          select new MaturitySettlementDTO
                                {
                                     LoginName = a.LoginName,FullName=a.f,
                                    ActionTime = a.ActionTime,
                                    Amount = a.Amount,
                                    AmountUSD = a.AmountUSD,
                                    CurrencyShortName = a.CurrencyShortName,
                                    FormCode = a.FormCode,
                                    MaturitySettlementCode = a.MaturitySettlementCode,
                                    MaturityCode = a.MaturityCode,
                                    MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                    FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                    FlowStatus = a.FlowStatus
                                }).ToList();

                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else if (utype ==2)
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.BankBranch == userbranch && a.Bank == userorg && a.MaturitySettlementCode == maturitysettlementcode
                                          select new MaturitySettlementDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();

                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else 
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.MaturitySettlementCode == maturitysettlementcode
                                          select new MaturitySettlementDTO
                                          {
                                              LoginName = a.LoginName,
                                              FullName = a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();

                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }


        }

        [Route("api/MaturitySettlement/getMaturitySettlementByMaturity")]
        public async Task<IHttpActionResult> GetMaturitySettlementByMaturity(string loginname, string password, long maturitycode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.LoginName == loginname && a.Password == password && a.MaturityCode == maturitycode
                                          select new MaturitySettlementDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();

                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else if (utype == 2)
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.BankBranch == userbranch && a.Bank == userorg && a.MaturityCode == maturitycode
                                          select new MaturitySettlementDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();
                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where  a.MaturityCode == maturitycode
                                          select new MaturitySettlementDTO
                                          {
                                              LoginName = a.LoginName,
                                              FullName = a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes = a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();
                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }


        }


    


        [Route("api/MaturitySettlement/getMaturitySettlementByForm")]
        public async Task<IHttpActionResult> GetMaturitySettlementByForm(string loginname, string password, long formcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.LoginName == loginname && a.Password == password && a.FormCode == formcode
                                          select new MaturitySettlementDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              RejectionNotes=a.RejectionNotes,
                                              PaymentDate = a.PaymentDate,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();
                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else if (utype == 2)
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where a.BankBranch == userbranch && a.Bank == userorg && a.FormCode == formcode
                                          select new MaturitySettlementDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              PaymentDate = a.PaymentDate,
                                              RejectionNotes = a.RejectionNotes,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();
                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }
            else 
            {
                var MaturitySettlement = (from a in dc.vMaturitySettlement
                                          where  a.FormCode == formcode
                                          select new MaturitySettlementDTO
                                          {
                                              LoginName = a.LoginName,
                                              FullName = a.FullName,
                                              ActionTime = a.ActionTime,
                                              Amount = a.Amount,
                                              AmountUSD = a.AmountUSD,
                                              CurrencyShortName = a.CurrencyShortName,
                                              FormCode = a.FormCode,
                                              MaturitySettlementCode = a.MaturitySettlementCode,
                                              MaturityCode = a.MaturityCode,
                                              MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                              FlowStatusNameIM = a.FlowStatusNameIM,
                                              PaymentDate = a.PaymentDate,
                                              RejectionNotes = a.RejectionNotes,
                                              FlowStatus = a.FlowStatus
                                          }).ToList();
                if (MaturitySettlement.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(MaturitySettlement);

            }


        }


        [Route("api/MaturitySettlement/getAllMaturitySettlement")]
        public async Task<IHttpActionResult> GetMaturitySettlementByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {
                    var MaturitySettlement = (from a in dc.vMaturitySettlement
                                              where a.LoginName == loginname && a.Password == password 
                                              select new MaturitySettlementDTO
                                              {
                                                   LoginName = a.LoginName,FullName=a.FullName,
                                                  ActionTime = a.ActionTime,
                                                  Amount = a.Amount,
                                                  AmountUSD = a.AmountUSD,
                                                  CurrencyShortName = a.CurrencyShortName,
                                                  FormCode = a.FormCode,
                                                  MaturitySettlementCode = a.MaturitySettlementCode,
                                                  MaturityCode = a.MaturityCode,
                                                  MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                                  FlowStatusNameIM = a.FlowStatusNameIM,
                                                  RejectionNotes = a.RejectionNotes,
                                                  PaymentDate = a.PaymentDate,
                                                  FlowStatus = a.FlowStatus
                                              }).ToList().Where(x => x.PaymentDate >= dtFrom && x.PaymentDate <= dtTo).Take(20);

                    if (MaturitySettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(MaturitySettlement);
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
                    var MaturitySettlement = (from a in dc.vMaturitySettlement
                                              where a.BankBranch == userbranch && a.Bank == userorg
                                              select new MaturitySettlementDTO
                                              {
                                                   LoginName = a.LoginName,FullName=a.FullName,
                                                  ActionTime = a.ActionTime,
                                                  Amount = a.Amount,
                                                  AmountUSD = a.AmountUSD,
                                                  CurrencyShortName = a.CurrencyShortName,
                                                  FormCode = a.FormCode,
                                                  MaturitySettlementCode = a.MaturitySettlementCode,
                                                  MaturityCode = a.MaturityCode,
                                                  MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                                  FlowStatusNameIM = a.FlowStatusNameIM,
                                                  RejectionNotes = a.RejectionNotes,
                                                  PaymentDate = a.PaymentDate,
                                                  FlowStatus = a.FlowStatus
                                              }).ToList().Where(x => x.PaymentDate >= dtFrom && x.PaymentDate <= dtTo).Take(20);
                    if (MaturitySettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(MaturitySettlement);
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
                    var MaturitySettlement = (from a in dc.vMaturitySettlement
                                           
                                              select new MaturitySettlementDTO
                                              {
                                                  LoginName = a.LoginName,
                                                  FullName = a.FullName,
                                                  ActionTime = a.ActionTime,
                                                  Amount = a.Amount,
                                                  AmountUSD = a.AmountUSD,
                                                  CurrencyShortName = a.CurrencyShortName,
                                                  FormCode = a.FormCode,
                                                  MaturitySettlementCode = a.MaturitySettlementCode,
                                                  MaturityCode = a.MaturityCode,
                                                  MaturitySettlementTypeDesc = a.MaturitySettlementTypeDesc,
                                                  FlowStatusNameIM = a.FlowStatusNameIM,
                                                  RejectionNotes = a.RejectionNotes,
                                                  PaymentDate = a.PaymentDate,
                                                  FlowStatus = a.FlowStatus
                                              }).ToList().Where(x => x.PaymentDate >= dtFrom && x.PaymentDate <= dtTo).Take(20);
                    if (MaturitySettlement.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(MaturitySettlement);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





        }








      











    }


}
