using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using stock_api.Domain.Entities;
using stock_api.Model;

namespace stock_api.Profiles
{
    public class StockProfiler : Profile
    {
        public StockProfiler()
        {
            CreateMap<Stock, StockViewModel>();
        }
    }
}
