﻿using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [ChildOf(typeof(BattleUnitComponent))]
    public class SkillEntity:Entity,IAwake<int, int>,IDestroy,ITransfer
    {
        public int SkillId;
        public int SkillLevel;
        
        [BsonIgnore]
        public SkillConfig SkillConfig => SkillConfigCategory.Instance.GetByKeys(this.SkillId, this.SkillLevel);

        /// <summary>
        /// 技能释放开始时间戳
        /// </summary>
        public long SpellStartTime;
        /// <summary>
        /// 技能结束完成释放时间
        /// </summary>
        public long SpellEndTime;
        /// <summary>
        /// 冷却时间
        /// </summary>
        public int CD;
        /// <summary>
        /// 当前冷却时间
        /// </summary>
        public int CurrentCD;


        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<string, long> Groups { get; set; }
    }
}