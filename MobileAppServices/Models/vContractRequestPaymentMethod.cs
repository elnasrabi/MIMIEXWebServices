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
    
    public partial class vContractRequestPaymentMethod
    {
        public string PaymentMethodNameAR { get; set; }
        public Nullable<long> ContractRequestCode { get; set; }
        public Nullable<long> PaymentMethodCode { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public string Password { get; set; }
        public string LoginName { get; set; }
        public long Bank { get; set; }
        public long BankBranch { get; set; }
    }
}
