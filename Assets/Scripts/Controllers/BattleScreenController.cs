using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScreenController : MonoBehaviour
{
    public GameObject[] pcSlot;
    public List<GameObject> enemy;
    public GameObject ref_OutputPanel, ref_monsterPanelPF, ref_MPF;
    public Sprite ref_AggStanceIcon, ref_DefStanceIcon;
    
    private string buttonPushed;
    private GameObject go;

    private void Start()
    {
        StartCoroutine("DelayStart", .5f);
    }
    IEnumerator DelayStart(float n)
    {
        yield return new WaitForSeconds(n);
        for (int _i = 0; _i < enemy.Count; _i++)
        {
            go = Instantiate(ref_monsterPanelPF, ref_MPF.transform);
            UpdateEnemyGUI(go);
        }
    }

    private void UpdatePlayerGUI()
    {
        for (int _i = 0; _i < 4; _i++)
        {            
            pcSlot[_i].transform.Find("Character_Portrait").GetComponent<Image>().sprite = GameManager.GAME.PC_Portrait[GameManager.PARTY.PC[_i].portraitIndex]; //This draws the PC's portrait
            pcSlot[_i].transform.Find("Character_Name_Plate").transform.GetChild(0).GetComponent<Text>().text = GameManager.PARTY.PC[_i].characterName;//this draws the PC's name
            pcSlot[_i].transform.Find("HealthBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].health - GameManager.PARTY.PC[_i].wounds) / GameManager.PARTY.PC[_i].health; //this draws the PC's health bar
            if (GameManager.PARTY.PC[_i].wounds >= GameManager.PARTY.PC[_i].health) pcSlot[_i].transform.Find("Dead").gameObject.SetActive(true);
            if (GameManager.PARTY.PC[_i].wounds < GameManager.PARTY.PC[_i].health) pcSlot[_i].transform.Find("Dead").gameObject.SetActive(false);
            if (GameManager.PARTY.PC[_i].mana == 0) { pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(false); } //If the PC has no mana, hide the mana bar.
            else
            {
                pcSlot[_i].transform.Find("ManaBarContainer").gameObject.SetActive(true); //IF the PC has Mana, show the mana bar
                pcSlot[_i].transform.Find("ManaBarContainer").transform.GetChild(1).GetComponent<Image>().fillAmount = (GameManager.PARTY.PC[_i].mana - GameManager.PARTY.PC[_i].drain) / GameManager.PARTY.PC[_i].mana; //draw the PC's Mana bar.
            }
            if (GameManager.PARTY.PC[_i].frontLine) pcSlot[_i].transform.Find("StanceIcon").GetComponent<Image>().sprite = ref_AggStanceIcon;
            if (!GameManager.PARTY.PC[_i].frontLine) pcSlot[_i].transform.Find("StanceIcon").GetComponent<Image>().sprite = ref_DefStanceIcon;
        }
    }

    private void UpdateEnemyGUI(GameObject e)
    {
        e.transform.Find("Portrait").GetComponent<Image>().sprite = GameManager.GAME.monster_Sprite[e.GetComponent<MonsterLogic>().monsterFaceIndex]; //Draw NPC portrait
        e.transform.Find("Name").GetComponent<Text>().text = e.GetComponent<MonsterLogic>().NPC_Name; //Draw NPC name
        e.transform.Find("ID Placard").GetComponentInChildren<Text>().text = 
    }

    public void ButtonPushed(string b)
    {
        buttonPushed = b;
    }
}
