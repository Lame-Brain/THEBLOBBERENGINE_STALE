using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeHive))]
public class NodePlacement : Editor
{  
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Release the Nodes"))
        {
            //Init gn (GridNodes) array with plenty of extra space to prevent overflows
            GameObject[,] gn = new GameObject[32,32];

            //Find the NodeHive and load up the Node prefab
            GameObject hive = GameObject.FindGameObjectWithTag("NodeHive");
            GameObject nodePF = hive.GetComponent<NodeHive>().nodePF;

            //Clear the field of existing Nodes
            GameObject[] oldNodes = GameObject.FindGameObjectsWithTag("Node");
            foreach (GameObject oldNode in oldNodes) DestroyImmediate(oldNode);

            //Find all the floors
            GameObject[] floors = GameObject.FindGameObjectsWithTag("MapFloor");
            foreach(GameObject o in floors) 
            {
                //Adjust the X,Z position of the floors, so they are in the array with comfortable buffer on all sides
                int x = (int)(o.transform.position.x+7)/6; 
                int y = (int)(o.transform.position.z+7)/6;                
                //Instantiate my nodes, childed under the Hive
                gn[x,y] = Instantiate(nodePF, hive.transform);
                //Position them to the floor position, set rotation to 0, and load the nodeX and nodeY publics
                gn[x, y].transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 1, o.transform.position.z);
                gn[x, y].transform.rotation = Quaternion.identity;
                gn[x, y].GetComponent<GridNode>().SetNodePosition(x, y);
            }

            //Establish Direction Links
            for(int y = 0; y < 18; y++)            {
                for(int x = 0; x < 18; x++)                {
                    if(gn[x,y] != null)                            {
                        if (gn[x, y - 1] != null) gn[x, y].GetComponent<GridNode>().northLink = gn[x, y - 1];
                        if (gn[x - 1, y] != null) gn[x, y].GetComponent<GridNode>().eastLink = gn[x - 1, y];
                        if (gn[x, y + 1] != null) gn[x, y].GetComponent<GridNode>().southLink = gn[x, y + 1];
                        if (gn[x + 1, y] != null) gn[x, y].GetComponent<GridNode>().westLink = gn[x + 1 , y];
                    }
                }
            }

            //Refine Direction Links with raycasting
            for (int y = 0; y < 18; y++)                {
                for (int x = 0; x < 18; x++)               {
                    if (gn[x, y] != null)                     {
                                    RaycastHit nHit, eHit, sHit, wHit;
                                    if (Physics.Raycast(gn[x, y].transform.position, Vector3.back, out nHit, 3) && nHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().northLink = null;
                                    if (Physics.Raycast(gn[x, y].transform.position, Vector3.left, out eHit, 3) && eHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().eastLink = null;
                                    if (Physics.Raycast(gn[x, y].transform.position, Vector3.forward, out sHit, 3) && sHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().southLink = null;
                                    if (Physics.Raycast(gn[x, y].transform.position, Vector3.right, out wHit, 3) && wHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().westLink = null;
                    }
                }
            }

            //Place party at start
            int startX = (int)GameObject.FindGameObjectWithTag("Respawn").transform.position.x;
            int startY = (int)GameObject.FindGameObjectWithTag("Respawn").transform.position.z;
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(startX, 1, startY);
        }
    }
}
