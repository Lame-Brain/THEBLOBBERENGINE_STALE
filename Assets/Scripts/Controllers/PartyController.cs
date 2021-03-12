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

    private bool moving = false;
    private Transform moveTarget, lookTarget, partyNode;
    private List<string> actionQueue = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        TeleportToDungeonStart();
        partyNode = FindMyNode().transform;
    }

    // Update is called once per frame
    void Update() //<------------------------------------------------------------------------------------------------ Update
    {
        //keep x_coor and y_coor up-to-date
        x_coor = (int)transform.position.x; y_coor = (int)transform.position.z;

    }


    private void FixedUpdate() //<------------------------------------------------------------------------------------------------Fixed Update
    {
        float move = GameManager.RULES.TileSize / GameManager.RULES.moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, move * Time.deltaTime); //move transform toward moveTarget position

        if (Vector3.Distance(transform.position, moveTarget.position) > .1) moving = true; //If the transform is away from the moveTarget, then the party is moving.

        if (Vector3.Distance(transform.position, moveTarget.position) < .1) //If the transform is close to the moveTarget, then the party is not moving.
        {
            transform.position = moveTarget.position; //"Snap" party to target location
            if (moving) //If the party was previously moving and is not not moving...
            {
                moving = false; //...then set the party to not moving and...
                PassTurn();     //...pass the turn.
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookTarget.position - transform.position), GameManager.RULES.turnSpeed * Time.deltaTime); //Rotate party to look at LookTarget
    }


    public void TeleportToDungeonStart()
    {
        actionQueue.Clear();
        GameObject _entrance = GameObject.FindGameObjectWithTag("MazeEntrance");
        transform.position = _entrance.transform.position;
        transform.rotation = _entrance.transform.rotation;
        if (transform.rotation.eulerAngles.y < -135 || transform.rotation.eulerAngles.y > 135) face = 0; //facing North
        if (transform.rotation.eulerAngles.y >= 225 && transform.rotation.eulerAngles.y <= 315) face = 1; //facing East
        if (transform.rotation.eulerAngles.y > -45 && transform.rotation.eulerAngles.y < 45) face = 2; //face South
        if (transform.rotation.eulerAngles.y >= 45 && transform.rotation.eulerAngles.y <= 135) face = 3; //Face West
    }

    public void LoadParty(SaveSlot.serialParty p)
    {
        for (int _i = 0; _i < 4; _i++) PC[_i].LoadCharacter(p.PC[_i]);
        money = p.money;
        light = p.light;
        x_coor = p.x_coor; y_coor = p.y_coor; face = p.face;
        for (int _i = 0; _i < 20; _i++) if(p.bagInventory[_i].genericName != "") bagInventory[_i] = bagInventory[_i].LoadItem(p.bagInventory[_i]);
    }

    public GameObject FindMyNode()
    {
        //public float TileSize; //Find location by adding half this value, then dividing by this value to x and z
        GameObject[] _nodeList = GameObject.FindGameObjectsWithTag("Node");
        GameObject _result = null;
        int _nodeX, _nodeY;
        _nodeX = (int)((transform.position.x + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);
        _nodeY = (int)((transform.position.z + (GameManager.RULES.TileSize / 2)) / GameManager.RULES.TileSize);
        foreach (GameObject _go in _nodeList) if (_go.GetComponent<GridNode>().nodeX == _nodeX && _go.GetComponent<GridNode>().nodeY == _nodeY) _result = _go;
        return _result;
    }

    public Transform FaceMyTarget(GridNode t, int f)
    {
        Transform _result = null;
        if (f == 0) _result = t.northLink.transform;
        if (f == 1) _result = t.eastLink.transform;
        if (f == 2) _result = t.southLink.transform;
        if (f == 3) _result = t.westLink.transform;

        return _result;
    }


    public void PassTurn()
    {

    }
}
