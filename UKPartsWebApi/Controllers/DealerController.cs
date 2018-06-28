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
    public class DealerController : ApiController
    {
     /// <summary>
     /// TODO:Shows Dealer Contact List.
     /// </summary>
     /// <returns>Dealer Directory List</returns>
     [HttpGet]
     [AllowAnonymous]
     [Route("api/GetDirectory")]
     [ResponseType(typeof (List<DirectoryViewModel>))]
     public IHttpActionResult GetDealerDirectory()
     {
       using(UKPartsDBEntities db=new UKPartsDBEntities())
       {
         var getDirectory=db.AspNetUsers.ToList();
          var config = new MapperConfiguration(cfg =>
          {
           cfg.CreateMap<AspNetUser,DirectoryViewModel>();
          });
          IMapper mapper = config.CreateMapper();
          var directory = mapper.Map<List<DirectoryViewModel>>(getDirectory);
         return Ok(new ResponseModel {Message="Get Directory List",Status="Success",Data=directory});
       }
     }
        /// <summary>
        /// TODO:Get Dealer Offer List.
        /// </summary>
        /// <returns>Dealer Offers</returns>
        [ResponseType(typeof(List<OffersViewModel>))]
        [HttpGet]
        [AllowAnonymous]
        [Route("api/GetAllOffers")]
        public IHttpActionResult GetOffers()
        {
            using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var offers = db.Offers.ToList();
                List<OffersViewModel> data = new List<OffersViewModel>();
                foreach (var item in offers)
                {
                    OffersViewModel model = new OffersViewModel();
                    model.DealerPlaceName = item.DealerName;
                    model.OrderedPartName = db.Parts.Where(d => d.Id == item.OrderedPartId).Select(d => d.PartName).SingleOrDefault();
                    model.SelectedBrand = db.Brands.Where(b => b.Id == item.BrandId).Select(b => b.BrandName).SingleOrDefault();
                    model.SelectedModel = db.Models.Where(x => x.Id == item.ModelId).Select(x => x.ModelName).SingleOrDefault();
                    model.Country = item.Country;
                    model.City = item.City;
                    data.Add(model);
                }
                return Ok(new ResponseModel { Message = "Get All Offers", Status = "Success", Data = data });
            }
        }

     /// <summary>
     /// TODO:View Particular Dealer Information.
     /// </summary>
     /// <param name="id"></param>
     /// <returns>Dealer Deatails</returns>
     [ResponseType(typeof(DealerViewModel))]
     [HttpGet]
     [AllowAnonymous]
     [Route("api/GetDealerById")]
     public IHttpActionResult GetDealerById(string id)
     {
       using (UKPartsDBEntities db = new UKPartsDBEntities())
            {
                var dealerInfo = db.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AspNetUser,DealerViewModel>();
                });
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<DealerViewModel>(dealerInfo);
                data.CountryName=db.Countries.Where(c=>c.Id == dealerInfo.CountryId).Select(c=>c.Name).SingleOrDefault();
                data.CityName = db.Cities.Where(d => d.Id == dealerInfo.CityId).Select(d => d.CityName).SingleOrDefault();
                return Ok(new ResponseModel { Message = "Get Dealer by Id", Status = "Success", Data = data });
            }
        }
    }
}
