using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public Character[] PC;
    public int wealth, light;
    public Item[] bagInventory = new Item[20];

    public bool[,] miniMap;

    public enum Direction { North, East, South, West }
    public Direction facing;

    public bool AllowParyMovement;
    public Transform FaceMe;
    public string Context;
    private bool isMoving, isTurning, isInteracting, escButtonHit;
    private Transform moveTarget;
    private int xCoord, yCoord;
    private GameObject MyNode;

    const int gridSize = 132; //should match gridSize in NodePlacement

    // Start is called before the first frame update
    void Start()
    {
        //Singleton Pattern
        if (GameManager.PARTY == null)
        {
            GameManager.PARTY = this;
            DontDestroyOnLoad(GameManager.PARTY);
        }
        else { Destroy(this); }

        AllowParyMovement = true;
        miniMap = new bool[gridSize, gridSize]; for (int _y = 0; _y < gridSize; _y++) for (int _x = 0; _x < gridSize; _x++) miniMap[_x, _y] = false; //Initialize MiniMap bools
        moveTarget = GetMyNode().transform;
        FaceMe.position = transform.position + Vector3.forward;
        PC = new Character[6];

        GameManager.GAME.InitializeGame(); //<--------------------------------------------------------------KICKS OFF GAME INITIALIZATION AFTER PARTY HAS A CHANCE TO EXIST
        
    }


    void Update()
    {//------------------------------------------------------------------------------------------------------------------------------------UPDATE------------------------------------------------------------------------------------------------------------------------------
        if (AllowParyMovement)
        {
            if (!isMoving && Input.GetAxis("Vertical") > 0) //Move Forward
            {
                if (facing == Direction.North && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.East && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (facing == Direction.South && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.West && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (!isMoving && Input.GetAxis("Vertical") < 0) //Move Backward
            {
                if (facing == Direction.North && ValidMove(Direction.South)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.East && ValidMove(Direction.West)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (facing == Direction.South && ValidMove(Direction.North)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.West && ValidMove(Direction.East)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (!isMoving && Input.GetAxis("Horizontal2") > 0) //Move: Slide Right
            {
                if (facing == Direction.North && ValidMove(Direction.East)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (facing == Direction.East && ValidMove(Direction.South)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.South && ValidMove(Direction.West)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (facing == Direction.West && ValidMove(Direction.North)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (!isMoving && Input.GetAxis("Horizontal2") < 0) //Move: Slide Left
            {
                if (facing == Direction.North && ValidMove(Direction.West)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (facing == Direction.East && ValidMove(Direction.North)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.South && ValidMove(Direction.East)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (facing == Direction.West && ValidMove(Direction.South)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }
                        
            if (Input.GetAxis("Horizontal") > 0) //Move: turn right
            {
                if (!isTurning && facing == Direction.North) FaceDirection(Direction.East);
                if (!isTurning && facing == Direction.East) FaceDirection(Direction.South);
                if (!isTurning && facing == Direction.South) FaceDirection(Direction.West);
                if (!isTurning && facing == Direction.West) FaceDirection(Direction.North);

            }

            if (Input.GetAxis("Horizontal") < 0) //Move: turn left
            {
                if (!isTurning && facing == Direction.North) FaceDirection(Direction.West);
                if (!isTurning && facing == Direction.West) FaceDirection(Direction.South);
                if (!isTurning && facing == Direction.South) FaceDirection(Direction.East);
                if (!isTurning && facing == Direction.East) FaceDirection(Direction.North);

            }

            //if (!isInteracting && Input.GetKeyDown(KeyCode.Space)) //INTERACT BUTTON
            if (!isInteracting && Input.GetAxis("Submit") > 0) //INTERACT BUTTON
            {
                isInteracting = true;
                if (facing == Direction.North && MyNode.GetComponent<GridNode>().northDoor != null) MyNode.GetComponent<GridNode>().northDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.East && MyNode.GetComponent<GridNode>().eastDoor != null) MyNode.GetComponent<GridNode>().eastDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.South && MyNode.GetComponent<GridNode>().southDoor != null) MyNode.GetComponent<GridNode>().southDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.West && MyNode.GetComponent<GridNode>().westDoor != null) MyNode.GetComponent<GridNode>().westDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();

                if(Context == "Chest")
                {
                    RaycastHit hit;
                    Physics.Raycast(transform.position, transform.forward, out hit, GameManager.TILESIZE);
                    GameManager.EXPLORE.OpenChest(hit.transform.gameObject);
                }
            }
        }
        //if (Input.GetKeyUp(KeyCode.Space)) isInteracting = false; //resets inteacting flag.
        if (Input.GetAxis("Submit") == 0) isInteracting = false; //resets inteacting flag.

        //if (Input.GetKeyUp(KeyCode.Escape)) //Escape button
        if (!escButtonHit && Input.GetAxis("Cancel") > 0) //Escape button
        {
            escButtonHit = true;
            if (GameManager.EXPLORE.OverlaysOpen()) { GameManager.EXPLORE.CloseOverlays(); }
            else
            { GameManager.EXPLORE.OpenMainMenu(); }
        }
        if (Input.GetAxis("Cancel") == 0) escButtonHit = false; //resets Cancel flag.

    }//------------------------------------------------------------------------------------------------------------------------------------UPDATE------------------------------------------------------------------------------------------------------------------------------

    private void FaceDirection(Direction direction)
    {
        facing = direction;
        if (direction == Direction.North) FaceMe.position = transform.position + Vector3.forward;
        if (direction == Direction.East) FaceMe.position = transform.position + Vector3.right;
        if (direction == Direction.South) FaceMe.position = transform.position + Vector3.back;
        if (direction == Direction.West) FaceMe.position = transform.position + Vector3.left;
        StartCoroutine(RotateToDirection());
    }

    public void FinishInteracting() { isInteracting = false; }

    private bool ValidMove(Direction dir)
    {
        bool _result = true;
        if (dir == Direction.North)
        {
            //Debug.Log("Result is " + _result);
            //Debug.Log("Looking for link " + MyNode.GetComponent<GridNode>().northLink.ToString());
            //Debug.Log("Looking for door " + MyNode.GetComponent<GridNode>().northDoor.ToString());
            if (MyNode.GetComponent<GridNode>().northLink == null) _result = false;
            if (MyNode.GetComponent<GridNode>().northDoor != null) _result = MyNode.GetComponent<GridNode>().northDoor.GetComponent<Hello_I_am_a_Door>().isOpen;
            //Debug.Log("Result is now " + _result);
        }
        if (dir == Direction.East)
        {
            if (MyNode.GetComponent<GridNode>().eastLink == null) _result = false;
            if (MyNode.GetComponent<GridNode>().eastDoor != null) _result = MyNode.GetComponent<GridNode>().eastDoor.GetComponent<Hello_I_am_a_Door>().isOpen;
        }
        if (dir == Direction.South)
        {
            if (MyNode.GetComponent<GridNode>().southLink == null) _result = false;
            if (MyNode.GetComponent<GridNode>().southDoor != null) _result = MyNode.GetComponent<GridNode>().southDoor.GetComponent<Hello_I_am_a_Door>().isOpen;
        }
        if (dir == Direction.West)
        {
            if (MyNode.GetComponent<GridNode>().westLink == null) _result = false;
            if (MyNode.GetComponent<GridNode>().westDoor != null) _result = MyNode.GetComponent<GridNode>().westDoor.GetComponent<Hello_I_am_a_Door>().isOpen;
        }
        return _result;
    }

    IEnumerator MoveToDestination()
    {
        isMoving = true;
        while(Vector3.Distance(transform.position, moveTarget.position) >= .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, GameManager.MOVESPEED);
            yield return null;
        }
        isMoving = false;
        transform.position = moveTarget.position;
        FaceMe.position = transform.position + Vector3.forward; //moves FaceMe target to in front of party.
        GetMyNode();
        WhatsInFrontOfMe();
    }

    IEnumerator RotateToDirection()
    {
        isTurning = true;

        while (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(FaceMe.position - transform.position)) >= 4)
        {            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(FaceMe.position - transform.position), GameManager.TURNSPEED);

            if (facing == Direction.North) FaceMe.position = transform.position + Vector3.forward;
            if (facing == Direction.East) FaceMe.position = transform.position + Vector3.right;
            if (facing == Direction.South) FaceMe.position = transform.position + Vector3.back;
            if (facing == Direction.West) FaceMe.position = transform.position + Vector3.left;

            yield return null;
        }
        isTurning = false;
        transform.LookAt(FaceMe.position);
        WhatsInFrontOfMe();
    }

    public GameObject GetMyNode() //Returns GameObject of node in same location as party
    {
        GameObject _result = null;
        foreach (GameObject _node in GameObject.FindGameObjectsWithTag("GridNode")) if ((int)transform.position.x == (int)_node.transform.position.x && (int)transform.position.z == (int)_node.transform.position.z) _result = _node;
        if (_result != null) { xCoord = _result.GetComponent<GridNode>().nodeX; yCoord = _result.GetComponent<GridNode>().nodeY; MyNode = _result; }        
        return _result;
    }

    public GameObject GetNodeAtGridCoords(int x, int y)
    {
        GameObject _result = null;
        foreach (GameObject _node in GameObject.FindGameObjectsWithTag("GridNode")) if (x == _node.GetComponent<GridNode>().nodeX && y == _node.GetComponent<GridNode>().nodeY) _result = _node;
        return _result;
    }

    public void WhatsInFrontOfMe()
    {
        GameManager.EXPLORE.ref_Interact_Display.sprite = GameManager.GAME.ActionIcon[0];
        Context = "";
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, GameManager.TILESIZE))
        {
            if (hit.transform.tag == "MapDoor") { GameManager.EXPLORE.ref_Interact_Display.sprite = GameManager.GAME.ActionIcon[3]; Context = "Door"; }
            if (hit.transform.tag == "Chest") { GameManager.EXPLORE.ref_Interact_Display.sprite = GameManager.GAME.ActionIcon[2]; Context = "Chest"; }
            if (hit.transform.tag == "MapLadder") { GameManager.EXPLORE.ref_Interact_Display.sprite = GameManager.GAME.ActionIcon[1]; Context = "Ladder"; }
        }
    }

    public void PassTurn()
    {
        GameObject[] _all_GameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject _go in _all_GameObjects) _go.gameObject.BroadcastMessage("TurnPasses", 1, SendMessageOptions.DontRequireReceiver);

        /* --------------------------------------------------------------------------------------------------------------------------------------OLD LIGHT CODE
        if (magical_light > 0) magical_light--; //consume magical light
        for (int _i = 0; _i < 20; _i++)
        {
            if (bagInventory[_i] != null && bagInventory[_i].type == InventoryItem.equipType.light && bagInventory[_i].active)
            {
                bagInventory[_i].currentDuration--; //active lightsource reduces duration
                if (bagInventory[_i].currentDuration <= 0) bagInventory[_i] = null; //consume lightsource if the duration is exceeded.
            }
        }  --------------------------------------------------------------------------------------------------------------------------------------OLD LIGHT CODE*/

    }


}
