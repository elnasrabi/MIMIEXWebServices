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
    
    public partial class vOperationRequestCommodity
    {
        public Nullable<long> OperationRequestCode { get; set; }
        public Nullable<long> CommodityCode { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string InitialInvoiceNumber { get; set; }
        public string InitialInvoiceIssuer { get; set; }
        public Nullable<System.DateTime> InitialInvoiceDate { get; set; }
        public string CommodityDesc { get; set; }
        public string CommodityNameAR { get; set; }
        public string MeasurementUnitNameEN { get; set; }
        public long Bank { get; set; }
        public long Branch { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
