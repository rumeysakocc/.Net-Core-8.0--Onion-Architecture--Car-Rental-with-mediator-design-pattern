﻿using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingresults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarsQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCarPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarsQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingId = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarId =x.CarID
            }).ToList();
        }
    }
}
