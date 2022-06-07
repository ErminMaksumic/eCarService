using AutoMapper;
using eCarService.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.CarBrand, Model.CarBrand>().ReverseMap();
            CreateMap<Database.CarBrand, CarBrandUpsertRequest>().ReverseMap();

            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.User, UserInsertRequest>().ReverseMap();
            CreateMap<Database.User, UserUpdateRequest>().ReverseMap();

            CreateMap<Database.Part, Model.Part>().ReverseMap();
            CreateMap<Database.Part, PartUpsertRequest>().ReverseMap();

            CreateMap<Database.CarService, Model.CarService>().ReverseMap();
            CreateMap<Database.CarService, CarServiceInsertRequest>().ReverseMap();
            CreateMap<Database.CarService, CarServiceUpdateRequest>().ReverseMap();

            CreateMap<Database.Offer, Model.Offer>().ReverseMap();
            CreateMap<Database.Offer, OfferInsertRequest>().ReverseMap();

            CreateMap<Database.CarBrandOffer, Model.CarBrandOffer>().ReverseMap();


        }
    }
}
