using EVEData;
using EVEData.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using YamlDotNet.Serialization;

namespace Repository.EVEData
{
    public class EVEItemRepository : IEVEItemRepository
    {
        public EVEItemRepository()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"EVEData\CCPFiles\typeIDs.yaml");
            
            if(!File.Exists(path))
            {
                throw new FileNotFoundException("Can not find ccp files, can not find ccp files");
            }
            string yaml = File.ReadAllText(path);
            TextReader textReader = new StringReader(yaml);
            Deserializer deserializer = new Deserializer();
            this.allEVEItems = deserializer.Deserialize<Dictionary<int, EVEItem>>(textReader);
        }
        private readonly Dictionary<int,EVEItem> allEVEItems = null;
        public async Task<List<EVEItem>> GetAllEVEItems()
        {
            return await Task.FromResult(this.allEVEItems.Values.ToList());
        }

        public async Task<EVEItem> GetEVEItem(int id)
        {
            if(this.allEVEItems.ContainsKey(id))
            {
                return await Task.FromResult(this.allEVEItems[id]);
            }
            return null;
        }

        public async Task<List<EVEItem>> GetEVEItems(List<int> ids)
        {
            return await Task.FromResult(this.allEVEItems
                                        .Where(dic=>ids.Any(id=>id==dic.Key))
                                        .Select(pair=>pair.Value)
                                        .ToList());
        }
    }
}
