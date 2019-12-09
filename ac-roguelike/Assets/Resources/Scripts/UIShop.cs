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

    bool slotIsEmpty = true;

    GameObject unitPref;


    private void Awake()
    {
        
        slotButtons = uiShop.GetComponentsInChildren<Button>();
        slottext = new Text[slotButtons.Length];
       
        for (int i = 0; i < slotButtons.Length; i++)
        {
            slottext[i] = slotButtons[i].GetComponentInChildren<Text>();

        }
        unitPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter3");
        
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
        
        UnitData unit = new UnitData("testORK", 1, false, 1, 100f, 10f, 0f, 1f, 1, 15f, 15f, 0);
        MasterScript.units.Add(unit);
        unit.gameObject = Instantiate(currentUnit);
        
        coord = new Vector3(GameObject.Find("Bench 0").transform.position.x, GameObject.Find("Bench 0").transform.position.y, GameObject.Find("Bench 0").transform.position.z - 1);
        //Vector3 tempCoord = coord;
        
       
        unit.gameObject.transform.position = coord;



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
