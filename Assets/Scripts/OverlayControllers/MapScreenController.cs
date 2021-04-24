using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreenController : MonoBehaviour
{
    const int gridSize = 132; //should match gridSize in NodePlacement
    private int myX, myY;

    public GameObject[] REF_TILES;

    private void Start()
    {
        myX = GameManager.PARTY.GetMyNode().GetComponent<GridNode>().nodeX;
        myY = GameManager.PARTY.GetMyNode().GetComponent<GridNode>().nodeY;
        DrawMiniMap();
    }
    public void CloseMapScreen()
    {
        GameManager.EXPLORE.CloseOverlays();
    }
    public void MoveMapUp()
    {

    }
    public void MoveMapRight()
    {

    }
    public void MoveMapDown()
    {

    }
    public void MoveMapLeft()
    {

    }
    public void DrawMiniMap()
    {
        for(int _y = -3; _y < 5; _y++)
            for(int _x = -4; _x < 5; _x++)
            {
                if (myX + _x > 0 && myX + _x < gridSize && myY + _y > 0 && myY + _y < gridSize)
                {
                    Debug.Log((_y + 3) + " *  9  + " + (_x + 4) + " = " + ((_y + 3) * 9 + (_x + 4)));
                    if (!GameManager.MAP[myX + _x, myY + _y].fillSolid)
                        REF_TILES[(_y + 3) * 9 + (_x + 4)].GetComponent<Image>().sprite = GameManager.GAME.MiniMapTileIcon[0];
                }
            }
    }
}
