using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlobberEngine {
    public class _enum
    {
        public enum CharacterClass { Fighter, Thief, Magic_User, Healer }
        public enum CharacterRace { Human, Elf, Dwarf, Monster, Goblin, Beast, Dragon, Lycanthrope, Undead, Giant }

    }

    public class _tool
    {
        public static int dice(int _sides)
        {
            return Random.Range(1, _sides);
        }
        public static int dice(int _number, int _sides)
        {
            int _result = 0;
            for (int _i = 0; _i < _sides; _i++)
                _result += Random.Range(1, _sides);
            return _result;
        }
    }

    public class CharacterCondition
    {
        public int ConditionType;
        public int ConditionTimer;
        public int ConditionAmount;

        public CharacterCondition(int _type, int _timer, int _amount)
        {
            this.ConditionType = _type;
            this.ConditionTimer = _timer;
            this.ConditionAmount = _amount;
        }
        public int[] SaveCondition()
        {
            int[] result = new int[3];
            result[0] = this.ConditionType;
            result[1] = this.ConditionTimer;
            result[2] = this.ConditionAmount;
            return result;
        }
        public void LoadCondition(int[] _data)
        {
            this.ConditionType = _data[0];
            this.ConditionTimer = _data[1];
            this.ConditionAmount = _data[2];
        }
    }
}

