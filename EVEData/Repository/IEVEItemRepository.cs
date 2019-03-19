using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEData.Repository
{
    public interface IEVEItemRepository
    {
        Task<List<EVEItem>> GetAllEVEItems();

        Task<EVEItem> GetEVEItem(int id);

        Task<List<EVEItem>> GetEVEItems(List<int> ids);
    }
}
