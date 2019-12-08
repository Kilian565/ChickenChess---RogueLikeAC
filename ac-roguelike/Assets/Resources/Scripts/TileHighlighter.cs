using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    public bool isSelected = false;
    private GameObject SelectedTile;
    MasterScript master;

    private void Awake()
    {
        master = Resources.Load<MasterScript>("Scripts/MasterScript");
        
    }
    void Start ()
    { 
	}
	void Update ()
    {
        if (Input.GetMouseButton(1))
        {
            isSelected = false;
            MasterScript.LastSelected = null;
        }
        if (!isSelected)
       
       
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnMouseDown()
    {

        isSelected = true;
        SelectedTile = this.gameObject;
        MasterScript.LastSelected = SelectedTile;
        SelectedTile.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Last Selected" + MasterScript.LastSelected.transform.position);
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        isSelected = false;
        MasterScript.LastSelected = null;
    }

    private void OnMouseEnter()
    {
        
    }
}
