﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.StatisticsResult
{
    public class GetAvgRentPriceForDailyQueryResult
    {
        public decimal AvgPriceForDaily { get; set; }
    }
}
