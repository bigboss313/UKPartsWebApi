using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UKPartsWebApi.EntityModel;
using UKPartsWebApi.Models;

namespace UKPartsWebApi.Controllers
{
    public class PartRequestController : ApiController
    {
      /// <summary>
      /// TODO:Show All Available Parts.
      /// </summary>
      /// <returns>Part List.</returns>
      [ResponseType(typeof(List<PartRequestModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetPartList")]
      public IHttpActionResult GetPartList()
      {
        using (UKPartsDBEntities db = new UKPartsDBEntities())
        {
           var getparts=db.Parts.ToList();   
           var config=new MapperConfiguration(cfg=> 
           {
             cfg.CreateMap<Part,PartRequestModel>();
           });
           IMapper mapper=config.CreateMapper();
           var data=mapper.Map<List<PartRequestModel>>(getparts);
           return Ok(new ResponseModel { Message="Get Parts",Status="Success",Data=data});
        }      
      }
      /// <summary>
      /// TODO:Show All Available Brands.
      /// </summary>
      /// <returns>Brand List</returns>
      [ResponseType(typeof(List<BrandListModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetBrandList")]
      public IHttpActionResult GetBrandList()
      {
       using(UKPartsDBEntities db=new UKPartsDBEntities())
       {
         var getbrands=db.Brands.ToList();
         var config=new MapperConfiguration(cfg=>
         {
             cfg.CreateMap<Brand, BrandListModel>();
         });
         IMapper mapper =config.CreateMapper();
         var brandlist=mapper.Map<List<BrandListModel>>(getbrands);
         return Ok(new ResponseModel{Message="Get Brands",Status="Success",Data=brandlist});
       }
      }
      /// <summary>
      /// TODO:Show Brand Models By Unique BrandId.
      /// </summary>
      /// <param name="brandId"></param>
      /// <returns>Brand Model List</returns>
      [ResponseType(typeof(List<BrandModelList>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetModelList")]
      public IHttpActionResult GetModelList(string brandId)
      {
       using(UKPartsDBEntities db=new UKPartsDBEntities())
       {
         var getmodels=db.Models.Where(m=>m.BrandId == brandId).ToList();
         var config=new MapperConfiguration(cfg=>
         {
           cfg.CreateMap<Model,BrandModelList>();
         });
         IMapper mapper=config.CreateMapper();
         var modelList=mapper.Map<List<BrandModelList>>(getmodels);
         return Ok(new ResponseModel {Message="GetModels",Status="Success",Data=modelList});
       }
      }
      /// <summary>
      /// TODO:Show Models By Year On The Basis Of ModelId.
      /// </summary>
      /// <param name="modelId"></param>
      /// <returns>Models List By Year</returns>
      [ResponseType(typeof(List<ModelByYear>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetModelYear")]
      public IHttpActionResult GetModelListByYear(string modelId)
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var getModelsByYear = db.ModelYears.Where(m => m.ModelId == modelId).ToList();
                var config = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<ModelYear,ModelByYear>();
                  });
                IMapper mapper = config.CreateMapper();
                var modelYearList = mapper.Map<List<ModelByYear>>(getModelsByYear);
                return Ok(new ResponseModel { Message = "GetModelsByYear", Status = "Succcess", Data = modelYearList });             
            }
        }
      /// <summary>
      /// TODO:Show Cities According to Selected Country On The Basis of CountryId.
      /// </summary>
      /// <param name="countryId"></param>
      /// <returns>City List</returns>
      [ResponseType(typeof(List<CityModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetCities")]
      public IHttpActionResult GetCities(int countryId)
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var getCities = db.Cities.Where(c=>c.CountryId == countryId).ToList();
                var config = new MapperConfiguration(cfg =>
                {
                  cfg.CreateMap<City,CityModel>();
                });
                IMapper mapper = config.CreateMapper();
                var cities=mapper.Map<List<CityModel>>(getCities);
                return Ok(new ResponseModel { Message = "Get City List", Status = "Success", Data = cities });
            }
        }
      /// <summary>
      /// TODO:Send Engine Size Details As Per Selected Model.
      /// </summary>
      /// <param name="modelId"></param>
      /// <returns>Engine Sizes Details.</returns>
      [ResponseType(typeof(List<EngineDetailModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetEngineSize")]
      public IHttpActionResult GetEngineSizeInfo(string modelId)
      {
        using(UKPartsDBEntities db=new UKPartsDBEntities())
        {
            var getEngineDetails = db.EngineDetails.Where(e => e.ModelId == modelId).ToList();
            var config=new MapperConfiguration(cfg=> 
            { 
             cfg.CreateMap<EngineDetail,EngineDetailModel>();
            });
            IMapper mapper =config.CreateMapper();
            var engineInfoList=mapper.Map<List<EngineDetailModel>>(getEngineDetails);
            return Ok(new ResponseModel {Message="Get Engine Size Details",Status="Success",Data=engineInfoList});
        }
      }
      /// <summary>
      /// TODO:Insert User Part Request.
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      [HttpPost]
      [AllowAnonymous]
      [Route("api/SubmitPartRequest")]
      public IHttpActionResult SubmitPartDetails(PartRequestViewModel model)
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Posted invalid data.");
                }
                if (model != null)
                {
                    try
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<PartRequestViewModel,PartRequestDetail>();
                        });
                        IMapper mapper = config.CreateMapper();
                        var partDetails = mapper.Map<PartRequestDetail>(model);
                        partDetails.Id = Guid.NewGuid().ToString();
                        partDetails.RequestedOn=DateTime.Now;
                        db.PartRequestDetails.Add(partDetails);
                        db.SaveChanges();
                        return Ok(new ResponseModel { Message="Part request submitted successfully.",Status="Success"});
                    }
                    catch (Exception ex)
                    {
                        return Ok(new ResponseModel { Message = ex.Message, Status = "Fail" });
                    }
                }
                return Ok();
            }
        }
      /// <summary>
      /// TODO:Get Most Recent Part Requests.
      /// </summary>
      /// <returns>Most Recent Part Request List</returns>
      [ResponseType(typeof(List<RecentRequestViewModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetRecentRequest")]
      public IHttpActionResult GetRequest()
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var RequestList = db.PartRequestDetails.OrderByDescending(x => x.RequestedOn).ToList();
                List<RecentRequestViewModel> data = new List<RecentRequestViewModel>();
                foreach (var item in RequestList)
                {
                    RecentRequestViewModel model = new RecentRequestViewModel();
                    model.PartName = db.Parts.Where(d => d.Id == item.PartId).Select(d => d.PartName).SingleOrDefault();
                    model.BrandName=db.Brands.Where(b => b.Id == item.BrandId).Select(b => b.BrandName).SingleOrDefault();
                    model.Model = db.Models.Where(x => x.Id == item.ModelId).Select(x => x.ModelName).SingleOrDefault();
                    model.ModelYear = db.ModelYears.Where(x => x.Id == item.ModelYearId).Select(x => x.Year).SingleOrDefault();
                    model.Country = db.Countries.Where(x => x.Id == item.CountryId).Select(x => x.Name).SingleOrDefault();
                    model.City = db.Cities.Where(x => x.Id == item.CityId).Select(x => x.CityName).SingleOrDefault();
                    model.RequestedOn= item.RequestedOn;
                    data.Add(model);
                }
                return Ok(new ResponseModel { Message = "Get Recent Request", Status = "Success", Data = data });
            }
        }
      /// <summary>
      /// TODO:Get User Part Requests By Unique DeviceId
      /// </summary>
      /// <param name="deviceId"></param>
      /// <returns>User Own Part Requests</returns>
      [ResponseType(typeof(List<RecentRequestViewModel>))]
      [HttpGet]
      [AllowAnonymous]
      [Route("api/GetMyRequestList")]
      public IHttpActionResult GetUserRequestList(string deviceId)
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var RequestList = db.PartRequestDetails.Where(x=>x.DeviceId == deviceId).OrderByDescending(x => x.RequestedOn).ToList();
                List<RecentRequestViewModel> data = new List<RecentRequestViewModel>();
                foreach (var item in RequestList)
                {
                    RecentRequestViewModel model = new RecentRequestViewModel();
                    model.PartName = db.Parts.Where(d => d.Id == item.PartId).Select(d => d.PartName).SingleOrDefault();
                    model.BrandName = db.Brands.Where(b => b.Id == item.BrandId).Select(b => b.BrandName).SingleOrDefault();
                    model.Model = db.Models.Where(x => x.Id == item.ModelId).Select(x => x.ModelName).SingleOrDefault();
                    model.ModelYear = db.ModelYears.Where(x => x.Id == item.ModelYearId).Select(x => x.Year).SingleOrDefault();
                    model.Country = db.Countries.Where(x => x.Id == item.CountryId).Select(x => x.Name).SingleOrDefault();
                    model.City = db.Cities.Where(x => x.Id == item.CityId).Select(x => x.CityName).SingleOrDefault();
                    model.RequestedOn = item.RequestedOn;
                    model.DeviceId = item.DeviceId;
                    data.Add(model);
                }
                return Ok(new ResponseModel { Message = "Get My Request List.", Status = "Success", Data = data });
            }
        }
    }
}
