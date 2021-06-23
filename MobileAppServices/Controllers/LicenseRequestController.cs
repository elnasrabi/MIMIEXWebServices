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
    public class LicenseRequestController : ApiController
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





        [Route("api/LicenseRequest/getLicenseRequest")]
        public async Task<IHttpActionResult> GetLicenseRequestByCode(string loginname, string password, long licenserequestcode)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var LicenseRequest = (from a in dc.vLicenseRequest
                                      where a.LoginName == loginname && a.Password == password && a.LicenseRequestCode == licenserequestcode
                                      select new LicenseRequestDTO
                                      {
                                           LoginName = a.LoginName,FullName=a.FullName,
                                          CBOSID = a.CBOSID,
                                          LicenseRequestCode = a.LicenseRequestCode,
                                          IsTraderEditable = a.IsTraderEditable,
                                          FlowStatusNameLicense = a.FlowStatusNameLicense,
                                          CountryNameAR = a.CountryNameAR,
                                          Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                          LicensePurposeNameAr = a.LicensePurposeNameAr,
                                          CreationTime = a.CreationTime,
                                          CurrencyShortName = a.CurrencyShortName,
                                          Notes = a.Notes,
                                          ImporterName = a.ImporterName,
                                          ImporterAddress = a.ImporterAddress,
                                          ExpirationDate = a.ExpirationDate,
                                          BankNameAR = a.BankNameAR,
                                          BranchNameAR = a.BranchNameAR,
                                          ArrivalPort = a.ArrivalPort,
                                          CurrencyCode = a.CurrencyCode,
                                          Custom_UnitPK = a.Custom_UnitPK,
                                          Bank = a.Bank,
                                          BankBranch = a.BankBranch,
                                          Purpose = a.Purpose,
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

                var LicenseRequest = (from a in dc.vLicenseRequest
                                      where a.BankBranch == userbranch && a.Bank == userorg && a.LicenseRequestCode == licenserequestcode
                                      select new LicenseRequestDTO
                                      {
                                           LoginName = a.LoginName,FullName=a.FullName,
                                          CBOSID = a.CBOSID,
                                          LicenseRequestCode = a.LicenseRequestCode,
                                          IsTraderEditable = a.IsTraderEditable,
                                          FlowStatusNameLicense = a.FlowStatusNameLicense,
                                          CountryNameAR = a.CountryNameAR,
                                          Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                          LicensePurposeNameAr = a.LicensePurposeNameAr,
                                          CreationTime = a.CreationTime,
                                          CurrencyShortName = a.CurrencyShortName,
                                          Notes = a.Notes,
                                          ImporterName = a.ImporterName,
                                          ImporterAddress = a.ImporterAddress,
                                          ExpirationDate = a.ExpirationDate,
                                          BankNameAR = a.BankNameAR,
                                          BranchNameAR = a.BranchNameAR,
                                          ArrivalPort = a.ArrivalPort,
                                          CurrencyCode = a.CurrencyCode,
                                          Custom_UnitPK = a.Custom_UnitPK,
                                          Bank = a.Bank,
                                          BankBranch = a.BankBranch,
                                          Purpose = a.Purpose,
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

        [Route("api/LicenseRequest/getAllLicenseRequest")]
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
                    var LicenseRequest = (from a in dc.vLicenseRequest
                                          where a.LoginName == loginname && a.Password == password
                                          select new LicenseRequestDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              CBOSID = a.CBOSID,
                                              IsTraderEditable = a.IsTraderEditable,
                                              LicenseRequestCode = a.LicenseRequestCode,
                                              FlowStatusNameLicense = a.FlowStatusNameLicense,
                                              CountryNameAR = a.CountryNameAR,
                                              Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                              LicensePurposeNameAr = a.LicensePurposeNameAr,
                                              CreationTime = a.CreationTime,
                                              CurrencyShortName = a.CurrencyShortName,
                                              Notes = a.Notes,
                                              ImporterName = a.ImporterName,
                                              ImporterAddress = a.ImporterAddress,
                                              ExpirationDate = a.ExpirationDate,
                                              BankNameAR = a.BankNameAR,
                                              BranchNameAR = a.BranchNameAR,
                                              ArrivalPort = a.ArrivalPort,
                                              CurrencyCode = a.CurrencyCode,
                                              Custom_UnitPK = a.Custom_UnitPK,
                                              Bank = a.Bank,
                                              BankBranch = a.BankBranch,
                                              Purpose = a.Purpose,
                                              RegistrationNumber = a.RegistrationNumber,
                                              TotalValue = a.TotalValue,
                                          }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
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


                    var LicenseRequest = (from a in dc.vLicenseRequest
                                          where a.BankBranch == userbranch && a.Bank == userorg
                                          select new LicenseRequestDTO
                                          {
                                               LoginName = a.LoginName,FullName=a.FullName,
                                              CBOSID = a.CBOSID,
                                              LicenseRequestCode = a.LicenseRequestCode,
                                              IsTraderEditable=a.IsTraderEditable,
                                              FlowStatusNameLicense = a.FlowStatusNameLicense,
                                              CountryNameAR = a.CountryNameAR,
                                              Custom_Unit_Name_AR = a.Custom_Unit_Name_AR,
                                              LicensePurposeNameAr = a.LicensePurposeNameAr,
                                              CreationTime = a.CreationTime,
                                              CurrencyShortName = a.CurrencyShortName,
                                              Notes = a.Notes,
                                              ImporterName = a.ImporterName,
                                              ImporterAddress = a.ImporterAddress,
                                              ExpirationDate = a.ExpirationDate,
                                              BankNameAR = a.BankNameAR,
                                              BranchNameAR = a.BranchNameAR,
                                              ArrivalPort = a.ArrivalPort,
                                              CurrencyCode = a.CurrencyCode,
                                              Custom_UnitPK = a.Custom_UnitPK,
                                              Bank = a.Bank,
                                              BankBranch = a.BankBranch,
                                              Purpose = a.Purpose,
                                              RegistrationNumber = a.RegistrationNumber,
                                              TotalValue = a.TotalValue,
                                          }).ToList().Where(x => x.CreationTime >= dtFrom && x.CreationTime <= dtTo);
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




        [HttpPost]
        public IHttpActionResult NewLicense(LicenseRequestViewModel LicenseInfo)

        {
            LicenseDTO License = LicenseInfo.License;
            var CommodityDetail = LicenseInfo.LicenseCommodityDetails;
        

            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spNewLicenseRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LoadingPort", License.LoadingPort));
            cmd.Parameters.Add(new SqlParameter("@ImporterName", License.ImporterName));
            cmd.Parameters.Add(new SqlParameter("@ImporterAddress", License.ImporterAddress));
            cmd.Parameters.Add(new SqlParameter("@Destination", License.Destination));
            cmd.Parameters.Add(new SqlParameter("@ArrivalPort", License.ArrivalPort));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", License.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", License.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", License.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", License.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@Purpose", License.Purpose));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", License.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", License.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", License.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToLicenseRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "LicenseCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

            //--------------PM------------------
         



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



        [Route("api/LicenseRequest/UpdateLicense")]
        [HttpPost]
        public IHttpActionResult Update(LicenseRequestViewModel LicenseInfo)
        {
            LicenseDTO License = LicenseInfo.License;
            var CommodityDetail = LicenseInfo.LicenseCommodityDetails;
           

            SqlConnection locConn = getConnection();
            var cmd = new SqlCommand("spUpdateLicenseRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LicenseRequestCode", License.LicenseRequestCode));
            cmd.Parameters.Add(new SqlParameter("@LoadingPort", License.LoadingPort));
            cmd.Parameters.Add(new SqlParameter("@ImporterName", License.ImporterName));
            cmd.Parameters.Add(new SqlParameter("@ImporterAddress", License.ImporterAddress));
            cmd.Parameters.Add(new SqlParameter("@Destination", License.Destination));
            cmd.Parameters.Add(new SqlParameter("@ArrivalPort", License.ArrivalPort));
            cmd.Parameters.Add(new SqlParameter("@TotalValue", License.TotalValue));
            cmd.Parameters.Add(new SqlParameter("@Currency", License.Currency));
            cmd.Parameters.Add(new SqlParameter("@Bank", License.Bank));
            cmd.Parameters.Add(new SqlParameter("@BankBranch", License.BankBranch));
            cmd.Parameters.Add(new SqlParameter("@Purpose", License.Purpose));
            cmd.Parameters.Add(new SqlParameter("@CBOSID", License.CBOSID));
            cmd.Parameters.Add(new SqlParameter("@Notes", License.Notes));
            cmd.Parameters.Add(new SqlParameter("@LoginName", License.LoginName));

            //------------Commodity------------
            DataTable commodityDataTable = ConvertToLicenseRequestCommodityDatatable(CommodityDetail);
            var commodityParam = new SqlParameter();
            commodityParam.ParameterName = "LicenseCommodity";
            commodityParam.SqlDbType = SqlDbType.Structured;
            commodityParam.Value = commodityDataTable;
            commodityParam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(commodityParam);

          


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




        [Route("api/LicenseRequest/DeleteLicense/")]
        [HttpPost]
        public IHttpActionResult DeleteLicenseRequest(long Licenserequestcode)
        {


            SqlConnection locConn = getConnection();

            var cmd = new SqlCommand("spDeleteLicenseRequest") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter("@LicenseRequestCode", Licenserequestcode));


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



        private static DataTable ConvertToLicenseRequestCommodityDatatable(IEnumerable<LicenseCommodityDTO> commodity)
        {
            var commodityDetails = new DataTable();

            commodityDetails.Columns.Add("CommodityNameAR", typeof(string));
            commodityDetails.Columns.Add("CommodityCode", typeof(long));
            commodityDetails.Columns.Add("Qty", typeof(decimal));
            commodityDetails.Columns.Add("UnitPrice", typeof(decimal));


            foreach (LicenseCommodityDTO item in commodity)
            {
                commodityDetails.Rows.Add(item.CommodityNameAR, item.CommodityCode, item.Qty, item.UnitPrice);
            }

            return commodityDetails;
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
