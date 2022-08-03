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

            CreateMap<Database.Offer, Model.Offer>().ForMember(x => x.Parts, opts => opts.MapFrom(x => x.OfferParts.Select(x => x.Part).ToList()))
            .ForMember(x => x.CarBrands, opts => opts.MapFrom(x => x.CarBrandOffers.Select(x => x.CarBrand).ToList()));

            CreateMap<Database.Offer, OfferUpsertRequest>().ReverseMap();
            CreateMap<Database.OfferPart, Model.OfferPart>().ReverseMap();

            CreateMap<Database.CarBrandOffer, Model.CarBrandOffer>().ReverseMap();

            CreateMap<Database.Rating, Model.Rating>().ReverseMap();
            CreateMap<Database.Rating, RatingUpsertRequest>().ReverseMap();

            CreateMap<Database.AdditionalService, Model.AdditionalService>().ReverseMap();
            CreateMap<Database.AdditionalService, AdditionalServiceUpsertRequest>().ReverseMap();

            CreateMap<Database.Reservation, Model.Reservation>().ReverseMap();
            CreateMap<Database.Reservation, ReservationInsertRequest>().ReverseMap();

            CreateMap<Database.Role, Model.Role>().ReverseMap();


            CreateMap<Database.ReservationsAdditionalService, Model.ReservationAdditionalService>().ReverseMap();

            CreateMap<Database.CustomOfferRequest, Model.CustomOfferRequest>().ReverseMap();
            CreateMap<Database.CustomOfferRequest, CustomOfferUpsertRequest>().ReverseMap();



        }
    }
}
