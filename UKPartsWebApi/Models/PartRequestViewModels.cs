using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKPartsWebApi.Models
{
    public class PartRequestModel
    {
      public string Id { get; set; }
      public string PartName { get; set; }
    }
    public class BrandListModel
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
    }
    public class BrandModelList
    {
      public string Id { get; set; }
      public string ModelName { get; set; }
    }
    public class ModelByYear
    {
      public string Id { get; set; }
      public string Year { get; set; }
    }
   public class CityModel
   { 
    public string Id { get; set; }
    public string CityName { get; set; }
   }
   public class EngineDetailModel
   {
    public string Id { get; set; }
    public float EngineSize { get; set; }
   }
   public class PartRequestViewModel
   {
    public string PartId { get; set; }
    public string BrandId { get; set; }
    public string ModelId { get; set;}
    public string ModelYearId { get; set; }
    public int CountryId { get; set; }
    public string CityId { get; set; }
    public string EngineSizeId { get; set; }
    public string FuelId { get; set; }
    public string ColorId { get; set; }
    public string SelectedOption { get; set; }
   }
}