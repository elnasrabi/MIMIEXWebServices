using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileAppServices.Models
{
 

 

    public class ClaimDTO
    {
        public long ClaimCode { get; set; }
        public long FormCode { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethodNameAR { get; set; }

        public string CurrencyShortName { get; set; }
        public string CommodityNameAR { get; set; }
        public long? TaxNumber { get; set; }
        public long CBOSID { get; set; }
        public decimal PaymentPercent { get; set; }
        public long ContractCode { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal ClaimDeduction { get; set; }
        public decimal? ClaimRemaining { get; set; }
        public long PaymentMethodCode { get; set; }
        public decimal AmountUSD { get; set; }
        public string DueDateString { get; set; }
        public bool IsContract { get; set; }
        public long Bank { get; set; }
        public string BankNameAR { get; set; }
        public long BankBranch { get; set; }

        public string BranchNameAR { get; set; }
 
        public long Measurement { get; set; }
        public string FullNameEnglish { get; set; }

        public string LoginName { get; set; }

        public string ClaimStatus { get; set; }
        public string FullName { get; set; }

    }


 
 


    public class ClaimSettlementDTO
    {
        public string FullName { get; set; }
        public long ClaimSettlementId { get; set; }
        public long ClaimSettlementCode { get; set; }
        public long ClaimCode { get; set; }
        public long PaymentCode { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Deduction { get; set; }
        public long FlowStatus { get; set; }
        public string RejectionNotes { get; set; }
        public decimal? DeductionUSD { get; set; }
        public string FlowStatusNameEX { get; set; }
        public long FormCode { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string LoginName { get; set; }

    }


    public class ClientInqueryDTO
    {
        public string FullName { get; set; }
        public decimal? RequiredClaim { get; set; }
        public decimal RequiredMaturity { get; set; }
        public decimal RequiredTransfers { get; set; }
        public long CBOSID { get; set; }
        public string FullNameArabic { get; set; }

        public string ClientStatusNameAR { get; set; }

        public long Status { get; set; }
        public string LoginName { get; set; }

    }


    public class ContractDTO
    {
        public string FullName { get; set; }
        public long ContractCode { get; set; }
        public long ContractRequestCode { get; set; }

        
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CreationDateString { get; set; }
        public string ExpirationDateString { get; set; }
        public long TaxNo { get; set; }
        public long LoadingPort { get; set; }

        public long Destination { get; set; }
        public long Currency { get; set; }
        public long ShipingType { get; set; }
        public long CBOSID { get; set; }
        public string FullNameArabic { get; set; }
        
        public string FullNameEnglish { get; set; }
        public string ImporterName { get; set; }
        public string ImporterAddress { get; set; }
        public string BankNameAR { get; set; }

        public string BranchNameAR { get; set; }
        public string LoadingPortNameAr { get; set; }
        public string CountryNameAR { get; set; }
        public string ArrivalPort { get; set; }
        public string ShipingTypeNameAR { get; set; }
        public string FlowStatusNameContract { get; set; }
        public decimal TotalValue { get; set; }
        public string CurrencyShortName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Notes { get; set; }
        public string RejectionNotes { get; set; }
        public string LoadingPortShortName { get; set; }
        public string DataEntereer { get; set; }
        public string FirstApproval { get; set; }
        public string SecondApproval { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string LoginName { get; set; }

    }




    public class ContractRequestDTO
    {
        public string FullName { get; set; }
        public long? ContractRequestCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CreationDateString { get; set; }
        public string ExpirationDateString { get; set; }
        public long? TaxNo { get; set; }
        public long ShipingTypeCode { get; set; }
        public long Custom_UnitPK { get; set; }
        public long CountryCode { get; set; }
        public long CurrencyCode { get; set; }
        public string ArrivalPort { get; set; }

        public string FullNameArabic { get; set; }
        public string FullNameEnglish { get; set; }
        public string ImporterName { get; set; }
        public string ImporterAddress { get; set; }
        public string BankNameAR { get; set; }

        public string BranchNameAR { get; set; }
        public string Custom_Unit_Name_AR { get; set; }
        public string CountryNameAR { get; set; }
 
        public string ShipingTypeNameAR { get; set; }
        public string FlowStatusNameContract { get; set; }
        public decimal TotalValue { get; set; }
        public string CurrencyShortName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Notes { get; set; }
        public string RejectionNotes { get; set; }
        public int LoadingPort { get; set; }
        public int ShipingType { get; set; }
        public int CBOSID { get; set; }

        public int IsTraderEditable { get; set; }

        public int Destination { get; set; }
        public int Currency { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string LoginName { get; set; }

    }
    

    public class LicenseDTO
    {
        public string FullName { get; set; }
        public long LicenseCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string LicensePurposeNameAr { get; set; }
        public string ValidityPeriodNameAR { get; set; }
        public string LoadingPortNameAr { get; set; }
        public string CountryNameAR { get; set; }
        public string FlowStatusNameLicense { get; set; }
        public string DataEnterer { get; set; }
        public string RejectionNotes { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalValueUSD { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string RegistrationNumber { get; set; }
        public string FullNameArabic { get; set; }
        public long CBOSID { get; set; }
        public string LoginName { get; set; }


        public long LicenseRequestCode { get; set; }
      
        public string ImporterName { get; set; }
        public string Custom_Unit_Name_AR { get; set; }
        public string CurrencyShortName { get; set; }
        public string Notes { get; set; }

      
        public string ImporterAddress { get; set; }
    
        public long Currency { get; set; }
        public long Destination { get; set; }
        public long LoadingPort { get; set; }

        public string ArrivalPort { get; set; }


       

        public long CurrencyCode { get; set; }

        public long Custom_UnitPK { get; set; }

        public long Purpose { get; set; }



    

        public int IsTraderEditable { get; set; }

    }

    public class LicenseRequestDTO
    {
        public string FullName { get; set; }
        public long LicenseRequestCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LicensePurposeNameAr { get; set; }
        public string ImporterName { get; set; }
        public string Custom_Unit_Name_AR { get; set; }
        public string CurrencyShortName { get; set; }
        public string Notes { get; set; }
        
        public string CountryNameAR { get; set; }
        public string FlowStatusNameLicense { get; set; }
        public string ImporterAddress { get; set; }
        public string RejectionNotes { get; set; }
        public long Bank { get; set; }
        public long Currency { get; set; }
        public long Destination { get; set; }
        public long LoadingPort { get; set; }
        
        public string ArrivalPort { get; set; }

        
        public long BankBranch { get; set; }

        public long CurrencyCode { get; set; }

        public long Custom_UnitPK { get; set; }

        public long Purpose { get; set; }


  
        public decimal TotalValue { get; set; }
        public decimal TotalValueUSD { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string RegistrationNumber { get; set; }
        public string FullNameArabic { get; set; }
        public long? CBOSID { get; set; }
        public string LoginName { get; set; }

        public int IsTraderEditable { get; set; }

    }

    public class PaymentDTO
    {
        public string FullName { get; set; }
        public long PaymentCode { get; set; }
        public DateTime CreationTime { get; set; }
        public long PaymentType { get; set; }
        public long CBOSID { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal Discounts { get; set; }
        public string CorrespondentName { get; set; }
        public string CorrespondentAccount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CurrencyShortName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string FlowStatusNamePayment { get; set; }
        public string RejectionNotes { get; set; }
        public string Notes { get; set; }
        public long FlowStatus { get; set; }
        public decimal? PaymentRemaining { get; set; }
        public string LoginName { get; set; }

    }

    public class ExFormDTO
    {
        public string FullName { get; set; }
        public long FormCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string BankSerial { get; set; }
        public long Contract { get; set; }
        public string CurrencyShortName { get; set; }
        public long CBOSID { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalValueUSD { get; set; }
        public string Note { get; set; }
        public long FlowStatus { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string DataEntereerName { get; set; }
        public string FirstApprovalName { get; set; }
        public string SecondApprovalName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImporterName { get; set; }
        public string ImporterAddress { get; set; }
        public string ArrivalPort { get; set; }
        public decimal ContractTotal { get; set; }
        public string RegistrationNumber { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string ShipingTypeNameAR { get; set; }
        public string FlowStatusNameEX { get; set; }
        public string CountryNameAR { get; set; }
        public string Custom_Unit_Name_AR { get; set; }
        public string FullNameAR { get; set; }
        public string LoginName { get; set; }

    }






    public class ImFormDTO
    {
        public string FullName { get; set; }
        public long FormCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string BankSerial { get; set; }
        public long Operation { get; set; }
        public long? CBOSID { get; set; }
        public long? TaxNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalValueUSD { get; set; }
        public string Note { get; set; }
        public long FlowStatus { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
        public string LoadingPort { get; set; }
        public string BillOfLading { get; set; }
        public string CurrencyShortName { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string FullNameAr { get; set; }
        public string LoadingPortNameAr { get; set; }
        public string FlowStatusNameIM { get; set; }
        public string CarrierTypeNameAr { get; set; }
        public string ExporterName { get; set; }
        public string ImportersRegister { get; set; }
        public string CountryNameAR { get; set; }
        public string UserType { get; set; }
        public string LoginName { get; set; }

    }


    public class ImFormCommodityDTO
    {

        public long Commodity { get; set; }
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public string FinalInvoiceNumber { get; set; }
        public string Note { get; set; }
        public long FormCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string LoginName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }


    }


    public class MaturityDTO
    {
        public string FullName { get; set; }
        public long MaturityCode { get; set; }
        public long FormCode { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountUSD { get; set; }
        public long FlowStatus { get; set; }
        public DateTime ActionTime { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string CurrnecyNameAR { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string FlowStatusNameIM { get; set; }

        public string MaturityStatus { get; set; }
        public decimal? MaturityRemaining { get; set; }

        public string LoginName { get; set; }



    }

    public class MaturitySettlementDTO
    {
        public string FullName { get; set; }
        public long MaturitySettlementCode { get; set; }
        public long MaturityCode { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountUSD { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ActionTime { get; set; }
        public long FlowStatus { get; set; }
        public long PaymentCode { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public long FormCode { get; set; }
        public string MaturitySettlementTypeDesc { get; set; }
        public string CurrencyShortName { get; set; }
        public string FlowStatusNameIM { get; set; }
        public string RejectionNotes { get; set; }
        public string LoginName { get; set; }

    }

    public class SuppoertedDocumentDTO
    {
        public string FullName { get; set; }
        public long? Code { get; set; }
        public long Id { get; set; }
        public string ObjectName { get; set; }

        public string DocumentName { get; set; }

        public byte[] DocumentData { get; set; }

        public string DocumentDesc { get; set; }

        public string LoginName { get; set; }
    

        public DateTime ActionTime { get; set; }

    }



    public class OperationDTO
    {
        public string FullName { get; set; }
        public long OperationCode { get; set; }
        public string OperationDate { get; set; }
        public long CBOSID { get; set; }
        public long TaxNo { get; set; }
        public string RefNumber { get; set; }
        public string CurrencyShortName { get; set; }
        public long PaymentType { get; set; }
        public long ImportPurpose { get; set; }
        public long Currency { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalValueUSD { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime? DocArrivalDate { get; set; }
        public long ExporterCountry { get; set; }
        public string ExporterName { get; set; }
        public string ImportersRegister { get; set; }
        public string RejectionNotes { get; set; }
        public string Notes { get; set; }
        public long FlowStatus { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string DataEntereerName { get; set; }
        public string SecondApprovalName { get; set; }
        public string FirstApprovalName { get; set; }
        public string PaymentTypeName { get; set; }
        public string ImportPurposeName { get; set; }
        public string ExporterCountryName { get; set; }
        public string CurrencyName { get; set; }
        public decimal? OperationAmountRemaining { get; set; }
        public DateTime CreationTime { get; set; }
        public string FullNameArabic { get; set; }
        public string BankNameAR { get; set; }

        public string FlowStatusNameIMOperation { get; set; }
      
        public string BranchNameAR { get; set; }
      
        public string LoginName { get; set; }

    }

    public class OperationTransferDTO
    {
        public string FullName { get; set; }
        public decimal? TransferAmount { get; set; }
        public long? TransferCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public string CorrespondentName { get; set; }
        public DateTime? CreationDate { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string ClientName { get; set; }
        public decimal? TransferRemaining { get; set; }
        public string CurrencyShortName { get; set; }
        public decimal Deduction { get; set; }
        public decimal DeductionUSD { get; set; }
        public long OperationCode { get; set; }
        public long? CBOSID { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string LoginName { get; set; }

    }


    public class OperationRequestDTO
    {
        public string FullName { get; set; }
        public long? OperationRequestCode { get; set; }
        public DateTime OperationRequestDate { get; set; }
        public long CBOSID { get; set; }
        public long? TaxNo { get; set; }
        public string RefNumber { get; set; }
        public long PaymentType { get; set; }
        public long ImportPurpose { get; set; }
        public long Currency { get; set; }
        public decimal Rate { get; set; }
        public decimal? TotalValueUSD { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime DocArrivalDate { get; set; }
        public long ExporterCountry { get; set; }
        public string ExporterName { get; set; }
        public string ImportersRegister { get; set; }
        public string RejectionNotes { get; set; }
        public string Notes { get; set; }
        public string FlowStatusNameIMOperation { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public long BankBranch { get; set; }
        public string DataEntereerName { get; set; }
        public string SecondApprovalName { get; set; }
        public string FirstApprovalName { get; set; }
        public string PaymentTypeName { get; set; }
        public string ImportPurposeName { get; set; }
        public string CountryNameAR { get; set; }
        public string CurrencyShortName { get; set; }
        public decimal OperationAmountRemaining { get; set; }
        public DateTime CreationTime { get; set; }
        public string FullNameArabic { get; set; }
        public string BankNameAR { get; set; }
        public long BankCode { get; set; }
        public long BranchCode { get; set; }
        public long CountryCode { get; set; }
        public long CurrencyCode { get; set; }


        public int IsTraderEditable { get; set; }

        public string BranchNameAR { get; set; }

        public string LoginName { get; set; }

      

    }

    public class IMEXUserDto
    {
        public long Id { get; set; }
        public string MobileNo { get; set; }
        public long? CBOSID { get; set; }
        public string LoginName { get; set; }
         public string UserType { get; set; }
        public long FormNo { get; set; }
        public string FullName { get; set; }
        public bool IsFirstLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpired { get; set; }
        public bool IsMobileVerified { get; set; }

    }

   
    public class IssueDto
    {
        public string FullName { get; set; }
        public long? Type { get; set; }
        public long? FormNo { get; set; }
        public string LoginName { get; set; }
        public string IssueDesc { get; set; }
        public Byte[] Attach { get; set; }
        public string ResolvedBy { get; set; }
    }

    public class HelpDTO
    {
     
        public string Question { get; set; }
        public string Answer { get; set; }
    
    }

    public class CommodityDTO
    {

        public long id { get; set; }
        public string name { get; set; }

     

    }

    public class RelatedObjectDTO
    {

        public long id { get; set; }
        public string name { get; set; }



    }

    public class IMEXLogin
    {
       
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        
    }

   

    public class ContractCommodityDTO
    {
        public long? ContractCommoidityCode { get; set; }
        public long Commodity { get; set; }

        public string CommodityCusCode { get; set; }
        public long CommodityCode { get; set; }
        public decimal Qty { get; set; }

        
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public long Contract { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string LoginName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }


    }


    public class ExFormCommodityDTO
    {
     
        public long CommodityCode { get; set; }
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public long FormCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string LoginName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }


    }

 


    public class ContractRequestCommodityDTO
    {
        public string CommodityNameAR { get; set; }
        public long? CommodityCode { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public string LoginName { get; set; }

        


    }






    public class ContractPaymentMethodDTO
    {
        public string PaymentMethodNameAR { get; set; }
        public long PaymentMethod { get; set; }
        public decimal Percentage { get; set; }

    }


    

    public class ContractRequestPaymentMethodDTO
    {
        public string PaymentMethodNameAR { get; set; }
        public long? PaymentMethodCode { get; set; }
        public decimal? Percentage { get; set; }

    }


    public class ContractPaymentMethod
    {
        public string PaymentMethodNameAR { get; set; }
        public long? PaymentMethod { get; set; }
        public decimal? Percentage { get; set; }

    }


    public class LicenseCommodityDTO
    {
        public long LicenseCommoidityId { get; set; }
        public long CommodityCode { get; set; }
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public string CommodityCusCode { get; set; }
        public long LicenseCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string LoginName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }


        public decimal Qty { get; set; }
    


    }



 




    public class LicenseRequestCommodityDTO
    {
        public string CommodityNameAR { get; set; }
        public long? CommodityCode { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }

        public string MeasurementUnitNameEN { get; set; }

        public string LoginName { get; set; }




    }







    public class ContractRequestViewModel
    {
        public ContractDTO contract { get; set; }
        public ContractCommodityDTO[] contractCommodityDetails { get; set; }

        public ContractPaymentMethodDTO[] contractPaymentMethodDetails { get; set; }

       

    }

    public class LicenseRequestViewModel
    {
        public LicenseDTO License { get; set; }
        public LicenseCommodityDTO[] LicenseCommodityDetails { get; set; }

    }

    public class LicenseUpdateRequestViewModel
    {
        public LicenseRequestDTO License { get; set; }
        public LicenseRequestCommodityDTO[] LicenseCommodityDetails { get; set; }
    }

        public class ContractUpdateRequestViewModel
    {
        public ContractRequestDTO contract { get; set; }
        public ContractRequestCommodityDTO[] contractCommodityDetails { get; set; }

        public ContractRequestPaymentMethodDTO[] contractPaymentMethodDetails { get; set; }

    }


    //-------Operation

    public class Operation
    {
        public string FullName { get; set; }
        public long OperationRequestCode { get; set; }
        public int ImportPurpose { get; set; }
        public string ExporterName { get; set; }
        public int ExporterCountry { get; set; }
        public string DocArrivalDate { get; set; }
        public decimal TotalValue { get; set; }
        public int Currency { get; set; }
        public int Bank { get; set; }
        public int BankBranch { get; set; }
        public long CBOSID { get; set; }
        public string Notes { get; set; }
        public string LoginName { get; set; }
    }

    public class OperationCommodityDTO
    {
        public DateTime CreationDate { get; set; }
        public DateTime InitInvoiceDate { get; set; }
        public string InitInvoiceNumber { get; set; }
        public string InitInvoiceIssuer { get; set; }
        public long OperationCode { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalValueUSD { get; set; }
        public string LoginName { get; set; }
        public string CommodityDesc { get; set; }
        public string CurrencyShortName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }


    }



    public class OperationPaymentMethodDTO
    {
        public string PaymentMethodNameAR { get; set; }
        public long PaymentMethod { get; set; }
        public decimal Percentage { get; set; }

    }


    public class OperationRequestCommodityDTO
    {
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }

        
        public long? CommodityCode { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public string InitialInvoiceNumber { get; set; }
        public string InitialInvoiceIssuer { get; set; }
        public DateTime? InitialInvoiceDate { get; set; }
        public string CommodityDesc { get; set; }
    }


    public class OperationRequestPaymentMethodDTO
    {
        public string PaymentMethodNameAR { get; set; }
        public long? PaymentMethodCode { get; set; }
        public long? PaymentMethod { get; set; }
        public decimal? Percentage { get; set; }

    }



    public class OperationRequestViewModel
    {
        public OperationRequestDTO operation { get; set; }
        public OperationRequestCommodityDTO[] operationCommodityDetails { get; set; }

        public OperationRequestPaymentMethodDTO[] operationPaymentMethodDetails { get; set; }

    }


    public class ContractSubmitViewModel
    {
        public ContractDTO operation { get; set; }
        public ContractCommodityDTO[] operationCommodityDetails { get; set; }

        public ContractPaymentMethodDTO[] operationPaymentMethodDetails { get; set; }

    }
}

