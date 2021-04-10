using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeHive))]
public class NodePlacement : Editor
{
    const int gridSize = 132;
    const int tileSize = 2;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Release the Nodes"))
        {
            //Init gn (GridNodes) array with plenty of extra space to prevent overflows
            GameObject[,] gn = new GameObject[gridSize, gridSize];

            //Find the NodeHive and load up the Node prefab (and the rules)
            GameObject hive = GameObject.FindGameObjectWithTag("NodeHive");
            GameObject nodePF = hive.GetComponent<NodeHive>().nodePF;

            //Clear the field of existing Nodes
            GameObject[] oldNodes = GameObject.FindGameObjectsWithTag("GridNode");
            foreach (GameObject oldNode in oldNodes) DestroyImmediate(oldNode);

            //Find all the floors
            GameObject[] floors = GameObject.FindGameObjectsWithTag("MapFloor");
            foreach (GameObject o in floors)
            {
                //Adjust the X,Z position of the floors, so they are in the array with comfortable buffer on all sides
                int x = (int)(o.transform.position.x + (gridSize / 2)) / tileSize;
                int y = (int)(o.transform.position.z + (gridSize / 2)) / tileSize;

                //Instantiate my nodes, childed under the Hive
                gn[x, y] = Instantiate(nodePF, hive.transform);

                //Position them to the floor position, set rotation to 0, and load the nodeX and nodeY publics
                gn[x, y].transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 1.5f, o.transform.position.z);
                gn[x, y].transform.rotation = Quaternion.identity; //rotate to 0,0,0
                gn[x, y].GetComponent<GridNode>().SetNodePosition(x, y); //establish node in grid

                //Set door links to null, until I can refine them with raycasting.
                gn[x, y].GetComponent<GridNode>().northDoor = null;
                gn[x, y].GetComponent<GridNode>().eastDoor = null;
                gn[x, y].GetComponent<GridNode>().southDoor = null;
                gn[x, y].GetComponent<GridNode>().westDoor = null;
            }

            //Establish Direction Links
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    //if (gn[x, y] == null) Debug.Log(x + ", " + y + " is null");
                    if (gn[x, y] != null) Debug.Log(x + ", " + y + " is valid");
                    if (gn[x, y] != null)
                    {                        
                        if (gn[x, y + 1] != null) gn[x, y].GetComponent<GridNode>().northLink = gn[x, y + 1];
                        if (gn[x + 1, y] != null) gn[x, y].GetComponent<GridNode>().eastLink = gn[x + 1, y];
                        if (gn[x, y - 1] != null) gn[x, y].GetComponent<GridNode>().southLink = gn[x, y - 1];
                        if (gn[x - 1, y] != null) gn[x, y].GetComponent<GridNode>().westLink = gn[x - 1, y];                        
                    }
                }
            }
            //Refine Direction Links with raycasting
            /*float d = tileSize;
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (gn[x, y] != null)
                    {
                        RaycastHit nHit, eHit, sHit, wHit;
                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.back, out nHit, d) && nHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().northLink = null;
                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.back, out nHit, d) && nHit.transform.tag == "MapDoor") gn[x, y].GetComponent<GridNode>().northDoor = nHit.transform.gameObject;

                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.left, out eHit, d) && eHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().eastLink = null;
                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.left, out eHit, d) && eHit.transform.tag == "MapDoor") gn[x, y].GetComponent<GridNode>().eastDoor = eHit.transform.gameObject;

                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.forward, out sHit, d) && sHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().southLink = null;
                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.forward, out sHit, d) && sHit.transform.tag == "MapDoor") gn[x, y].GetComponent<GridNode>().southDoor = sHit.transform.gameObject;

                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.right, out wHit, d) && wHit.transform.tag != "MapDoor") gn[x, y].GetComponent<GridNode>().westLink = null;
                        if (Physics.Raycast(gn[x, y].transform.position, Vector3.right, out wHit, d) && wHit.transform.tag == "MapDoor") gn[x, y].GetComponent<GridNode>().westDoor = wHit.transform.gameObject;
                    }
                }
            } */
        }
    }
}
