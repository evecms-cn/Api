using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace EVEData
{
    /// <summary>
    /// 游戏中的属性加成
    /// </summary>
    public class Bonus
    {
        [YamlMember(Alias = "bonusText")]
        public MultipleLanguage BonusText { get; set; }
        [YamlMember(Alias = "importance")]
        public int Importance { get; set; }
        [YamlMember(Alias = "bonus")]
        public decimal Value { get; set; }
        [YamlMember(Alias = "unitID")]
        public int UnitID { get; set; }
    }
}
