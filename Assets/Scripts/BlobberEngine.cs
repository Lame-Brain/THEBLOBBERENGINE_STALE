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
        private bool curse_status; //penalty to hit, half damage to all
        private int curse_amnt; //permanent until countered

        private bool poison_status; //lose hp every turn/step
        private int poison_amnt; //permanent until countered

        private bool slow_status; //penalty to initiative and tohit. wears off after combat        

        private bool disease_status, disease_active; //1 = strength, 2 = dexterity, 3 = max health, 4 = fatal. status = true means diseased. active = true means the disease has applied its effects
        private int disease_type, disease_value, disease_countdown; //type: see above. value: amount str, dex, or hp is reduced. countdown: turns until disease manifests

        private bool paralyze_status; //prevents character from taking actions

        private bool fear_status; //prevents character from taking offensive actions

        private bool prone_status; //Any damage taken is fatal. Character skips next action and clears this status

        private bool XP_drain_Status; //adds drain XP, and reduces MaxHp by class hitdice. fatal at level 1

        private bool stat_drain_status; //drains a stat by amnt
        private int stat_drain_type, stat_drain_amnt; //1 = str, 2 = dex, 3 = iq, 4 = wis, 5 = charm

        private bool bless_status; //bonus to hit, able to deal full damage to undead
        private int bless_amnt, bless_time;

        private bool regen_status; //regain hp every turn/step
        private int regen_amnt, regen_time;

        private bool shield_status; //bonus to defense against attacks
        private int shield_amnt, shield_time;

        private bool magic_resist_status; //A % that hostile magical effects targeting the character fail outright
        private int magic_resist_amnt, magic_resist_time;

        private bool haste_status; //bonus to initiative and toHit.
        private int haste_time;

        private bool protection_status; //protects from negative status
        private int protection_type, protection_time; //1 = curse, 2 = poison, 3 = slow, 4 = paralyze, 5 = fear, 6 = disease, 7 = level drain, 8 = all

        private bool fortify_stat_status; //1 = strength, 2 = dexterity, 3 = IQ, 4 = wisdom, 5 = charm
        private int fortify_stat_type, fortify_stat_time;

        public bool Curse() { return curse_status; }
        public void ClearCurse() { this.curse_status = false; }
        public void SetCurse(int n) 
        { 
            this.curse_status = true;
            this.curse_amnt = n;
        }

        public bool Poison() { return poison_status; }
        public void ClearPoison() { this.poison_status = false; }
        public void SetPoison(int n)
        {
            this.poison_status = true;
            this.poison_amnt = n;
        }

        public bool Slow() { return slow_status; }
        public void ClearSlow() { this.slow_status = false; }
        public void SetSlow() { this.slow_status = true; }

        public bool Disease() { return disease_status; }
        public void SetDisease(int i, int t, int c) 
        {
            this.disease_countdown = c;
            this.disease_type = t;
            this.disease_status = true;
            this.disease_active = false;
        }

        public bool Disease_active() { return disease_active; }

        public bool Paralyze() { return paralyze_status; }

        public bool Fear() { return fear_status; }

        public bool Prone() { return prone_status; }

        public bool LevelDrained() { return XP_drain_Status; }

        public bool StatDrained() { return stat_drain_status; }

        public bool Bless() { return bless_status; }

        public bool Regen() { return regen_status; }

        public bool Shield() { return shield_status; }

        public bool Magic_Resist() { return magic_resist_status; }

        public bool Haste() { return haste_status; }

        public bool Protection() { return protection_status; }

        public bool Fortify_Stat() { return fortify_stat_status; }
    }
}

