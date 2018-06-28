using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKPartsWebApi.Models
{
    public class RecentRequestViewModel
    {
        public string PartName { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DeviceId { get; set; }
        public Nullable<System.DateTime> RequestedOn { get; set; }
        public double TimeTag
        {

            get
            {

                return DateTime.Now.Subtract(Convert.ToDateTime(RequestedOn)).TotalMinutes;
            }
        }



    }

}