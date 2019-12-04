using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool ShopIsActiv;
    public GameObject uiShop;

    private int playerGold;
    public Text playerGoldText;

    private int playerLevel;
    public Text playerLevelText;

    Image[] slotImages;
    Button[] slotButtons;

    private void Awake()
    {
        slotImages = uiShop.GetComponentsInChildren<Image>();
        slotButtons = uiShop.GetComponentsInChildren<Button>();
    }
    void Start ()
    {

    }
	
	void Update ()
    {
        ActivateShop();

        playerGold = PlayerStats.playerGold;
        playerGoldText.text = "Gold: " + playerGold.ToString();

        playerLevel = PlayerStats.playerLevel;
        playerLevelText.text = "Level: " + playerLevel.ToString();

    }

    void ActivateShop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShopIsActiv = !ShopIsActiv;
        }
        if (ShopIsActiv)
        {
            foreach (var item in slotImages)
            {
                item.enabled = true;
            }
            foreach (var item in slotButtons)
            {
                item.enabled = true;
            }
        }
        if (!ShopIsActiv)
        {
            foreach (var item in slotImages)
            {
                item.enabled = false;
            }
            foreach (var item in slotButtons)
            {
                item.enabled = false;
            }
        }
    }
}
