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
    //[HideInInspector]
    public bool northTorch = false, eastTorch = false, southTorch = false, westTorch = false;

    public int nodeX, nodeY;
    //public InventoryItem[] inventory = new InventoryItem[9];

    public int trapLevel, trapDamage;
    public bool trapDark;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, .25f);
    }

    private void Awake()
    {
        DynamicProps();
    }

    private void Start()
    {
    }

    public void SetNodePosition(int x, int y)
    {
        nodeX = x;
        nodeY = y;
    }

    public void DynamicProps()
    {
    }
    public void TurnPasses()
    {
        for (int _i = 0; _i < 9; _i++)
        {
        }
    }

}
