using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public Character[] PC;
    public int wealth, light;
    public Item.ItemInstance[] bagInventory = new Item.ItemInstance[20];

    public bool[,] miniMap;

    public enum Direction { North, East, South, West }
    public Direction facing;

    public bool AllowParyMovement;
    public Transform FaceMe;
    private bool isMoving, isTurning;
    private Transform moveTarget;
    private int xCoord, yCoord;
    private GameObject MyNode;

    // Start is called before the first frame update
    void Start()
    {
        AllowParyMovement = true;
        moveTarget = GetMyNode().transform;
        FaceMe.position = transform.position + Vector3.forward;
    }


    void Update()
    {//------------------------------------------------------------------------------------------------------------------------------------UPDATE------------------------------------------------------------------------------------------------------------------------------
        if (AllowParyMovement)
        {
            if (!isMoving && Input.GetKey(KeyCode.UpArrow))
            {
                if (facing == Direction.North && MyNode.GetComponent<GridNode>().northLink != null) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.East && MyNode.GetComponent<GridNode>().eastLink != null) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
                if (facing == Direction.South && MyNode.GetComponent<GridNode>().southLink != null) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.West && MyNode.GetComponent<GridNode>().westLink != null) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (moveTarget != MyNode.transform) StartCoroutine(MoveToDestination());
            }

            if (!isMoving && Input.GetKey(KeyCode.DownArrow))
            {
                if (facing == Direction.North && MyNode.GetComponent<GridNode>().southLink != null) moveTarget = MyNode.GetComponent<GridNode>().southLink.transform;
                if (facing == Direction.East && MyNode.GetComponent<GridNode>().westLink != null) moveTarget = MyNode.GetComponent<GridNode>().westLink.transform;
                if (facing == Direction.South && MyNode.GetComponent<GridNode>().northLink != null) moveTarget = MyNode.GetComponent<GridNode>().northLink.transform;
                if (facing == Direction.West && MyNode.GetComponent<GridNode>().eastLink != null) moveTarget = MyNode.GetComponent<GridNode>().eastLink.transform;
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
        }

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

    IEnumerator MoveToDestination()
    {
        isMoving = true;
        while(Vector3.Distance(transform.position, moveTarget.position) >= .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, .01f);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(FaceMe.position - transform.position), .01f);

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
