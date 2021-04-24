using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapTile: MonoBehaviour
{
    public bool fillSolid;
    public bool northWall;
    public bool eastWall;
    public bool southWall;
    public bool westWall;
    public bool NE_Corner;
    public bool SE_Corner;
    public bool SW_Corner;
    public bool NW_Corner;
    public bool northDoor;
    public bool eastDoor;
    public bool southDoor;
    public bool westDoor;
    public bool trap;
    public bool chest;
    public bool poi;
    public bool upStairs;
    public bool downStairs;

    public void InitMiniMapTile()
    {
        this.fillSolid = true;
        this.northWall = false;
        this.eastWall = false;
        this.southWall = false;
        this.westWall = false;
        this.NE_Corner = false;
        this.SE_Corner = false;
        this.SW_Corner = false;
        this.NW_Corner = false;
        this.northDoor = false;
        this.eastDoor = false;
        this.southDoor = false;
        this.westDoor = false;
        this.trap = false;
        this.chest = false;
        this.poi = false;
        this.upStairs = false;
        this.downStairs = false;
    }
}
