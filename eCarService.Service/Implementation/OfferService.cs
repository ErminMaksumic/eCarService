using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class OfferService : CRUDService<Model.Offer, OfferSearchObject, Database.Offer, OfferUpsertRequest,
        OfferUpsertRequest>, IOfferService
    {
        public OfferService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public override Model.Offer Insert(OfferUpsertRequest request)
        {
            var offer = _mapper.Map<Offer>(request);

            _context.Offers.Add(offer);
            _context.SaveChanges();

            foreach (var brand in request.Brands)
            {
                Database.CarBrandOffer carBrandOffer = new CarBrandOffer();
                carBrandOffer.CarBrandId = brand;
                carBrandOffer.OfferId = offer.OfferId;

                _context.CarBrandOffers.Add(carBrandOffer);

                _context.SaveChanges();
            }

            foreach (var part in request.Parts)
            {
                Database.OfferPart offerPart = new OfferPart();
                offerPart.PartId = part;
                offerPart.OfferId = offer.OfferId;

                _context.OfferParts.Add(offerPart);

                _context.SaveChanges();
            }

            return _mapper.Map<Model.Offer>(offer);
        }

        public override Model.Offer Update(int id, OfferUpsertRequest request)
        {
            var entity = _context.Offers.Include("CarBrandOffers")
                .Include("OfferParts").FirstOrDefault(x=> x.OfferId == id);

            entity.Name = request.Name;
            entity.Price = request.Price;

            foreach (var item in entity.OfferParts)
            {
                _context.OfferParts.Remove(item);
            }
            foreach (var item in entity.CarBrandOffers)
            {
                _context.CarBrandOffers.Remove(item);
            }

            foreach (var brand in request.Brands)
            {
                Database.CarBrandOffer carBrandOffer = new CarBrandOffer();
                carBrandOffer.CarBrandId = brand;
                carBrandOffer.OfferId = entity.OfferId;

                _context.CarBrandOffers.Add(carBrandOffer);
            }

            foreach (var part in request.Parts)
            {
                Database.OfferPart offerPart = new OfferPart();
                offerPart.PartId = part;
                offerPart.OfferId = entity.OfferId;

                _context.OfferParts.Add(offerPart);
            }
            _context.SaveChanges();


            return _mapper.Map<Model.Offer>(entity);
        }

        public override Model.Offer GetById(int id)
        {
            var entity = _context.Offers.Include("CarBrandOffers").Include("CarBrandOffers.CarBrand").
                Include("OfferParts").Include("OfferParts.Part").
                FirstOrDefault(x => x.OfferId == id);

            return _mapper.Map<Model.Offer>(entity);
        }

        public override IQueryable<Offer> AddFilter(IQueryable<Offer> query, OfferSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.CarServiceId != null && search.CarServiceId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.CarServiceId == search.CarServiceId);
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }
            return filteredQuery;
        }

        public override void BeforeDelete(Offer entity)
        {
            var ratings = _context.Ratings.Where(x => x.OfferId == entity.OfferId ).ToList();

            _context.RemoveRange(ratings);

            var brands = _context.CarBrandOffers.Where(x => x.OfferId == entity.OfferId).ToList();

            _context.RemoveRange(brands);


            var reservations = _context.Reservations.Where(x => x.OfferId == entity.OfferId).ToList();

            _context.RemoveRange(reservations);


            var parts = _context.OfferParts.Where(x => x.OfferId == entity.OfferId).ToList();

            _context.RemoveRange(parts);

        }

        public override IQueryable<Offer> AddInclude(IQueryable<Offer> query, OfferSearchObject searchObject = null)
        {
            var includedQuery = base.AddInclude(query, searchObject);

            includedQuery = includedQuery.Include("OfferParts.Part").Include("CarBrandOffers.CarBrand");

            return includedQuery;
        }
    }
}
