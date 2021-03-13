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

        //Debug.Log(Quaternion.Angle(transform.rotation, Quaternion.LookRotation(lookTarget.position - transform.position)));
        //Debug.Log(moveTarget.position.x + ", " + moveTarget.position.z);
        //Debug.Log(lookTarget.position.x + ", " + lookTarget.position.z);

        //Determine if camera is moving or rotating;

        //keep x_coor and y_coor up-to-date
        x_coor = (int)transform.position.x; y_coor = (int)transform.position.z;

        if (AllowMovement) //I want to be able to pause movement and input while in menus
        {
            //Process button presses to build the action queue
            if (!moving && Input.GetAxisRaw("Vertical") > 0) StartCoroutine(DelayInput("UP", GameManager.RULES.MoveDelay));
            if (!moving && Input.GetAxisRaw("Vertical") < 0) StartCoroutine(DelayInput("DOWN", GameManager.RULES.MoveDelay));
            if (!moving && Input.GetAxisRaw("Horizontal2") < 0) StartCoroutine(DelayInput("LEFT", GameManager.RULES.MoveDelay));
            if (!moving && Input.GetAxisRaw("Horizontal2") > 0) StartCoroutine(DelayInput("RIGHT", GameManager.RULES.MoveDelay));
            if (!moving && Input.GetAxisRaw("Horizontal") > 0) StartCoroutine(DelayInput("SLIDE_RIGHT", GameManager.RULES.MoveDelay));
            if (!moving && Input.GetAxisRaw("Horizontal") < 0) StartCoroutine(DelayInput("SLIDE_LEFT", GameManager.RULES.MoveDelay));

            //convert party location to gridnode coordinates
            int x = (int)((transform.position.x + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);
            int y = (int)((transform.position.z + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);

            if (actionQueue == "UP")
            {
                //Debug.Log("Where am I going? Here: (" + (int)moveTarget.position.x + ", " + (int)moveTarget.position.z + ")");
                if (face == 0 && NodeIsValid(x, y - 1) && NotBlockedForMovement(face)) moveTarget = FindNode(x, y - 1).transform;
                if (face == 1 && NodeIsValid(x - 1, y) && NotBlockedForMovement(face)) moveTarget = FindNode(x - 1, y).transform;
                if (face == 2 && NodeIsValid(x, y + 1) && NotBlockedForMovement(face)) moveTarget = FindNode(x, y + 1).transform;
                if (face == 3 && NodeIsValid(x + 1, y) && NotBlockedForMovement(face)) moveTarget = FindNode(x + 1, y).transform;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            if (actionQueue == "DOWN")
            {
                if (face == 0 && NodeIsValid(x, y + 1) && NotBlockedForMovement(2)) moveTarget = FindNode(x, y + 1).transform;
                if (face == 1 && NodeIsValid(x + 1, y) && NotBlockedForMovement(3)) moveTarget = FindNode(x + 1, y).transform;
                if (face == 2 && NodeIsValid(x, y - 1) && NotBlockedForMovement(0)) moveTarget = FindNode(x, y - 1).transform;
                if (face == 3 && NodeIsValid(x - 1, y) && NotBlockedForMovement(1)) moveTarget = FindNode(x - 1, y).transform;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            if (actionQueue == "LEFT")
            {
                face--;
                if (face < 0) face = 3;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            if (actionQueue == "RIGHT")
            {
                face++;
                if (face > 3) face = 0;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            if (actionQueue == "SLIDE_LEFT")
            {
                if (face == 0 && NodeIsValid(x + 1, y) && NotBlockedForMovement(3)) moveTarget = FindNode(x + 1, y).transform;
                if (face == 1 && NodeIsValid(x, y - 1) && NotBlockedForMovement(0)) moveTarget = FindNode(x, y - 1).transform;
                if (face == 2 && NodeIsValid(x - 1, y) && NotBlockedForMovement(1)) moveTarget = FindNode(x - 1, y).transform;
                if (face == 3 && NodeIsValid(x, y + 1) && NotBlockedForMovement(2)) moveTarget = FindNode(x, y + 1).transform;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            if (actionQueue == "SLIDE_RIGHT")
            {
                if (face == 0 && NodeIsValid(x - 1, y) && NotBlockedForMovement(1)) moveTarget = FindNode(x - 1, y).transform;
                if (face == 1 && NodeIsValid(x, y + 1) && NotBlockedForMovement(2)) moveTarget = FindNode(x, y + 1).transform;
                if (face == 2 && NodeIsValid(x + 1, y) && NotBlockedForMovement(3)) moveTarget = FindNode(x + 1, y).transform;
                if (face == 3 && NodeIsValid(x, y - 1) && NotBlockedForMovement(0)) moveTarget = FindNode(x, y - 1).transform;
                lookTarget = FaceMyTarget(moveTarget.gameObject, face);
            }
            actionQueue = "";
        }
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

    IEnumerator DelayInput(string i, float n)
    {
        actionQueue = i;
        moving = true;

        yield return new WaitForSecondsRealtime(n);

        moving = false;
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
        bool _result = false; GameObject _node = FindMyNode();
        //Check if there is a link. If there is a link, is there a door? If there is a door, is it open?
        if (d == 0 && _node.GetComponent<GridNode>().northLink != null)
        {
            if (_node.GetComponent<GridNode>().northDoor == null) _result = true;
            if (_node.GetComponent<GridNode>().northDoor != null && _node.GetComponent<GridNode>().northDoor.GetComponent<Hello_I_am_a_door>().doorOpen) _result = true;
        }
        if (d == 1 && _node.GetComponent<GridNode>().eastLink != null)
        {
            if (_node.GetComponent<GridNode>().eastDoor == null) _result = true;
            if (_node.GetComponent<GridNode>().eastDoor != null && _node.GetComponent<GridNode>().eastDoor.GetComponent<Hello_I_am_a_door>().doorOpen) _result = true;
        }
        if (d == 2 && _node.GetComponent<GridNode>().southLink != null)
        {
            if (_node.GetComponent<GridNode>().southDoor == null) _result = true;
            if (_node.GetComponent<GridNode>().southDoor != null && _node.GetComponent<GridNode>().southDoor.GetComponent<Hello_I_am_a_door>().doorOpen) _result = true;
        }
        if (d == 3 && _node.GetComponent<GridNode>().westLink != null)
        {
            if (_node.GetComponent<GridNode>().westDoor == null) _result = true;
            if (_node.GetComponent<GridNode>().westDoor != null && _node.GetComponent<GridNode>().westDoor.GetComponent<Hello_I_am_a_door>().doorOpen) _result = true;
        }
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
