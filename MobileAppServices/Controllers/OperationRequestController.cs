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
    public class OperationRequestController : ApiController
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



        // [Route(" api/OperationRequest/getAllOperationRequest")]


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




             [Route("api/OperationRequest/getOperationRequest")]
    public async Task<IHttpActionResult> GetOperationRequestByCode(string loginname, string password, long Operationrequestcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
            

                var OperationRequest = (from a in dc.vOperationRequest
                                        where a.LoginName == loginname && a.Password == password && a.OperationRequestCode == Operationrequestcode
                                        select new OperationRequestDTO
                                 {
                                      LoginName = a.LoginName,FullName=a.FullName,
                                     CreationTime = a.CreationTime,
                                     CurrencyShortName = a.CurrencyShortName,
                                     CBOSID = a.CBOSID,
                                     CountryCode = a.CountryCode,
                                     CurrencyCode = a.CurrencyCode,
                                     BankBranch = a.Bank,
                                     BranchCode = a.BranchCode,
                                     DocArrivalDate = a.DocArrivalDate,
                                     ExporterCountry = a.CountryCode,
                                     CountryNameAR = a.CountryNameAR,
                                     ExporterName = a.ExporterName,
                                     BankNameAR = a.BankNameAR,
                                     BranchNameAR = a.BranchNameAR,
                                     ImportersRegister = a.ImportersRegister,
                                     OperationRequestCode = a.OperationRequestCode,
                                     OperationRequestDate = a.OperationRequestDate,
                                     Notes = a.Notes,
                                     TotalValue = a.TotalValue,
                                     TotalValueUSD = a.TotalValueUSD,
                                     FlowStatusNameIMOperation = a.FlowStatusNameIMOperation,
                                     ImportPurposeName = a.ImportPurposeName,
                                     TaxNo = a.TaxNo,
                                     Currency = a.CurrencyCode,
                                     ImportPurpose = a.ImportPurpose,
                                     Bank = a.Bank,
                                     Branch = a.Branch,
                                     RejectionNotes = a.RejectionNotes,
                                     IsTraderEditable = a.IsTraderEditable,
                                        }).ToList();

                if (OperationRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationRequest);

            }
            else
            {


                var OperationRequest = (from a in dc.vOperationRequest
                                        where a.Branch == userbranch && a.Bank == userorg && a.OperationRequestCode == Operationrequestcode
                                        select new OperationRequestDTO
                                        {
                                             LoginName = a.LoginName,FullName=a.FullName,
                                            CountryCode = a.CountryCode,
                                            CurrencyCode = a.CurrencyCode,
                                            BankBranch = a.Bank,
                                            BranchCode = a.BranchCode,
                                            CreationTime = a.CreationTime,
                                            CurrencyShortName = a.CurrencyShortName,
                                            CBOSID = a.CBOSID,
                                            IsTraderEditable = a.IsTraderEditable,
                                            DocArrivalDate = a.DocArrivalDate,
                                            ExporterCountry = a.CountryCode,
                                            CountryNameAR = a.CountryNameAR,
                                            ExporterName = a.ExporterName,
                                            BankNameAR = a.BankNameAR,
                                            BranchNameAR = a.BranchNameAR,
                                            ImportersRegister = a.ImportersRegister,
                                            OperationRequestCode = a.OperationRequestCode,
                                            OperationRequestDate = a.OperationRequestDate,
                                            Notes = a.Notes,
                                            TotalValue = a.TotalValue,
                                            TotalValueUSD = a.TotalValueUSD,
                                            FlowStatusNameIMOperation = a.FlowStatusNameIMOperation,
                                            ImportPurposeName = a.ImportPurposeName,
                                            TaxNo = a.TaxNo,
                                            Currency = a.CurrencyCode,
                                            ImportPurpose = a.ImportPurpose,
                                            Bank = a.Bank,
                                            Branch = a.Branch,
                                          
                                            RejectionNotes = a.RejectionNotes
                                        }).ToList();

                if (OperationRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(OperationRequest);

            }


        }

        [Route("api/OperationRequest/getAllOperationRequest")]
        public async Task<IHttpActionResult> GetOperationRequestByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {

                    var OperationRequest = (from a in dc.vOperationRequest
                                            where a.LoginName == loginname && a.Password == password
                                            select new OperationRequestDTO
                                            {
                                                 LoginName = a.LoginName,FullName=a.FullName,
                                                CountryCode = a.CountryCode,
                                                CurrencyCode = a.CurrencyCode,
                                                BankBranch = a.Bank,
                                                BranchCode = a.BranchCode,
                                                CreationTime = a.CreationTime,
                                                CurrencyShortName = a.CurrencyShortName,
                                                CBOSID = a.CBOSID,
                                                IsTraderEditable = a.IsTraderEditable,
                                                DocArrivalDate = a.DocArrivalDate,
                                                ExporterCountry = a.CountryCode,
                                                CountryNameAR = a.CountryNameAR,
                                                ExporterName = a.ExporterName,
                                                BankNameAR = a.BankNameAR,
                                                BranchNameAR = a.BranchNameAR,
                                                ImportersRegister = a.ImportersRegister,
                                                OperationRequestCode = a.OperationRequestCode,
                                                OperationRequestDate = a.OperationRequestDate,
                                                Notes = a.Notes,
                                                TotalValue = a.TotalValue,
                                                TotalValueUSD = a.TotalValueUSD,
                                                FlowStatusNameIMOperation = a.FlowStatusNameIMOperation,
                                                ImportPurposeName = a.ImportPurposeName,
                                                TaxNo = a.TaxNo,
                                                Currency = a.CurrencyCode,
                                                ImportPurpose = a.ImportPurpose,
                                                Bank = a.Bank,
                                                Branch = a.Branch,
                                                RejectionNotes = a.RejectionNotes
                                            }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
                    if (OperationRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(OperationRequest);
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

                    var OperationRequest = (from a in dc.vOperationRequest
                                            where a.Branch == userbranch && a.Bank == userorg
                                            select new OperationRequestDTO
                                            {
                                                 LoginName = a.LoginName,FullName=a.FullName,
                                                CountryCode=a.CountryCode,
                                                CurrencyCode=a.CurrencyCode,
                                                BankBranch=a.Bank,
                                                BranchCode=a.BranchCode,
                                                CreationTime = a.CreationTime,
                                                CurrencyShortName = a.CurrencyShortName,
                                                CBOSID = a.CBOSID,
                                                IsTraderEditable = a.IsTraderEditable,
                                                DocArrivalDate = a.DocArrivalDate,
                                                ExporterCountry = a.CountryCode,
                                                CountryNameAR = a.CountryNameAR,
                                                ExporterName = a.ExporterName,
                                                BankNameAR = a.BankNameAR,
                                                BranchNameAR = a.BranchNameAR,
                                                ImportersRegister = a.ImportersRegister,
                                                OperationRequestCode = a.OperationRequestCode,
                                                OperationRequestDate = a.OperationRequestDate,
                                                Notes = a.Notes,
                                                TotalValue = a.TotalValue,
                                                TotalValueUSD = a.TotalValueUSD,
                                                FlowStatusNameIMOperation = a.FlowStatusNameIMOperation,
                                                ImportPurposeName = a.ImportPurposeName,
                                                TaxNo = a.TaxNo,
                                                Currency = a.CurrencyCode,
                                                ImportPurpose = a.ImportPurpose,
                                                Bank = a.Bank,
                                                Branch = a.Branch,
                                                RejectionNotes = a.RejectionNotes
                                            }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
                    if (OperationRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(OperationRequest);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }





        }




        [HttpPost]
        public IHttpActionResult Post(OperationRequestViewModel OperationInfo)
        {
            OperationRequestDTO Operation = OperationInfo.operation;
         var  CommodityDetail = OperationInfo.operationCommodityDetails;
          var PMDetail = OperationInfo.operationPaymentMethodDetails;

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spNewOperatoinRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@ImportPurpose", Operation.ImportPurpose));
            cmd.Parameters.Add(new SqlParameter("@ExporterName", Operation.ExporterName));
            cmd.Parameters.Add(new SqlParameter("@ExporterCountry", Operation.ExporterCountry));
            cmd.Parameters.Add(new SqlParameter("@DocArrivalDate",Convert.ToDateTime(Operation.DocArrivalDate)));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", Operation.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", Operation.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", Operation.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", Operation.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", Operation.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", Operation.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", Operation.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToOperationRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "OperationCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

            //--------------PM------------------
            DataTable PaymentMethodDataTable = ConvertToOperationRequestPMDatatable(PMDetail);
            var PaymentMethodParam = new SqlParameter();
            PaymentMethodParam.ParameterName = "OperationPaymentMethod";
            PaymentMethodParam.SqlDbType = SqlDbType.Structured;
            PaymentMethodParam.Value = PaymentMethodDataTable;
            PaymentMethodParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(PaymentMethodParam);



            try
            {
                locConn.Open();
                cmd.ExecuteNonQuery();
                return StatusCode(HttpStatusCode.OK);


            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }



            locConn.Close();
          
        }



        [Route("api/{OperationRequest}/UpdateOperation")]
        [HttpPost]
        public IHttpActionResult Update(OperationRequestViewModel OperationInfo)
        {
            OperationRequestDTO Operation = OperationInfo.operation;
            var CommodityDetail = OperationInfo.operationCommodityDetails;
            var PMDetail = OperationInfo.operationPaymentMethodDetails;

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spUpdateOperatoinRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@OperationRequestCode", Operation.OperationRequestCode));
            cmd.Parameters.Add(new SqlParameter("@ImportPurpose", Operation.ImportPurpose));
            cmd.Parameters.Add(new SqlParameter("@ExporterName", Operation.ExporterName));
            cmd.Parameters.Add(new SqlParameter("@ExporterCountry", Operation.ExporterCountry));
            cmd.Parameters.Add(new SqlParameter("@DocArrivalDate", Convert.ToDateTime(Operation.DocArrivalDate)));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", Operation.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", Operation.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", Operation.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", Operation.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", Operation.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", Operation.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", Operation.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToOperationRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "OperationCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

            //--------------PM------------------
            DataTable PaymentMethodDataTable = ConvertToOperationRequestPMDatatable(PMDetail);
            var PaymentMethodParam = new SqlParameter();
            PaymentMethodParam.ParameterName = "OperationPaymentMethod";
            PaymentMethodParam.SqlDbType = SqlDbType.Structured;
            PaymentMethodParam.Value = PaymentMethodDataTable;
            PaymentMethodParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(PaymentMethodParam);


            try
            {
                locConn.Open();
                cmd.ExecuteNonQuery();
                return StatusCode(HttpStatusCode.OK);


            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }



            locConn.Close();

        }




        [Route("api/OperationRequest/DeleteOperation/")]
        [HttpPost]
        public IHttpActionResult DeleteOperationRequest(long Operationrequestcode)
        {


            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spDeleteOperationRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@OperationRequestCode", Operationrequestcode));


            try
            {
                locConn.Open();
                cmd.ExecuteNonQuery();
                return StatusCode(HttpStatusCode.OK);


            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }



            locConn.Close();

        }




        private static DataTable ConvertToOperationRequestCommodityDatatable(IEnumerable<OperationRequestCommodityDTO> commodity)
        {
            var commodityDetails = new DataTable();

            commodityDetails.Columns.Add("CommodityNameAR", typeof(string));
            commodityDetails.Columns.Add("CommodityCode", typeof(long));
            commodityDetails.Columns.Add("Qty", typeof(decimal));
            commodityDetails.Columns.Add("UnitPrice", typeof(decimal));
            commodityDetails.Columns.Add("InitialInvoiceNumber", typeof(string));
            commodityDetails.Columns.Add("InitialInvoiceIssuer", typeof(string));
            commodityDetails.Columns.Add("InitialInvoiceDate", typeof(DateTime));
            commodityDetails.Columns.Add("CommodityDesc", typeof(string));


            foreach (OperationRequestCommodityDTO item in commodity)
            {
                commodityDetails.Rows.Add(item.CommodityNameAR,item.CommodityCode, item.Qty, item.UnitPrice,item.InitialInvoiceNumber, item.InitialInvoiceIssuer, Convert.ToDateTime(item.InitialInvoiceDate), item.CommodityDesc);
            }

            return commodityDetails;
        }

        private static DataTable ConvertToOperationRequestPMDatatable(IEnumerable<OperationRequestPaymentMethodDTO> PM)
        {
            var PMDetails = new DataTable();

            PMDetails.Columns.Add("PaymentMethodNameAR", typeof(string));
            PMDetails.Columns.Add("PaymentMethod", typeof(long));
            PMDetails.Columns.Add("Percentage", typeof(decimal));
          


            foreach (OperationRequestPaymentMethodDTO item in PM)
            {
                PMDetails.Rows.Add(item.PaymentMethodNameAR, item.PaymentMethod, item.Percentage);
            }

            return PMDetails;
        }


        public SqlConnection getConnection()
        {

            const string serverName = "AFS-SQL01-DEV\\AFS_SQL01_DEV";
            const string dbName = "MIMEX";
            SqlConnection conn = null;
           conn = new SqlConnection("Server = tcp:mimex.database.windows.net,1433; Initial Catalog = MIMEX; Persist Security Info = False; User ID = mimex; Password = Mangooli@25; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ; MultipleActiveResultSets = True");
            //   conn.Open();
            return conn;




            //   SqlConnection con = new SqlConnection("Data Source= DEVSRV\DEVSQL;Initial Catalog=CMS;Integrated Security=True");
            //  return con;
        }

    }


}
