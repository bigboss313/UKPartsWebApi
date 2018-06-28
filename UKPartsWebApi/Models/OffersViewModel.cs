using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKPartsWebApi.Models
{
    public class OffersViewModel
    {
        public string DealerPlaceName { get; set; }
        public string OrderedPartName { get; set; }
        public string SelectedBrand { get; set; }
        public string SelectedModel { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        //public DateTime IssuedOn { get; set; }
        //public double TimeTag
        //{
        //    get
        //    {
        //        return DateTime.Now.Subtract(Convert.ToDateTime(IssuedOn)).TotalMinutes;
        //    }
        //}

    }

}