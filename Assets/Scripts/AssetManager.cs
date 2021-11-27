using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public List<ItemBase> ITEMLIST = new List<ItemBase>();

    public ItemBase FindItemInList(int _id)
    {
        ItemBase result = null;
        foreach (ItemBase _ib in ITEMLIST) if (_ib.ID == _id) result = _ib;
        return result;
    }

    public List<Spell> SPELL_LIST = new List<Spell>();
    public Spell FindSpellInList(string _s)
    {
        Spell _result = null;
        foreach (Spell _as in SPELL_LIST) if (_as.spellInvoke == _s) _result = _as;
        return _result;
    }

    public List<Sprite> PORTRAITS = new List<Sprite>();
}
