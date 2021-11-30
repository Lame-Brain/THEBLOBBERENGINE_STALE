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

        public static void Save_Roster()
        {
            string filename = Application.persistentDataPath + "/ROSTER.TBE";
            if (File.Exists(filename)) File.Delete(filename);
            Stream out_stream = File.Open(filename, FileMode.Create, FileAccess.Write);
            BinaryFormatter br = new BinaryFormatter();
            List<SaveCharacter> _saved_characters = new List<SaveCharacter>();
            for (int _i = 0; _i < ROSTER.Count; _i++) _saved_characters.Add(ROSTER[_i].SaveCharacter());
            br.Serialize(out_stream, _saved_characters);
            out_stream.Close();
        }
        public static void Load_Roster()
        {
            string filename = Application.persistentDataPath + "/ROSTER.TBE";
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                Stream in_stream = File.Open(filename, FileMode.Open);
                List<SaveCharacter> _loaded_characters = bf.Deserialize(in_stream) as List<SaveCharacter>;
                in_stream.Close();
                ROSTER.Clear();
                for (int _i = 0; _i < _loaded_characters.Count; _i++) ROSTER.Add(new PlayerCharacter(_loaded_characters[_i]));
            }
        }
        public static int NextID()
        {
            int result = 0;
            for (int _i = 0; _i < ROSTER.Count; _i++) if (ROSTER[_i].ID >= result) result = ROSTER[_i].ID;
            result++;
            return result;
        }
        public static PlayerCharacter GetMember(int n)
        {
            PlayerCharacter result = null;
            if (ROSTER[n].ID == n)
                result = ROSTER[n];
            else
                for (int _i = 0; _i < ROSTER.Count; _i++)
                    if (ROSTER[_i].ID == n) result = ROSTER[_i];
            return result;
        }
    }


}

