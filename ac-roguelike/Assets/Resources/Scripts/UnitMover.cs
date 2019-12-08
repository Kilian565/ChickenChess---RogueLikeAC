using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{


    public bool isSelected = false;


    void Start()
    {

    }
    void Update()
    {
        MoveUnit();
    }

    private void OnMouseDown()
    {
        if (this.gameObject.GetComponent<Unit>().selected)
        {
            this.gameObject.GetComponent<Unit>().selected = false;
        }
        else
            this.gameObject.GetComponent<Unit>().selected = true;
        //isSelected = true;

        //this.transform.position = this.transform.position + Vector3.back;

    }

   private void MoveUnit()
    {

        if (this.gameObject.GetComponent<Unit>().selected && Input.GetMouseButton(0) && MasterScript.LastSelected != null)
        {
            this.transform.position = MasterScript.LastSelected.transform.position + Vector3.back;
            this.gameObject.GetComponent<Unit>().selected = false;
            MasterScript.LastSelected = null;

        }
        if (this.gameObject.GetComponent<Unit>().selected)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
