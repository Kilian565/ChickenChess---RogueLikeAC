using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    bool isShopActiv = false;
    GameObject shopPref;
    GameObject inGameShop;

    MeshRenderer[] shopRenderers;
    MeshCollider[] shopColliders;

    private void Awake()
    {
        shopPref = Resources.Load<GameObject>("Prefabs/Shop");
    }

    void Start ()
    {
        GameObject inGameShop = Instantiate(shopPref);
        shopRenderers = inGameShop.GetComponentsInChildren<MeshRenderer>();
        shopColliders = inGameShop.GetComponentsInChildren<MeshCollider>();    
    }
	
	void Update ()
    {
        ActivateShop();
        calculatingShopOdds();
	}

    void ActivateShop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShopActiv = !isShopActiv;           
        }
        if (isShopActiv)
        {
            foreach (var item in shopRenderers)
            {
                item.enabled = true;
            }
            foreach (var item in shopColliders)
            {
                item.enabled = true;
            }
        }
        if (!isShopActiv)
        {
            foreach (var item in shopRenderers)
            {
                item.enabled = false;
            }
            foreach (var item in shopColliders)
            {
                item.enabled = false;
            }
        }
    }

    void calculatingShopOdds()
    {
        if (PlayerStats.playerLevel == 1)
        {

        }
    }
}
