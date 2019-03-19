using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace EVEData
{
    /// <summary>
    /// 飞船等的加成信息信息描述
    /// </summary>
    public class Traits
    {
        [YamlMember(Alias = "roleBonuses")]
        public List<Bonus> RoleBonuses { get; set; }

        [YamlMember(Alias = "miscBonuses")]
        public List<Bonus> MiscBonuses { get; set; }

        [YamlMember(Alias = "types")]
        public Dictionary<int, List<Bonus>> Types { get; set; }
    }
}
