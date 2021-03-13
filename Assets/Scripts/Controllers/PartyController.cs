using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartyController : MonoBehaviour
{
    public Character[] PC;
    public int money; //how much money does the party have?
    new public int light; //how many more turns of light does the party have?
    public int x_coor, y_coor, face;
    public InventoryItem[] bagInventory = new InventoryItem[20]; //What is the party carrying?

    private bool moving = false, AllowMovement = true;
    private Transform moveTarget, lookTarget, partyNode;
    private string actionQueue;
    private Transform previousPos_Rot;

    // Start is called before the first frame update
    void Start()
    {
        TeleportToDungeonStart();
        partyNode = FindMyNode().transform;
        previousPos_Rot = transform;
    }

    // Update is called once per frame
    void Update() //<------------------------------------------------------------------------------------------------ Update
    {
    }


    private void FixedUpdate() //<------------------------------------------------------------------------------------------------Fixed Update
    {
        float move = GameManager.RULES.TileSize / GameManager.RULES.moveSpeed;

        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, move * Time.deltaTime); //move transform toward moveTarget position

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookTarget.position - transform.position), GameManager.RULES.turnSpeed * Time.deltaTime); //Rotate party to look at LookTarget

//        if (Vector3.Distance(transform.position, moveTarget.position) > .1) moving = true; //If the transform is away from the moveTarget, then the party is moving.

//        if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(lookTarget.position - transform.position)) > 4) moving = true; //If the transform is away from the moveTarget, then the party is moving.

        if (Vector3.Distance(transform.position, moveTarget.position) < .1 && Quaternion.Angle(transform.rotation, Quaternion.LookRotation(lookTarget.position - transform.position)) < 4) //If the transform is close to the moveTarget, then the party is not moving.
        {
            transform.position = moveTarget.position; //"Snap" party to target location
            transform.LookAt(lookTarget.position); //"Snap" party to rotation
//            if (moving) //If the party was previously moving and is not not moving...
//            {
//                moving = false; //...then set the party to not moving and...
//                PassTurn();     //...pass the turn.
//            }
        }
    }


    public void TeleportToDungeonStart()
    {
        actionQueue = ""; //Clear the action queue

        GameObject _entrance = GameObject.FindGameObjectWithTag("MazeEntrance"); //find the entrance
        transform.position = _entrance.transform.position; //Set Party location
        transform.rotation = _entrance.transform.rotation; //Set Party rotation
        //set party facing based on rotation
        if (transform.rotation.eulerAngles.y < -135 || transform.rotation.eulerAngles.y > 135) face = 0; //facing North
        if (transform.rotation.eulerAngles.y >= 225 && transform.rotation.eulerAngles.y <= 315) face = 1; //facing East
        if (transform.rotation.eulerAngles.y > -45 && transform.rotation.eulerAngles.y < 45) face = 2; //face South
        if (transform.rotation.eulerAngles.y >= 45 && transform.rotation.eulerAngles.y <= 135) face = 3; //Face West
        //Reset moveTarget and lookTarget
        moveTarget = FindMyNode().transform;
        lookTarget = FaceMyTarget(FindMyNode(), face);
    }

    public void LoadParty(SaveSlot.serialParty p)
    {
        for (int _i = 0; _i < 4; _i++) PC[_i].LoadCharacter(p.PC[_i]);
        money = p.money;
        light = p.light;
        x_coor = p.x_coor; y_coor = p.y_coor; face = p.face;
        for (int _i = 0; _i < 20; _i++) if(p.bagInventory[_i].genericName != "") bagInventory[_i] = bagInventory[_i].LoadItem(p.bagInventory[_i]);
    }

    public GameObject FindMyNode() //returns a reference to the gameobject of the node that is in the same time as the party object
    {        
        GameObject[] _nodeList = GameObject.FindGameObjectsWithTag("Node");
        GameObject _result = null;
        int _nodeX, _nodeY;
        _nodeX = (int)((transform.position.x + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);
        _nodeY = (int)((transform.position.z + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);
        foreach (GameObject _go in _nodeList) if (_go.GetComponent<GridNode>().nodeX == _nodeX && _go.GetComponent<GridNode>().nodeY == _nodeY) _result = _go;
        return _result;
    }

    public GameObject FindNode(int x, int y) //Takes the grid coordinates of a node, not the transform, returns reference to node gameobject
    {
        GameObject[] _nodeList = GameObject.FindGameObjectsWithTag("Node");
        GameObject _result = null;
        foreach (GameObject _go in _nodeList) if (_go.GetComponent<GridNode>().nodeX == x && _go.GetComponent<GridNode>().nodeY == y) _result = _go;
        return _result;
    }
    
    public bool NodeIsValid(int x, int y)//Takes the grid coordinates of a node, not the transform, returns true if the node exists
    {
        bool _result = false;
        GameObject[] _nodeList = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject _go in _nodeList) if (_go.GetComponent<GridNode>().nodeX == x && _go.GetComponent<GridNode>().nodeY == y) _result = true;
        return _result;
    }

    public bool NotBlockedForMovement(int d)
    {
        bool _result = false;
        if (d == 0 && FindMyNode().GetComponent<GridNode>().northLink != null) _result = true;
        if (d == 1 && FindMyNode().GetComponent<GridNode>().eastLink != null) _result = true;
        if (d == 2 && FindMyNode().GetComponent<GridNode>().southLink != null) _result = true;
        if (d == 3 && FindMyNode().GetComponent<GridNode>().westLink != null) _result = true;
        return _result;
    }

    public Transform FaceMyTarget(GameObject t, int f)
    {
        Transform _result = null;
        if (f == 0) _result = t.transform.Find("North").transform;
        if (f == 1) _result = t.transform.Find("East").transform;
        if (f == 2) _result = t.transform.Find("South").transform;
        if (f == 3) _result = t.transform.Find("West").transform;

        return _result;
    }

    //public access to AllowMovement bool
    public void ToggleAllowMovement() { AllowMovement = !AllowMovement; }
    public void SetAllowedMovement(bool b) { AllowMovement = b; }
    public bool GetAllowedMovement() { return AllowMovement; }

    public void PassTurn()
    {

    }
}
