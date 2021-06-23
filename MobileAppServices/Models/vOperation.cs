//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileAppServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vOperation
    {
        public long OperationCode { get; set; }
        public string OperationDate { get; set; }
        public long CBOSID { get; set; }
        public long TaxNo { get; set; }
        public string RefNumber { get; set; }
        public long PaymentType { get; set; }
        public decimal TotalValue { get; set; }
        public long ImportPurpose { get; set; }
        public long Currency { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalValueUSD { get; set; }
        public long ExporterCountry { get; set; }
        public string ExporterName { get; set; }
        public Nullable<System.DateTime> DocArrivalDate { get; set; }
        public string ImportersRegister { get; set; }
        public long Status { get; set; }
        public string RejectionNotes { get; set; }
        public string Notes { get; set; }
        public long FlowStatus { get; set; }
        public long DataEntereer { get; set; }
        public long SecondApproval { get; set; }
        public long FirstApproval { get; set; }
        public bool IsDeleted { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string DataEntereerName { get; set; }
        public string SecondApprovalName { get; set; }
        public string FirstApprovalName { get; set; }
        public string UGUID { get; set; }
        public string PaymentTypeName { get; set; }
        public string ImportPurposeName { get; set; }
        public string ExporterCountryName { get; set; }
        public string CurrencyName { get; set; }
        public string OperationDateString { get; set; }
        public string DocArrivalDateString { get; set; }
        public Nullable<decimal> OperationAmountRemaining { get; set; }
        public System.DateTime CreationTime { get; set; }
        public string BankNameAR { get; set; }
        public string BranchNameAR { get; set; }
        public string FullNameArabic { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
