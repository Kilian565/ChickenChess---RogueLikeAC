using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridElement
{
    // Membervariablen
    public Vector2Int coordinate;
    public string Name;
    public string position;
    public GameObject gameObject;
    public bool isOccupied;
    public bool isSelected;

    public static Dictionary<Vector2Int, GridElement> coordRef = new Dictionary<Vector2Int, GridElement>();
    public static Dictionary<GameObject, GridElement> goRef = new Dictionary<GameObject ,GridElement>();

    // Konstruktor **parameter hinzufügen**
    public GridElement(Vector2Int coordinate)
    {
        this.coordinate = coordinate;
    }

}
