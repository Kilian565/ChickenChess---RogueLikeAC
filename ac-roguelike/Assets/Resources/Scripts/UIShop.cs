using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    
    bool shopIsActive;
    Button[] slotButtons;
    GameObject currentUnit = null;
    public GameObject uiShop;
    public GameObject[] platzhalter;
    Text[] slottext;
    Vector3 coord;
    UnitData unit;

    bool slotIsEmpty = true;

    GameObject unitPref;
    GameObject weaponPref;


    private void Awake()
    {
        
        slotButtons = uiShop.GetComponentsInChildren<Button>();
        slottext = new Text[slotButtons.Length];
       
        for (int i = 0; i < slotButtons.Length; i++)
        {
            slottext[i] = slotButtons[i].GetComponentInChildren<Text>();

        }
        unitPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter3");
        weaponPref = Resources.Load<GameObject>("Prefabs/Kanabo_Club_Weapon");
        
        slotButtons[0].onClick.AddListener(Slot1);
        slotButtons[1].onClick.AddListener(Slot2);
        slotButtons[2].onClick.AddListener(Slot3);
        slotButtons[3].onClick.AddListener(Slot4);
        slotButtons[4].onClick.AddListener(Slot5);

    }

    void Start()
    {

    }

    void Update()
    {

        ShopOddsCalculation();
        ActivateShopText();
       // unit.weapon.gameObject.transform.position = new Vector3(unit.gameObject.transform.position.x + //unit.gameObject.transform.localScale.x / 2, unit.gameObject.transform.position.y, -1);


    }

    void ShopOddsCalculation()
    {
        if (slotIsEmpty)
        {
            foreach (var item in slotButtons)
            {
                currentUnit = platzhalter[Random.Range(0, 4)];

            }
            slotIsEmpty = false;
            Debug.Log("slots mit Units ausgestattet");
        }
    }

    void Slot1()
    {
        if (PlayerStats.playerGold > 0 && Input.GetMouseButtonUp(0))
        {
            BuyUnit();
            slottext[0].text = currentUnit.ToString();
            Debug.Log("ich wurde gedrückt: " + slotButtons[0].ToString());
            PlayerStats.playerGold = PlayerStats.playerGold - 1;
            slotIsEmpty = true;

        }
    }
    void Slot2()
    {
        if (PlayerStats.playerGold > 0 && Input.GetMouseButtonUp(0))
        {
            BuyUnit();

            slottext[1].text = currentUnit.ToString();


            Debug.Log("ich wurde gedrückt: " + slotButtons[1].ToString());
            PlayerStats.playerGold = PlayerStats.playerGold - 1;
            slotIsEmpty = true;
        }
    }
    void Slot3()
    {
        if (PlayerStats.playerGold > 0 && Input.GetMouseButtonUp(0))
        {
            BuyUnit();
            slottext[2].text = currentUnit.ToString();
            Debug.Log("ich wurde gedrückt: " + slotButtons[2].ToString());
            PlayerStats.playerGold = PlayerStats.playerGold - 1;
            slotIsEmpty = true;
        }
    }
    void Slot4()
    {
        if (PlayerStats.playerGold > 0 && Input.GetMouseButtonUp(0))
        {
            slottext[3].text = currentUnit.ToString();
            BuyUnit();
            Debug.Log("ich wurde gedrückt: " + slotButtons[3].ToString());
            PlayerStats.playerGold = PlayerStats.playerGold - 1;
            slotIsEmpty = true;

        }
    }
    void Slot5()
    {
        if (PlayerStats.playerGold > 0 && Input.GetMouseButtonUp(0))
        {
            BuyUnit();
            slottext[4].text = currentUnit.ToString();
            Debug.Log("ich wurde gedrückt: " + slotButtons[4].ToString());
            PlayerStats.playerGold = PlayerStats.playerGold - 1;
            slotIsEmpty = true;

        }
    }

    void BuyUnit()
    {
        
        unit = new UnitData("testORK", 1, false, 1, 100f, 10f, 0f, 1f, 1, 15f, 15f, 0);

        unit.gameObject = Instantiate(currentUnit);
        unit.weapon = new Weapons(1, 1, 1, 1, 1);
        unit.weapon.gameObject = Instantiate(weaponPref);
        unit.weapon.gameObject.transform.localScale = unit.gameObject.transform.localScale / 2;
        unit.weapon.gameObject.transform.Rotate(new Vector3(-45, 0, 0));
        
        coord = new Vector3(GameObject.Find("Bench 0").transform.position.x, GameObject.Find("Bench 0").transform.position.y, GameObject.Find("Bench 0").transform.position.z - 1);
        MasterScript.units.Add(unit);
        //Vector3 tempCoord = coord;
        
       
        unit.gameObject.transform.position = coord;

        unit.weapon.gameObject.transform.position = new Vector3(unit.gameObject.transform.position.x + unit.gameObject.transform.localScale.x / 2, unit.gameObject.transform.position.y, -1);


    }

    private void ActivateShopText()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shopIsActive = !shopIsActive;
        }

        if (shopIsActive)
        {
            for (int i = 0; i < slottext.Length; i++)
            {
                slottext[i].gameObject.SetActive(true);
            }

        }
        else
        {
            for (int i = 0; i < slottext.Length; i++)
            {
                slottext[i].gameObject.SetActive(false);
            }
        }
            
    }
}
