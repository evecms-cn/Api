using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace EVEData
{
    /// <summary>
    /// 多语言，游戏中物品的描述信息等属性用使用该对象
    /// </summary>
    public class MultipleLanguage
    {
        [YamlMember(Alias = "en")]
        public string English { get; set; }
        [YamlMember(Alias = "zh")]
        public string Chinese { get; set; }
        [YamlMember(Alias = "fr")]
        public string French { get; set; }
        [YamlMember(Alias = "ru")]
        public string Russian { get; set; }
        [YamlMember(Alias = "de")]
        public string Deutsch { get; set; }
        [YamlMember(Alias = "ja")]
        public string Japanese { get; set; }

        [YamlMember(Alias = "es")]
        public string Spanish { get; set; }

        [YamlMember(Alias = "it")]
        public string Italian { get; set; }

    }
}
