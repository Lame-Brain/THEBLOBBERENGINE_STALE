using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour
{
    public GameObject northLink;
    public GameObject eastLink;
    public GameObject southLink;
    public GameObject westLink;
    public GameObject northDoor;
    public GameObject eastDoor;
    public GameObject southDoor;
    public GameObject westDoor;
    [HideInInspector]
    public bool northChest = false, eastChest = false, southChest = false, westChest = false;
    public int nodeX, nodeY;
    public InventoryItem[] inventory = new InventoryItem[9];

    public int trapLevel, trapDamage;

    private void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1);
    }

    private void Awake()
    {
        DynamicProps();
    }

    public void SetNodePosition(int x, int y)
    {
        nodeX = x;
        nodeY = y;
    }

    public void DynamicProps()
    {
        int _count = 0;
        for(int _i = 0; _i < inventory.Length; _i++)
        {
            if (inventory[_i] != null) _count++;
        }
        if (_count == 0) { transform.Find("BagSprite").gameObject.SetActive(false); }
        else { transform.Find("BagSprite").gameObject.SetActive(true); }
    }
}
