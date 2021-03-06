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
    
    public partial class vOperationRequest
    {
        public string BankNameAR { get; set; }
        public long OperationRequestId { get; set; }
        public Nullable<long> OperationRequestCode { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string BranchNameAR { get; set; }
        public string CurrencyShortName { get; set; }
        public string FlowStatusNameIMOperation { get; set; }
        public System.DateTime CreationTime { get; set; }
        public long CBOSID { get; set; }
        public Nullable<long> TaxNo { get; set; }
        public System.DateTime OperationRequestDate { get; set; }
        public decimal TotalValue { get; set; }
        public Nullable<decimal> TotalValueUSD { get; set; }
        public string ExporterName { get; set; }
        public string CountryNameAR { get; set; }
        public string ImportersRegister { get; set; }
        public string RejectionNotes { get; set; }
        public string Notes { get; set; }
        public string LoginName { get; set; }
        public System.DateTime ModifiedTime { get; set; }
        public string Password { get; set; }
        public long BankCode { get; set; }
        public long BranchCode { get; set; }
        public long CountryCode { get; set; }
        public long CurrencyCode { get; set; }
        public string ImportPurposeName { get; set; }
        public long ImportPurpose { get; set; }
        public int IsTraderEditable { get; set; }
        public System.DateTime DocArrivalDate { get; set; }
        public string FullName { get; set; }
    }
}
