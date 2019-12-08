using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    Button[] slotButtons;
    GameObject currentUnit = null;
    public GameObject uiShop;
    public GameObject[] platzhalter;

    bool slotIsEmpty = true;

    GameObject unitPref;


    private void Awake()
    {
        slotButtons = uiShop.GetComponentsInChildren<Button>();	
        unitPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter3");
    }

    void Start ()
    {
        
        slotButtons[0].onClick.AddListener(Slot1);
        slotButtons[1].onClick.AddListener(Slot2);
        slotButtons[2].onClick.AddListener(Slot3);
        slotButtons[3].onClick.AddListener(Slot4);
        slotButtons[4].onClick.AddListener(Slot5);
       
	}
	
	void Update ()
    {
        ShopOddsCalculation();
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
        BuyUnit();
        Debug.Log("ich wurde gedrückt: " + slotButtons[0].ToString());
        PlayerStats.playerGold = PlayerStats.playerGold - 1;
    }
    void Slot2()
    {
        BuyUnit();
        Debug.Log("ich wurde gedrückt: " + slotButtons[1].ToString());
        PlayerStats.playerGold = PlayerStats.playerGold - 1;
    }
    void Slot3()
    {
        BuyUnit();
        Debug.Log("ich wurde gedrückt: " + slotButtons[2].ToString());
        PlayerStats.playerGold = PlayerStats.playerGold - 1;
    }
    void Slot4()
    {
        BuyUnit();
        Debug.Log("ich wurde gedrückt: " + slotButtons[3].ToString());
        PlayerStats.playerGold = PlayerStats.playerGold - 1;
    }
    void Slot5()
    {
        BuyUnit();
        Debug.Log("ich wurde gedrückt: " + slotButtons[4].ToString());
        PlayerStats.playerGold = PlayerStats.playerGold - 1;
    }

    void BuyUnit()
    {
        UnitData unit = new UnitData("testORK", 1, false, 1, 100f, 10f, 0f, 1f, 1, 15f, 15f, 0);
        MasterScript.units.Add(unit);
        unit.gameObject = Instantiate(unitPref);
        unit.gameObject.transform.position = new Vector3(0, -2, -unit.gameObject.transform.localScale.z);


    }
}
