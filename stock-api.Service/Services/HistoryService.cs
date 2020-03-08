using System;
using System.Collections.Generic;
using History_api.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;

namespace stock_api.Service.Services
{
    public class HistoryService : BaseService<History>
    {
        private HistoryRepository customRepository;
        public HistoryService(IConfiguration configuration)
        {
            customRepository = new HistoryRepository(configuration);
            repository = customRepository;            
        }

        public IList<History> SelectAllFromStock(int idStock)
        {
            if (idStock == 0)
                throw new ArgumentException("The Stock Id can't be zero.");

            return customRepository.SelectAllFromStock(idStock);
        }
    }
}
