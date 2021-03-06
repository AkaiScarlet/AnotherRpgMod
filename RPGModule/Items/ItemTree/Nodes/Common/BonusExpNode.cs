﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AnotherRpgMod.Items
{
    class BonusExpNode : ItemNodeAdvanced
    {
        new protected string m_Name = "Bonus Experience";
        new protected string m_Desc = "Add";
        new protected NodeCategory m_NodeCategory = NodeCategory.Other;
        new public float rarityWeight = 0.4f;
        public override string GetName
        {
            get
            {
                return m_Name;
            }
        }

        public override string GetDesc { get {
                return "Add " + (PercentBonus * Utils.Mathf.Clamp(GetLevel,1,GetMaxLevel)) + " % bonus Item Exp";
            } }

        public override void Passive(Item item)
        {
            item.GetGlobalItem<ItemUpdate>().bonusXp +=  0.01f * PercentBonus * GetLevel;
        }

        public int PercentBonus;    

        public override void SetPower(float value)
        {
            PercentBonus = Utils.Mathf.Clamp((int)value*5, 1, 150);
        }

        public override void LoadValue(string saveValue)
        {
            power = float.Parse(saveValue);
            SetPower(power);
        }

        public override string GetSaveValue()
        {
            return PercentBonus.ToString();
        }

    }
}
