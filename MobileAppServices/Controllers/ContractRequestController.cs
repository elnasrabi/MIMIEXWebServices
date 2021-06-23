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
    public class ContractRequestController : ApiController
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




[Route("api/ContractRequest/getContractRequest")]
        public async Task<IHttpActionResult> GetContractRequestByCode(string loginname, string password, long contractrequestcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var ContractRequest = (from a in dc.vContractRequest
                                       where a.LoginName == loginname && a.Password == password && a.ContractRequestCode == contractrequestcode
                                       select new ContractRequestDTO
                                {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           ArrivalPort = a.ArrivalPort,
                                           ShipingTypeCode = a.ShipingTypeCode,
                                           Custom_UnitPK = a.Custom_UnitPK,
                                           CurrencyCode = a.CurrencyCode,
                                           BankBranch = a.BankBranch,
                                           Bank = a.Bank,
                                           CountryCode = a.CountryCode,
                                           ContractRequestCode = a.ContractRequestCode,
                                           CurrencyShortName = a.CurrencyShortName,
                                           FlowStatusNameContract = a.FlowStatusNameContract,
                                           CountryNameAR = a.CountryNameAR,
                                           Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                           Notes = a.Notes,
                                           CreationTime = a.CreationTime,
                                           ExpirationDate = a.ExpirationDate,
                                           BankNameAR = a.BankNameAR,
                                           BranchNameAR = a.BranchNameAR,
                                           ImporterAddress = a.ImporterAddress,
                                           ImporterName = a.ImporterName,
                                           RegistrationNumber = a.RegistrationNumber,
                                           ShipingTypeNameAR = a.ShipingTypeNameAR,
                                           TaxNo = a.TaxNo,
                                           TotalValue = a.TotalValue,
                                           IsTraderEditable = a.IsTraderEditable,
                                       }).ToList();


                if (ContractRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ContractRequest);

            }
            else
            {
               
                var ContractRequest = (from a in dc.vContractRequest
                                       where a.BankBranch == userbranch && a.Bank == userorg && a.ContractRequestCode == contractrequestcode
                                       select new ContractRequestDTO
                                       {
                                            LoginName = a.LoginName,FullName=a.FullName,
                                           ArrivalPort = a.ArrivalPort,
                                           ShipingTypeCode = a.ShipingTypeCode,
                                           Custom_UnitPK = a.Custom_UnitPK,
                                           CurrencyCode = a.CurrencyCode,
                                           BankBranch = a.BankBranch,
                                           Bank = a.Bank,
                                           CountryCode = a.CountryCode,
                                           ContractRequestCode = a.ContractRequestCode,
                                           CurrencyShortName = a.CurrencyShortName,
                                           FlowStatusNameContract = a.FlowStatusNameContract,
                                           CountryNameAR = a.CountryNameAR,
                                           Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                           Notes = a.Notes,
                                           CreationTime = a.CreationTime,
                                           ExpirationDate = a.ExpirationDate,
                                           BankNameAR = a.BankNameAR,
                                           BranchNameAR = a.BranchNameAR,
                                           ImporterAddress = a.ImporterAddress,
                                           ImporterName = a.ImporterName,
                                           RegistrationNumber = a.RegistrationNumber,
                                           ShipingTypeNameAR = a.ShipingTypeNameAR,
                                           TaxNo = a.TaxNo,
                                           TotalValue = a.TotalValue,
                                           IsTraderEditable = a.IsTraderEditable,
                                       }).ToList();
                if (ContractRequest.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(ContractRequest);

            }


        }

        [Route("api/ContractRequest/getAllContractRequest")]
        public async Task<IHttpActionResult> GetContractRequestByDate(string loginname, string password, DateTime fromdate, DateTime todate)
        {
            MIMEXEntities dc = new MIMEXEntities();
            DateTime dtFrom = Convert.ToDateTime(fromdate);
            DateTime dtTo = Convert.ToDateTime(todate);

            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                try
                {

                          var ContractRequest = (from a in dc.vContractRequest
                                                 where a.LoginName == loginname && a.Password == password
                                                 select new ContractRequestDTO
                                                 {
                                                      LoginName = a.LoginName,FullName=a.FullName,
                                                     ArrivalPort = a.ArrivalPort,
                                                     ShipingTypeCode = a.ShipingTypeCode,
                                                     Custom_UnitPK = a.Custom_UnitPK,
                                                     CurrencyCode = a.CurrencyCode,
                                                     BankBranch = a.BankBranch,
                                                     Bank = a.Bank,
                                                     CountryCode = a.CountryCode,
                                                     ContractRequestCode = a.ContractRequestCode,
                                                     CurrencyShortName = a.CurrencyShortName,
                                                     FlowStatusNameContract = a.FlowStatusNameContract,
                                                     CountryNameAR = a.CountryNameAR,
                                                     Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                                     Notes = a.Notes,
                                                     CreationTime = a.CreationTime,
                                                     ExpirationDate = a.ExpirationDate,
                                                     BankNameAR = a.BankNameAR,
                                                     BranchNameAR = a.BranchNameAR,
                                                     ImporterAddress = a.ImporterAddress,
                                                     ImporterName = a.ImporterName,
                                                     RegistrationNumber = a.RegistrationNumber,
                                                     ShipingTypeNameAR = a.ShipingTypeNameAR,
                                                     TaxNo = a.TaxNo,
                                                     TotalValue = a.TotalValue,
                                                     IsTraderEditable = a.IsTraderEditable,
                                                 }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
                    if (ContractRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ContractRequest);
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

                    var ContractRequest = (from a in dc.vContractRequest
                                           where a.BankBranch == userbranch && a.Bank == userorg
                                           select new ContractRequestDTO
                                           {
                                                LoginName = a.LoginName,FullName=a.FullName,
                                               ArrivalPort = a.ArrivalPort,
                                               ShipingTypeCode = a.ShipingTypeCode,
                                               Custom_UnitPK = a.Custom_UnitPK,
                                               CurrencyCode = a.CurrencyCode,
                                               BankBranch = a.BankBranch,
                                               Bank = a.Bank,
                                               CountryCode = a.CountryCode,
                                               ContractRequestCode = a.ContractRequestCode,
                                               CurrencyShortName = a.CurrencyShortName,
                                               FlowStatusNameContract = a.FlowStatusNameContract,
                                               CountryNameAR = a.CountryNameAR,
                                               Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                               Notes = a.Notes,
                                               CreationTime = a.CreationTime,
                                               ExpirationDate = a.ExpirationDate,
                                               BankNameAR = a.BankNameAR,
                                               BranchNameAR = a.BranchNameAR,
                                               ImporterAddress = a.ImporterAddress,
                                               ImporterName = a.ImporterName,
                                               RegistrationNumber = a.RegistrationNumber,
                                               ShipingTypeNameAR = a.ShipingTypeNameAR,
                                               TaxNo = a.TaxNo,
                                               TotalValue = a.TotalValue,
                                               IsTraderEditable = a.IsTraderEditable,
                                           }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
                    if (ContractRequest.Count() == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ContractRequest);
                }
                catch (Exception ex)
                {

                    return NotFound();
                }



            }

          
       


        }

       

        [Route("api/ContractRequest/Upload")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload(long code,string relatedobject,string documentdesc,string loginname)
        {
            var httpContext = HttpContext.Current;
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

          
            SqlConnection locConn = getConnection();

            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files  
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    if (httpPostedFile != null)
                    {
                                int iFileLength;
                        
                                iFileLength = httpPostedFile.ContentLength;
                                Byte[] inputBuffer = new Byte[iFileLength];
                                System.IO.Stream inputStream;
                                inputStream = httpPostedFile.InputStream;
                                inputStream.Read(inputBuffer, 0, iFileLength);
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(inputStream))
                        {
                            fileData = binaryReader.ReadBytes(httpPostedFile.ContentLength);
                        }

                       
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spNewSupportedDocument";
                        cmd.Connection = locConn;

                        cmd.Parameters.AddWithValue("@DocumentData", inputBuffer);
                        cmd.Parameters.AddWithValue("@DocumentName", httpPostedFile.FileName);
                        cmd.Parameters.AddWithValue("@ContentType", httpPostedFile.ContentType);
                        cmd.Parameters.AddWithValue("@FileSize", httpPostedFile.ContentLength);
                        cmd.Parameters.AddWithValue("@Code", code);
                        cmd.Parameters.AddWithValue("@RelatedObject", relatedobject);
                        cmd.Parameters.AddWithValue("@DocumentDesc", documentdesc);
                        cmd.Parameters.AddWithValue("@LoginName", loginname);
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




                            }

                            locConn.Close();
                       


                    }
              

            }
            else
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.OK);

        }

        //foreach (var file in provider.Contents)
        //{
        //     filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //     buffer = await file.ReadAsByteArrayAsync();


        //    var cmd = new SqlCommand("spNewContractRequestDocument") { Connection = locConn, CommandType = CommandType.StoredProcedure };
        //    cmd.Parameters.Add(new SqlParameter("@ContractRequestCode", contractrequestcode));
        //    cmd.Parameters.Add(new SqlParameter("@DocumentName", filename));
        //    SqlParameter param = cmd.Parameters.Add("@DocumentData", SqlDbType.VarBinary);
        //    param.Value = buffer;

        //    try
        //    {
        //        locConn.Open();
        //        cmd.ExecuteNonQuery();
        //        return StatusCode(HttpStatusCode.OK);


        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(HttpStatusCode.BadRequest);
        //    }




        //}

        //locConn.Close();






       

        [HttpPost]
        public IHttpActionResult NewContract(ContractRequestViewModel contractInfo)

        {
            ContractDTO contract = contractInfo.contract;
         var  CommodityDetail = contractInfo.contractCommodityDetails;
          var PMDetail = contractInfo.contractPaymentMethodDetails;

            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spNewContractRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LoadingPort", contract.LoadingPort));
            cmd.Parameters.Add(new SqlParameter("@ImporterName", contract.ImporterName));
            cmd.Parameters.Add(new SqlParameter("@ImporterAddress", contract.ImporterAddress));
            cmd.Parameters.Add(new SqlParameter("@Destination", contract.Destination));
            cmd.Parameters.Add(new SqlParameter("@ArrivalPort", contract.ArrivalPort));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", contract.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", contract.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", contract.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", contract.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@ShipingType", contract.ShipingType));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", contract.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", contract.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", contract.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToContractRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "ContractCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

            //--------------PM------------------
            DataTable PaymentMethodDataTable = ConvertToContractRequestPMDatatable(PMDetail);
            var PaymentMethodParam = new SqlParameter();
            PaymentMethodParam.ParameterName = "ContractPaymentMethod";
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



         [Route("api/ContractRequest/UpdateContract")]
        [HttpPost]
        public IHttpActionResult Update(ContractRequestViewModel contractInfo)
        {
            ContractDTO contract = contractInfo.contract;
            var CommodityDetail = contractInfo.contractCommodityDetails;
            var PMDetail = contractInfo.contractPaymentMethodDetails;

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spUpdateContractRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@ContractRequestCode", contract.ContractRequestCode));
            cmd.Parameters.Add(new SqlParameter("@LoadingPort", contract.LoadingPort));
            cmd.Parameters.Add(new SqlParameter("@ImporterName", contract.ImporterName));
            cmd.Parameters.Add(new SqlParameter("@ImporterAddress", contract.ImporterAddress));
            cmd.Parameters.Add(new SqlParameter("@Destination", contract.Destination));
            cmd.Parameters.Add(new SqlParameter("@ArrivalPort", contract.ArrivalPort));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", contract.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", contract.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", contract.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", contract.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@ShipingType", contract.ShipingType));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", contract.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", contract.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", contract.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToContractRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "ContractCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

            //--------------PM------------------
            DataTable PaymentMethodDataTable = ConvertToContractRequestPMDatatable(PMDetail);
            var PaymentMethodParam = new SqlParameter();
            PaymentMethodParam.ParameterName = "ContractPaymentMethod";
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




        [Route("api/ContractRequest/DeleteContract/")]
        [HttpPost]
        public IHttpActionResult DeleteContractRequest(long contractrequestcode)
        {
           

            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spDeleteContractRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@ContractRequestCode", contractrequestcode));
          

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



        private static DataTable ConvertToContractRequestCommodityDatatable(IEnumerable<ContractCommodityDTO> commodity)
        {
            var commodityDetails = new DataTable();

            commodityDetails.Columns.Add("CommodityNameAR", typeof(string));
            commodityDetails.Columns.Add("CommodityCode", typeof(long));
            commodityDetails.Columns.Add("Qty", typeof(decimal));
            commodityDetails.Columns.Add("UnitPrice", typeof(decimal));
        

            foreach (ContractCommodityDTO item in commodity)
            {
                commodityDetails.Rows.Add(item.CommodityNameAR, item.CommodityCode, item.Qty, item.UnitPrice);
            }

            return commodityDetails;
        }

        private static DataTable ConvertToContractRequestPMDatatable(IEnumerable<ContractPaymentMethodDTO> PM)
        {
            var PMDetails = new DataTable();

            PMDetails.Columns.Add("PaymentMethodNameAR", typeof(string));
            PMDetails.Columns.Add("PaymentMethod", typeof(long));
            PMDetails.Columns.Add("Percentage", typeof(decimal));
          


            foreach (ContractPaymentMethodDTO item in PM)
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
