﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKPartsWebApi.Models
{
    public class DirectoryViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Avtar { get; set; }


        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }


    }
}