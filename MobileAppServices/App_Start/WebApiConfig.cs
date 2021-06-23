using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace MobileAppServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}"
               
            );
            config.Routes.MapHttpRoute(
               name: "GetFormNo",
               routeTemplate: "api/{controller}/{formno}/{loginname}/{password}"
              
           );
            config.Routes.MapHttpRoute(
              name: "GetAllFormNo",
              routeTemplate: "api/{controller}/getAll/{loginname}/{password}/{fromdate}/{todate}"
             
          );
            config.Routes.MapHttpRoute(
              name: "Login",
              routeTemplate: "api/{controller}/{LoginName}/{Password}"

          );

            config.Routes.MapHttpRoute(
             name: "LoginDetail",
             routeTemplate: "api/{controller}/{LoginName}"

         );

            config.Routes.MapHttpRoute(
             name: "CommodityRoute",
             routeTemplate: "api/{controller}/getCommodity/{loginname}/{password}/{formno}"

         );

        

            config.Routes.MapHttpRoute(
name: "GetHelp",
routeTemplate: "api/{controller}/getHelp/{isbank}"

);

            config.Routes.MapHttpRoute(
name: "LoginApi",
routeTemplate: "api/{controller}/Login/{username}/{password}"

);


            config.Routes.MapHttpRoute(
name: "VerifyUser",
routeTemplate: "api/{controller}/VerifyUser/{loginname}/{password}"

);


            config.Routes.MapHttpRoute(
name: "ChangePassword",
routeTemplate: "api/{controller}/ChangePassword/{loginname}/{newpassword}"

);




            config.Routes.MapHttpRoute(
name: "GetUserInfo",
routeTemplate: "api/{controller}/GetUserInfo/{loginname}"

);

            //Claims------------------------

            config.Routes.MapHttpRoute(
         name: "GetAllClaim",
         routeTemplate: "api/{controller}/getAllClaims/{loginname}/{password}/{fromdate}/{todate}"

     );


            config.Routes.MapHttpRoute(
 name: "GetClaimByForm",
 routeTemplate: "api/{controller}/getFormClaims/{loginname}/{password}/{formno}"

);


            config.Routes.MapHttpRoute(
 name: "GetClaimByClaim",
 routeTemplate: "api/{controller}/getClaimsbyClaimCode/{loginname}/{password}/{claimcode}"

);

            //----ContractRequest--------------------------------

            config.Routes.MapHttpRoute(
   name: "GetAllContractRequest",
   routeTemplate: "api/{controller}/getAllContractRequest/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetContractRequestByCode",
 routeTemplate: "api/{controller}/getContractRequest/{loginname}/{password}/{contractrequestcode}"

);



            config.Routes.MapHttpRoute(
name: "GetContractRequestPaymentMethodByCode",
routeTemplate: "api/{controller}/getContractRequestPaymentMethod/{loginname}/{password}/{contractrequestcode}"

);

            //ISSUE--------------------------------------



            config.Routes.MapHttpRoute(
   name: "NewIssue",
   routeTemplate: "api/{controller}/New/{loginname}/{FormNo}/{type}/{IssueObject}/{issuedesc}"

);

            config.Routes.MapHttpRoute(
name: "DeleteIssue",
routeTemplate: "api/{controller}/DeleteIssue/{IssueCode}"

);

            config.Routes.MapHttpRoute(
    name: "GetIssues",
    routeTemplate: "api/{controller}/getIssues/{loginname}"

);




            // LicenseRequest--------------------------

            config.Routes.MapHttpRoute(
name: "GetAllLicenseRequest",
routeTemplate: "api/{controller}/getAllLicenseRequest/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetLicenseRequestByCode",
 routeTemplate: "api/{controller}/getLicenseRequest/{loginname}/{password}/{licenserequestcode}"

);



            config.Routes.MapHttpRoute(
name: "NewLicense",
routeTemplate: "api/{controller}/NewLicense"

);

            config.Routes.MapHttpRoute(
name: "UpdateLicense",
routeTemplate: "api/{controller}/UpdateLicense"

);

            config.Routes.MapHttpRoute(
name: "DeleteLicenseRequest",
routeTemplate: "api/{controller}/DeleteLicense/{licenserequestcode}"

);


            // Maturity--------------------------

            config.Routes.MapHttpRoute(
name: "GetAllMaturity",
routeTemplate: "api/{controller}/getAllMaturity/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetMaturityByCode",
 routeTemplate: "api/{controller}/getMaturity/{loginname}/{password}/{maturitycode}"

);



            config.Routes.MapHttpRoute(
name: "getMaturityByForm",
routeTemplate: "api/{controller}/getMaturityByForm/{loginname}/{password}/{formcode}"

);



            // MaturitySettlement--------------------------

            config.Routes.MapHttpRoute(
name: "GetAllMaturitySettlement",
routeTemplate: "api/{controller}/getAllMaturitySettlement/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetMaturitySettlementByCode",
 routeTemplate: "api/{controller}/getMaturitySettlement/{loginname}/{password}/{maturitysettlementcode}"

);

            config.Routes.MapHttpRoute(
name: "getMaturitySettlementByMaturity",
routeTemplate: "api/{controller}/getMaturitySettlementByMaturity/{loginname}/{password}/{maturitycode}"

);

            config.Routes.MapHttpRoute(
name: "getMaturitySettlementByForm",
routeTemplate: "api/{controller}/getMaturitySettlementByForm/{loginname}/{password}/{formcode}"

);

 


            // ClaimSettlement--------------------------

            config.Routes.MapHttpRoute(
name: "GetAllClaimSettlement",
routeTemplate: "api/{controller}/getAllClaimSettlement/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetClaimSettlementByCode",
 routeTemplate: "api/{controller}/getClaimSettlement/{loginname}/{password}/{claimsettlementcode}"

);

            config.Routes.MapHttpRoute(
name: "getClaimSettlementByClaim",
routeTemplate: "api/{controller}/getClaimSettlementByClaim/{loginname}/{password}/{claimcode}"

);

            config.Routes.MapHttpRoute(
name: "getClaimSettlementByForm",
routeTemplate: "api/{controller}/getClaimSettlementByForm/{loginname}/{password}/{formcode}"

);

            config.Routes.MapHttpRoute(
name: "getClaimSettlementByPayment",
routeTemplate: "api/{controller}/getClaimSettlementByPayment/{loginname}/{password}/{paymentcode}"

);


            // License--------------------------

            config.Routes.MapHttpRoute(
name: "GetAllLicense",
routeTemplate: "api/{controller}/getAllLicense/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetLicenseByCode",
 routeTemplate: "api/{controller}/getLicense/{loginname}/{password}/{licensecode}"

);

 

            // LicenseRequestCommodity--------------------------




            config.Routes.MapHttpRoute(
 name: "GetLicenseRequestCommodityByCode",
 routeTemplate: "api/{controller}/getLicenseRequestCommodityByCode/{loginname}/{password}/{licenserequestcode}"

);

            // LicenseCommodity--------------------------




            config.Routes.MapHttpRoute(
 name: "GetLicenseCommodityByCode",
 routeTemplate: "api/{controller}/getLicenseCommodityByCode/{loginname}/{password}/{licensecode}"

);


            // ContractRequestCommodity--------------------------




            config.Routes.MapHttpRoute(
 name: "GetContractRequestCommodityByCode",
 routeTemplate: "api/{controller}/getContractRequestCommodityByCode/{loginname}/{password}/{contractrequestcode}"

);



            // ContractCommodity--------------------------




            config.Routes.MapHttpRoute(
 name: "GetContractCommodityByCode",
 routeTemplate: "api/{controller}/getContractCommodityByCode/{loginname}/{password}/{contractcode}"

);


            // ContractPaymentMethod--------------------------




            config.Routes.MapHttpRoute(
 name: "GetContractPaymentMethodByCode",
 routeTemplate: "api/{controller}/getContractPaymentMethodByCode/{loginname}/{password}/{contractcode}"

);

            // OperationPaymentMethod--------------------------




            config.Routes.MapHttpRoute(
 name: "GetOperationPaymentMethodByCode",
 routeTemplate: "api/{controller}/getOperationPaymentMethodByCode/{loginname}/{password}/{operationcode}"

);



            // OperationCommodity--------------------------




            config.Routes.MapHttpRoute(
 name: "GetOperationCommodityByCode",
 routeTemplate: "api/{controller}/getOperationCommodity/{loginname}/{password}/{operationcode}"

);



            //-------OperationrRequest--------

            config.Routes.MapHttpRoute(
name: "GetAllOperationRequest",
routeTemplate: "api/{controller}/getAllOperationRequest/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetOperationRequestByCode",
 routeTemplate: "api/{controller}/getOperationRequest/{loginname}/{password}/{operationrequestcode}"

);

            config.Routes.MapHttpRoute(
name: "GetOperationRequestCommodityByCode",
routeTemplate: "api/{controller}/getOperationRequestCommodity/{loginname}/{password}/{operationrequestcode}"

);

            config.Routes.MapHttpRoute(
name: "GetOperationRequestPaymentMethodByCode",
routeTemplate: "api/{controller}/getOperationRequestPaymentMethod/{loginname}/{password}/{operationrequestcode}"

);


            //--------------------

            //-------Operation--------

            config.Routes.MapHttpRoute(
name: "GetAllOperation",
routeTemplate: "api/{controller}/getAllOperation/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetOperationByCode",
 routeTemplate: "api/{controller}/getOperation/{loginname}/{password}/{operationcode}"

);








            //--------------------


            //-------Contract--------

            config.Routes.MapHttpRoute(
name: "GetAllContract",
routeTemplate: "api/{controller}/getAllContract/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetContractByCode",
 routeTemplate: "api/{controller}/getContract/{loginname}/{password}/{contractcode}"

);





            //--------------------

            //-----------ExForm-------------------

            config.Routes.MapHttpRoute(
name: "getContractForms",
routeTemplate: "api/{controller}/getContractForms/{loginname}/{password}/{contractcode}"

);

            config.Routes.MapHttpRoute(
name: "getExform",
routeTemplate: "api/{controller}/getExform/{loginname}/{password}/{formno}"

);

            config.Routes.MapHttpRoute(
name: "getAllExForm",
routeTemplate: "api/{controller}/getAllExForm/{loginname}/{password}/{fromdate}/{todate}"

);

            //-----------ExFormCOmmodity-------------------



            config.Routes.MapHttpRoute(
name: "getExFormCommodity",
routeTemplate: "api/{controller}/getExFormCommodity/{loginname}/{password}/{formno}"

);

            //----------------------------------------

            //-----------ImForm-------------------

            config.Routes.MapHttpRoute(
name: "getOperationForms",
routeTemplate: "api/{controller}/getOperationForms/{loginname}/{password}/{operationcode}"

);

            config.Routes.MapHttpRoute(
name: "getImForm",
routeTemplate: "api/{controller}/getImForm/{loginname}/{password}/{formno}"

);

            config.Routes.MapHttpRoute(
name: "getAllImForm",
routeTemplate: "api/{controller}/getAllImForm/{loginname}/{password}/{fromdate}/{todate}"

);


            //-----------ImFormCOmmodity-------------------



            config.Routes.MapHttpRoute(
name: "getImFormCommodity",
routeTemplate: "api/{controller}/getImFormCommodity/{loginname}/{password}/{formno}"

);

            //----------------------------------------




            //-------Payment--------

            config.Routes.MapHttpRoute(
name: "GetAllPayment",
routeTemplate: "api/{controller}/getAllPayment/{loginname}/{password}/{fromdate}/{todate}"

);


            config.Routes.MapHttpRoute(
 name: "GetPaymentByCode",
 routeTemplate: "api/{controller}/getPayment/{loginname}/{password}/{paymentcode}"

);



            //--------------------


            config.Routes.MapHttpRoute(
name: "GetCommodity",
routeTemplate: "api/{controller}/getCommodity/{loginname}/{password}"

);

            config.Routes.MapHttpRoute(
name: "SearchCommodity",
routeTemplate: "api/{controller}/searchCommodity/{loginname}/{password}/{searchword}"

);

            config.Routes.MapHttpRoute(
        name: "NewContract",
        routeTemplate: "api/{controller}/NewContractRequest"

    );

            config.Routes.MapHttpRoute(
name: "UpdateContract",
routeTemplate: "api/{controller}/UpdateContract"

);

            


            config.Routes.MapHttpRoute(
 name: "NewOperation",
 routeTemplate: "api/{controller}/NewOperationRequest"

);


            config.Routes.MapHttpRoute(
name: "DeleteContractRequest",
routeTemplate: "api/{controller}/DeleteContract/{contractrequestcode}"

);


            config.Routes.MapHttpRoute(
name: "UpdateOperation",
routeTemplate: "api/{controller}/UpdateOperation"

);

            config.Routes.MapHttpRoute(
name: "DeleteOperationRequest",
routeTemplate: "api/{controller}/DeleteOperation/{operationrequestcode}"

);

            //---Upload Documents------------------

            config.Routes.MapHttpRoute(
name: "UploadDocument",
routeTemplate: "api/{controller}/Upload/{code}/{relatedobject}/{documentdesc}/{loginname}"

);

            config.Routes.MapHttpRoute(
name: "GetReleatedObject",
routeTemplate: "api/{controller}/getRelatedObject/{loginname}/{password}"

);


            config.Routes.MapHttpRoute(
name: "GetAllDocuments",
routeTemplate: "api/{controller}/getAllDocs/{loginname}/{password}"

);


            config.Routes.MapHttpRoute(
name: "getObjectDocument",
routeTemplate: "api/{controller}/getObjectDocument/{loginname}/{password}/{id}");

            config.Routes.MapHttpRoute(
name: "GetPdf",
routeTemplate: "api/{controller}/GetPdf/{loginname}/{password}/{id}");


            config.Routes.MapHttpRoute(
name: "getObjectDocumentByCode",
routeTemplate: "api/{controller}/getObjectDocument/{loginname}/{password}/{code}"

);


            //---------------------


            // GetClientInfo--------------------------




            config.Routes.MapHttpRoute(
 name: "GetClientInfo",
 routeTemplate: "api/{controller}/getClientInfo/{loginname}/{password}/{cbosid}"

);

            config.Formatters.JsonFormatter.SupportedMediaTypes
    .Add(new MediaTypeHeaderValue("text/html"));

        }


    }
}
