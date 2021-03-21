﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel_Controller : MonoBehaviour
{
    public GameObject ref_mapPanel;
    public GameObject ref_mapTileEmptyPF, ref_tileImage;
    public Sprite ref_emptyTile, ref_damageTile, ref_darkTile, ref_chestTile, ref_inWall, ref_exWall, ref_doorWall, ref_torchWall, ref_player;

    private GameObject[,] maptile = new GameObject[25, 25];
    private int n = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Start by drawing the map tiles surrounding the player
        for (int y=0; y < 25; y++)
            for(int x = 0; x < 25; x++)
            {
                maptile[x, y] = Instantiate(ref_mapTileEmptyPF, ref_mapPanel.transform);
                maptile[x, y].transform.localPosition = new Vector2((x-2)*25, (y-2)*25);
            }
        DrawMap();
    }

    private void DrawMap()
    {
        //First, Destroy old map tiles
        GameObject[] _go = GameObject.FindGameObjectsWithTag("MiniMapTile");
        foreach (GameObject _t in _go) Destroy(_t);

        Debug.Log("Draw Map");
        //now draw:
        GameObject _tgo;
        int _px = (int)((GameManager.PARTY.x_coor + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize), _py = (int)((GameManager.PARTY.y_coor + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);

        for (int y = -n; y <= n; y++)
            for (int x = -n; x <= n; x++)
            {
                if(_px + x > 0 && _px + x < 16 && _py + y > 0 && _py + y < 16) //Checking array bounds of Party.map
                {
                    //Debug.Log("wot? " + (_px + x) + ", " + (_py + y) + " NDoor? " + GameManager.PARTY.mapND[_px + x, _py + y]);
                    if (GameManager.PARTY.map[_px + x, _py + y] == 0) Instantiate(ref_tileImage, maptile[x + n, y + n].transform); //draw empty tiles                    
                    if (GameManager.PARTY.mapC[_px + x, _py + y]) //draw chest
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "CHEST";
                        _tgo.GetComponent<Image>().sprite = ref_chestTile;
                    }
                    if (GameManager.PARTY.mapN[_px + x, _py + y] > 0) //draw north wall
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "North Wall";
                        if (GameManager.PARTY.mapN[_px + x, _py + y] == 1) _tgo.GetComponent<Image>().sprite = ref_exWall;
                        if (GameManager.PARTY.mapN[_px + x, _py + y] == 2) _tgo.GetComponent<Image>().sprite = ref_inWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    if (GameManager.PARTY.mapND[_px + x, _py + y]) //draw north door
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "North Door";
                        _tgo.GetComponent<Image>().sprite = ref_doorWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    if (GameManager.PARTY.mapE[_px + x, _py + y] > 0) //draw east wall
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "East Wall";
                        if (GameManager.PARTY.mapE[_px + x, _py + y] == 1) _tgo.GetComponent<Image>().sprite = ref_exWall;
                        if (GameManager.PARTY.mapE[_px + x, _py + y] == 2) _tgo.GetComponent<Image>().sprite = ref_inWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                    if (GameManager.PARTY.mapED[_px + x, _py + y]) //draw east door
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "East Door";
                        _tgo.GetComponent<Image>().sprite = ref_doorWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 270);
                    }

                    if (GameManager.PARTY.mapS[_px + x, _py + y] > 0) //draw south wall
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "South Wall";
                        if (GameManager.PARTY.mapS[_px + x, _py + y] == 1) _tgo.GetComponent<Image>().sprite = ref_exWall;
                        if (GameManager.PARTY.mapS[_px + x, _py + y] == 2) _tgo.GetComponent<Image>().sprite = ref_inWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    if (GameManager.PARTY.mapSD[_px + x, _py + y]) //draw south door
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "South Door";
                        _tgo.GetComponent<Image>().sprite = ref_doorWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }

                    if (GameManager.PARTY.mapW[_px + x, _py + y] > 0) //draw west wall
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "West Wall";
                        if (GameManager.PARTY.mapN[_px + x, _py + y] == 1) _tgo.GetComponent<Image>().sprite = ref_exWall;
                        if (GameManager.PARTY.mapN[_px + x, _py + y] == 2) _tgo.GetComponent<Image>().sprite = ref_inWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    if (GameManager.PARTY.mapWD[_px + x, _py + y]) //draw west door
                    {
                        _tgo = Instantiate(ref_tileImage, maptile[x + n, y + n].transform);
                        _tgo.name = "West Door";
                        _tgo.GetComponent<Image>().sprite = ref_doorWall;
                        _tgo.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }

                }
            }

        _tgo = Instantiate(ref_tileImage, maptile[n, n].transform);
        _tgo.GetComponent<Image>().sprite = ref_player;
        _tgo.name = "PLAYER MARK";
        if (GameManager.PARTY.face == 0) _tgo.transform.rotation = Quaternion.Euler(0, 0, 0); //North
        if (GameManager.PARTY.face == 1) _tgo.transform.rotation = Quaternion.Euler(0, 0, 270); //East
        if (GameManager.PARTY.face == 2) _tgo.transform.rotation = Quaternion.Euler(0, 0, 180); //South
        if (GameManager.PARTY.face == 3) _tgo.transform.rotation = Quaternion.Euler(0, 0, 90); //West
    }





    public void CloseMapScreen()
    {
        GetComponentInParent<ExploreController>().ClearAllScreens();
    }
    public void Navigate_Left()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenSpellCompendium(_c);
    }
    public void Navigate_Right()
    {
        int _c = GameManager.EXPLORE.selected_Character;
        GetComponentInParent<ExploreController>().ClearAllScreens();
        GetComponentInParent<ExploreController>().OpenInventoryScreen(_c);
    }
    public void ShowCloseTooltip()
    {
        Tooltip.ShowToolTip_Static("Close the Map");
    }
    public void ShowLeftArrowToolTip()
    {
        Tooltip.ShowToolTip_Static("Go to Spell Compendium");
    }
    public void ShowRightArrowToolTip()
    {
        Tooltip.ShowToolTip_Static("Go to Inventory");
    }
    public void HideLeftArrowToolTip()
    {
        Tooltip.HideToolTip_Static();
    }
}
