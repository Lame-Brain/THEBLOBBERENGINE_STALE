using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public Character[] PC;
    public int wealth, light;
    public Item[] Starting_bagInventory = new Item[20];
    public Item.ItemInstance[] bagInventory = new Item.ItemInstance[20];

    public bool[,] miniMap;

    public enum Direction { North, East, South, West }
    public Direction facing;

    public bool AllowParyMovement;
    public Transform FaceMe;
    private bool isMoving, isTurning, isInteracting;
    private Transform moveTarget;
    private int xCoord, yCoord;
    private GameObject MyNode;

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

        for (int _i = 0; _i < bagInventory.Length; _i++) bagInventory[_i] = new Item.ItemInstance();
        AllowParyMovement = true;
        moveTarget = GetMyNode().transform;
        FaceMe.position = transform.position + Vector3.forward;
        PC = new Character[6];

        GameManager.GAME.InitializeGame(); //<--------------------------------------------------------------KICKS OFF GAME INITIALIZATION AFTER PARTY HAS A CHANCE TO EXIST
        
    }


    void Update()
    {//------------------------------------------------------------------------------------------------------------------------------------UPDATE------------------------------------------------------------------------------------------------------------------------------
        if (AllowParyMovement)
        {
            if (!isMoving && Input.GetKey(KeyCode.UpArrow))
            {
                if (facing == Direction.North && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.East && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (facing == Direction.South && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.West && ValidMove(facing)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (!isMoving && Input.GetKey(KeyCode.DownArrow))
            {
                if (facing == Direction.North && ValidMove(Direction.South)) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.East && ValidMove(Direction.West)) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (facing == Direction.South && ValidMove(Direction.North)) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.West && ValidMove(Direction.East)) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!isTurning && facing == Direction.North) FaceDirection(Direction.East);
                if (!isTurning && facing == Direction.East) FaceDirection(Direction.South);
                if (!isTurning && facing == Direction.South) FaceDirection(Direction.West);
                if (!isTurning && facing == Direction.West) FaceDirection(Direction.North);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!isTurning && facing == Direction.North) FaceDirection(Direction.West);
                if (!isTurning && facing == Direction.West) FaceDirection(Direction.South);
                if (!isTurning && facing == Direction.South) FaceDirection(Direction.East);
                if (!isTurning && facing == Direction.East) FaceDirection(Direction.North);

            }

            if (!isInteracting && Input.GetKeyDown(KeyCode.Space)) //INTERACT BUTTON
            {
                isInteracting = true;
                if (facing == Direction.North && MyNode.GetComponent<GridNode>().northDoor != null) MyNode.GetComponent<GridNode>().northDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.East && MyNode.GetComponent<GridNode>().eastDoor != null) MyNode.GetComponent<GridNode>().eastDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.South && MyNode.GetComponent<GridNode>().southDoor != null) MyNode.GetComponent<GridNode>().southDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
                if (facing == Direction.West && MyNode.GetComponent<GridNode>().westDoor != null) MyNode.GetComponent<GridNode>().westDoor.GetComponent<Hello_I_am_a_Door>().Interact_With_Me();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) isInteracting = false; //resets inteacting flag.

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
        GetMyNode();
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
}
