using Application;
using EVEData;
using EVEData.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEDataProvider
{
    public class EVEDataService : IEVEDataService
    {
        private IEVEItemRepository repository;
        public EVEDataService(IEVEItemRepository repository)
        {
            this.repository = repository;
        }
        public async Task<EVEItem> GetEVEItem(int id)
        {
            return await this.repository.GetEVEItem(id);
        }

        public async Task<List<EVEItem>> GetEVEItems(List<int> ids)
        {
            return await this.repository.GetEVEItems(ids);
        }
    }
}
