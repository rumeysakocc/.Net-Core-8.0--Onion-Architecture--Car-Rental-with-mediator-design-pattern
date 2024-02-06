using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResult;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.Read
{
    public class GetCarBrandAndModelByRendPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRendPriceDailyMinQuery, GetCarBrandAndModelByRendPriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRendPriceDailyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRendPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRendPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarBrandAndModelByRendPriceDailyMin();
            return new GetCarBrandAndModelByRendPriceDailyMinQueryResult
            {
                CarBrandAndModelByRentPriceDailyMin = values,
            };
        }
    }
}
