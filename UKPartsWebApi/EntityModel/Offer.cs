//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UKPartsWebApi.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Offer
    {
        public string Id { get; set; }
        public string DealerName { get; set; }
        public string OrderedPartId { get; set; }
        public Nullable<decimal> OfferPrice { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string BrandId { get; set; }
        public string ModelId { get; set; }
    }
}
