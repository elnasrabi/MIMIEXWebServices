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
    
    public partial class vLicense
    {
        public long LicenseId { get; set; }
        public long LicenseCode { get; set; }
        public System.DateTime CreationTime { get; set; }
        public string CreationTimeString { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string LicensePurposeNameAr { get; set; }
        public string LicensePurposeNameEng { get; set; }
        public string ValidityPeriodNameAR { get; set; }
        public string ValidityPeriodNameEN { get; set; }
        public string LoadingPortNameAr { get; set; }
        public string LoadingPortNameEng { get; set; }
        public string CountryNameEN { get; set; }
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
        public string UGUID { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEnglish { get; set; }
        public string CIASARegistrationNumber { get; set; }
        public long CBOSID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
