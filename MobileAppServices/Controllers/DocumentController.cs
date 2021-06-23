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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace MobileAppServices.Controllers
{
    public class DocumentController : ApiController
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



        [Route("api/Document/getRelatedObject/")]
        public async Task<IHttpActionResult> GetRelatedObject(string loginname, string password)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {
                var result = (from a in dc.vRelatedObject
                              select new RelatedObjectDTO { id = a.id, name = a.name }).ToList();

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            else
            {
                var result = (from a in dc.vRelatedObject
                              select new RelatedObjectDTO { id = a.id, name = a.name }).ToList();

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }


        }


        [Route("api/Document/getAllDocs")]
        public async Task<IHttpActionResult> GetMyDocs(string loginname, string password)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var docs = (from a in dc.vSupportedDouments
                                where a.LoginName == loginname && a.Password == password 
                                select new SuppoertedDocumentDTO
                                {
                                    Code = a.Code,
                                    DocumentName = a.DocumentName,
                                    DocumentDesc = a.DocumentDesc,
                                    ActionTime = a.ActionTime,
                                    DocumentData = a.DocumentData,
                                    ObjectName = a.ObjectName,
                                     LoginName = a.LoginName,FullName=a.FullName
                                   
                                }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }
            else
            {



                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                 LoginName = a.LoginName,FullName=a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }


        }


        [Route("api/Document/getObjectDocument")]
        public async Task<IHttpActionResult> GetObjectDoc(string loginname, string password,long id)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password && a.Id==id
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                Id = a.Id,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                 LoginName = a.LoginName,FullName=a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }
            else if(utype==2)
            {



                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password && a.Id == id
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                 LoginName = a.LoginName,FullName=a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }
            else 
            {



                var docs = (from a in dc.vSupportedDouments
                            where a.Id == id
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                LoginName = a.LoginName,
                                FullName = a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }



        }


        [Route("api/Document/GetPdf")]
        public async Task<IHttpActionResult> getfile(string loginname, string password, long id)
        {
            MIMEXEntities dc = new MIMEXEntities();
         
                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password && a.Id == id
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                Id = a.Id,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                LoginName = a.LoginName,
                                FullName = a.FullName

                            }).ToList();



            if (String.IsNullOrEmpty(id.ToString()))
                return NotFound();


            byte[] myArrayOfBytes = null;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            
            response.Content = new StreamContent(new FileStream(docs.FirstOrDefault().DocumentData.ToString(), FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = docs.FirstOrDefault().DocumentName.ToString();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return   Ok(response); 
        }




        [Route("api/Document/getObjectDocumentByCode")]
        public async Task<IHttpActionResult> GetObjectDocbyCode(string loginname, string password, long code)
        {
            MIMEXEntities dc = new MIMEXEntities();
            int utype = GetUserType(loginname, password);

            if (utype == 1)
            {

                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password && a.Code == code
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                LoginName = a.LoginName,
                                FullName = a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }
            else if(utype==2)
            {



                var docs = (from a in dc.vSupportedDouments
                            where a.LoginName == loginname && a.Password == password && a.Id == code
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                LoginName = a.LoginName,
                                FullName = a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }

            else 
            {



                var docs = (from a in dc.vSupportedDouments
                            where  a.Id == code
                            select new SuppoertedDocumentDTO
                            {
                                Code = a.Code,
                                DocumentName = a.DocumentName,
                                DocumentDesc = a.DocumentDesc,
                                ActionTime = a.ActionTime,
                                DocumentData = a.DocumentData,
                                ObjectName = a.ObjectName,
                                LoginName = a.LoginName,
                                FullName = a.FullName

                            }).ToList();

                if (docs.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(docs);

            }


        }

        [Route("api/Document/Upload")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload(long code,string relatedobject,string documentdesc,string loginname)
        {
            SqlConnection locConn = getConnection();

            int matched = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCheckMatchedCode";
                cmd.Connection = locConn;

               
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@RelatedObject", relatedobject);
                cmd.Parameters.AddWithValue("@LoginName", loginname);
                var outputIdParam = new SqlParameter("@matched", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(outputIdParam);


                try
                {
                    locConn.Open();
                    cmd.ExecuteNonQuery();
                    locConn.Close();

                    matched = (int)outputIdParam.Value;
                }
                catch (Exception ex)
                {

                    return StatusCode(HttpStatusCode.BadRequest);
                }

                locConn.Close();

            }
            catch (Exception)
            {

                return StatusCode(HttpStatusCode.BadRequest);
            }

            if (matched==1)
            {

                var httpContext = HttpContext.Current;
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);




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
                            cmd.Parameters.AddWithValue("@FileSize", iFileLength);
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

            } // Matched Object
            else if (matched==0) //Not matched Object 
            {

                return StatusCode(HttpStatusCode.Forbidden);


            }

            return StatusCode(HttpStatusCode.OK);


        }

            //foreach (var file in provider.Contents)
            //{
            //     filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            //     buffer = await file.ReadAsByteArrayAsync();
               

            //    var cmd = new SqlCommand("spNewDocumentDocument") { Connection = locConn, CommandType = CommandType.StoredProcedure };
            //    cmd.Parameters.Add(new SqlParameter("@DocumentCode", Documentcode));
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
