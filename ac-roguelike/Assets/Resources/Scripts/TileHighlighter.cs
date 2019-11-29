using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    bool isSelected = false;

	void Start ()
    { 
	}
	void Update ()
    {
        if (isSelected)
        {
            this.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnMouseDown()
    {
        isSelected = !isSelected;
    }

    private void OnMouseOver()
    {
        if (!isSelected)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnMouseEnter()
    {
        
    }
}
