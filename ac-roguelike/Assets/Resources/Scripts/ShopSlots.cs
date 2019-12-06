using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlots : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.GetComponent<Renderer>().material.color = Color.white;
            BuyUnit();
        }
	}
    private void OnMouseDown()
    {
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void BuyUnit()
    {
        
    }
}
