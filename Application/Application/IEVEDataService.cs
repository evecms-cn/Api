using EVEData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IEVEDataService
    {
        Task<EVEItem> GetEVEItem(int id);

        Task<List<EVEItem>> GetEVEItems(List<int> ids);
    }
}
