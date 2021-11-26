using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace BlobberEngine {
    public class _enum
    {
        public enum CharacterClass { Fighter, Thief, Magic_User, Healer }
        public enum CharacterRace { Human, Elf, Dwarf, Monster, Goblin, Beast, Dragon, Lycanthrope, Undead, Giant }

    }

    public static class _tool
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

    public static class Roster
    {
        public static List<PlayerCharacter> ROSTER = new List<PlayerCharacter>();

        public static void Init_Roster()
        {
            string filename = Application.dataPath + "ROSTER.TBE";
            BinaryFormatter bf = new BinaryFormatter();
            Stream filestream = File.Open(filename, FileMode.Open);
            //SaveCharacter[] _toonArray = (SaveCharacter)bf.Deserialize(filestream);
            filestream.Close();
        }
        public static int NextID()
        {
            int result = 0;
            for (int _i = 0; _i < ROSTER.Count; _i++) if (ROSTER[_i].ID >= result) result = ROSTER[_i].ID;
            result++;
            return result;
        }
    }


}

