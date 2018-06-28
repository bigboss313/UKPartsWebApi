using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKPartsWebApi.Models
{
    public class DirectoryViewModel
    {
      public string Id { get; set; }
      public string DealerPlaceName { get; set; }
      public string CountryName { get; set; }
    //public string PhoneNumber { get; set; }
    }
    public class DealerViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DealerPlaceName { get; set; }
        public string Avtar { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }


    }
}