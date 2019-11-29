using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridElement
{
    // Membervariablen
    public Vector2Int coordinate;
    public string Name;
    public string position;
    public GameObject appearance;

    // Konstruktor **parameter hinzufügen**
    public GridElement(Vector2Int coordinate)
    {
        this.coordinate = coordinate;
    }

}
