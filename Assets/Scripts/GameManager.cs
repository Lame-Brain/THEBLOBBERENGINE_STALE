using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GAME;

    public Item ref_item, ref_null;
    public GameObject gobbo1, gobbo2;

    private void Awake()
    {
        GAME = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Item.ItemInstance item1 = new Item.ItemInstance(ref_item);
        Item.ItemInstance item2 = new Item.ItemInstance(ref_item);
        gobbo1.GetComponent<MobLogic>().InitializeMob();
        gobbo2.GetComponent<MobLogic>().InitializeMob();

        item2.ID_Item();
        Debug.Log("This is the First Sword: " + item1.GetName() + " it deals " + item1.GetDamage() + " damage!");
        Debug.Log("This is the Second Sword: " + item2.GetName() + " it deals " + item2.GetDamage() + " damage!");

        Character pc = new Character("tester", Character.Class.Fighter, 8, 8, 8, 8, 8, 8, 8);
        Debug.Log("Hello " + pc.pc_Name + "!");

        gobbo2.GetComponent<MobLogic>().mob_data.mob_HP--;
        Debug.Log("Goblins are here! Gobbo1 has " + gobbo1.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
        Debug.Log("Goblins are here! Gobbo2 has " + gobbo2.GetComponent<MobLogic>().mob_data.mob_HP + " hp.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
