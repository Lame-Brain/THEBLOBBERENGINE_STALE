using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour
{
    public GameObject northLink;
    public GameObject eastLink;
    public GameObject southLink;
    public GameObject westLink;
    public int nodeX, nodeY;
    public InventoryItem[] inventory = new InventoryItem[9];

    private void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.color = Color.red;
        if (northLink != null) Gizmos.DrawLine(new Vector3(transform.position.x + .25f, 1, transform.position.z), new Vector3(northLink.transform.position.x + .25f, 1, northLink.transform.position.z));
        Gizmos.color = Color.yellow;
        if (eastLink != null) Gizmos.DrawLine(new Vector3(transform.position.x, 1, transform.position.z + .25f), new Vector3(eastLink.transform.position.x, 1, eastLink.transform.position.z + .25f));
        Gizmos.color = Color.blue;
        if (southLink != null) Gizmos.DrawLine(new Vector3(transform.position.x - .25f, 1, transform.position.z), new Vector3(southLink.transform.position.x - .25f, 1, southLink.transform.position.z));
        Gizmos.color = Color.cyan;
        if (westLink != null) Gizmos.DrawLine(new Vector3(transform.position.x, 1, transform.position.z - .25f), new Vector3(westLink.transform.position.x, 1, westLink.transform.position.z - .25f));
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
    }
}
