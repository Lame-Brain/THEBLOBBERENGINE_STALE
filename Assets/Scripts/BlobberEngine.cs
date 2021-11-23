using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlobberEngine {
    public class _enum
    {
        public enum CharacterClass { Fighter, Thief, Magic_User, Healer }
        public enum CharacterRace { Human, Elf, Dwarf, Monster, Goblin, Beast, Dragon, Lycanthrope, Undead, Giant}
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
}

