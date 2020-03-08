using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;
using stock_api.Infra.Repositories;

namespace stock_api.Service.Services
{
    public class StockService : BaseService<Stock>
    {

        private StockRepository customRepository;
        public StockService(IConfiguration configuration)
        {            
            customRepository = new StockRepository(configuration);
            repository = customRepository;
        }


        public IList<Stock> SelectFomCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("The code can't be empty.");

            return customRepository.SelectFomCode(code);
        }
    }
}
