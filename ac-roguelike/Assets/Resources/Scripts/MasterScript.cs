using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public bool RoundIsStarted;

    public static List<GridElement> tiles = new List<GridElement>();
    public static GridElement tile;
    public int gridheigth = 8;
    public int gridwidth = 8;

    Canvas uiShopPref;

    GameObject tilePref;
    GameObject cameraPref;
    GameObject lightPref;
    GameObject enemyPref;
    GameObject shopPref;
    GameObject enemy;

    private void Awake()
    {
        new Grid(gridwidth, gridheigth, 1, new Vector3(0, 0, 0));

        uiShopPref = Resources.Load<Canvas>("Prefabs/InGame_UI");
        tilePref = Resources.Load<GameObject>("Prefabs/Cube");
        cameraPref = Resources.Load<GameObject>("Prefabs/MainCamera");
        lightPref = Resources.Load<GameObject>("Prefabs/Light");
        enemyPref = Resources.Load<GameObject>("3dObjects/Mega_Man");
    }
    void Start()
    {
        GameConstruct();
        GridConstruct();
        BenchConstruct();
    }


    void Update()
    {

    }

    void GameConstruct()
    {
        Instantiate(cameraPref);
        Instantiate(lightPref);
        enemy = Instantiate(enemyPref);
        Instantiate(uiShopPref);
        enemy.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        enemy.transform.position = new Vector3(3.5f, 7f, -0.5f);
        enemy.transform.eulerAngles = new Vector3(90f, 0f, 180f);
    }

    private void GridConstruct()
    {
        for (int y = 0; y < gridheigth; y++)
        {
            for (int x = 0; x < gridwidth; x++)
            {
                tile = new GridElement(new Vector2Int(x, y));
                tiles.Add(tile);
                tile.gameObject = Instantiate(tilePref);
                tile.gameObject.transform.position = new Vector3(tile.coordinate.x, tile.coordinate.y, 0);
                tile.gameObject.name = "Tile " + x + "/" + y;
            }
        }
    }
    private void BenchConstruct()
    {
        for (int x = 0; x < gridwidth; x++)
        {
            tile = new GridElement(new Vector2Int(x, -2));
            tiles.Add(tile);
            tile.gameObject = Instantiate(tilePref);
            tile.gameObject.transform.position = new Vector3(tile.coordinate.x, tile.coordinate.y, 0);
            tile.gameObject.name = "Bench " + x;

        }

    }

    private void RoundStart()
    {

        if(Input.GetKey(KeyCode.G))
        {
            RoundIsStarted = true;
        }

        if (RoundIsStarted)
        {
            
        }
    }
}
