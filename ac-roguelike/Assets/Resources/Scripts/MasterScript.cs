using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{

    public static List<GridElement> tiles = new List<GridElement>();
    public static GridElement tile;
    public int gridheigth = 8;
    public int gridwidth = 8;

    GameObject tilePref;
    GameObject cameraPref;
    GameObject lightPref;
    GameObject shopPref;

    private void Awake()
    {
        tilePref = Resources.Load<GameObject>("Prefabs/Cube");
        cameraPref = Resources.Load<GameObject>("Prefabs/MainCamera");
        lightPref = Resources.Load<GameObject>("Prefabs/Light");
    }
    void Start ()
    {
        GameConstruct();
        GridConstruct();
	}
	
	
	void Update ()
    {
	     
	}

    void GameConstruct()
    {
        Instantiate(cameraPref);
        Instantiate(lightPref);
    }

    private void GridConstruct()
    {
        for (int y = 0; y < gridheigth; y++)
        {
            for (int x = 0; x < gridwidth; x++)
            {
                tile = new GridElement(new Vector2Int(x, y));
                tiles.Add(tile);
                tile.appearance = Instantiate(tilePref);
                tile.appearance.transform.position = new Vector3(tile.coordinate.x, tile.coordinate.y, 0);
            }
        }
    }
}
