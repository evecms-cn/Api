using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace EVEData
{
    /// <summary>
    /// 游戏中的物品类型，包含但不限于星域，星系，商品，NPC，空间实体等
    /// </summary>
    public class EVEItem
    {
        [YamlMember(Alias = "groupID")]
        public int GroupId { get; set; }
        [YamlMember(Alias = "name")]
        public MultipleLanguage Name { get; set; }
        [YamlMember(Alias = "published")]
        public bool Published { get; set; }
        [YamlMember(Alias = "masteries")]
        public Dictionary<int,int[]> Masteries { get; set; }
        [YamlMember(Alias = "factionID")]
        public int FactionID { get; set; }
        [YamlMember(Alias = "portionSize")]
        public int PortionSize { get; set; }
        [YamlMember(Alias = "radius")]
        public decimal Radius { get; set; }
        [YamlMember(Alias = "volume")]
        public decimal Volume { get; set; }
        [YamlMember(Alias = "description")]
        public MultipleLanguage Description { get; set; }
        [YamlMember(Alias = "graphicID")]
        public int GraphicID { get; set; }
        [YamlMember(Alias = "mass")]
        public string Mass { get; set; }
        [YamlMember(Alias = "soundID")]
        public int SoundID { get; set; }
        [YamlMember(Alias = "iconID")]
        public int IconID { get; set; }
        [YamlMember(Alias = "basePrice")]
        public decimal BasePrice { get; set; }
        [YamlMember(Alias = "marketGroupID")]
        public int MarketGroupID { get; set; }
        [YamlMember(Alias = "raceID")]
        public int RaceID { get; set; }
        [YamlMember(Alias = "sofFactionName")]
        public string SofFactionName { get; set; }
        [YamlMember(Alias = "capacity")]
        public decimal Capacity { get; set; }
        [YamlMember(Alias = "traits")]
        public Traits Traits { get; set; }
        [YamlMember(Alias = "sofMaterialSetID")]
        public int SofMaterialSetID { get; set; }
    }

   
}
