using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public bool RoundIsStarted;

    public static List<GridElement> tiles = new List<GridElement>();
    public static List<UnitData> units = new List<UnitData>();
    public GridElement tile;
    public int gridheigth = 8;
    public int gridwidth = 8;

    public static GameObject LastSelected;



    Canvas uiShopPref;

    GameObject tilePref;
    GameObject cameraPref;
    GameObject lightPref;
    GameObject enemyPref;
    GameObject shopPref;
    GameObject unitPref;
    UnitData unit;
    UnitData enemy;

    private void Awake()
    {


        uiShopPref = Resources.Load<Canvas>("Prefabs/InGame_UI");
        tilePref = Resources.Load<GameObject>("Prefabs/Cube");
        cameraPref = Resources.Load<GameObject>("Prefabs/MainCamera");
        lightPref = Resources.Load<GameObject>("Prefabs/Light");
        enemyPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter4");
        unitPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter2");
        unit = new UnitData("Killer", 2, false, 1, 100, 1, 1, 1, 1, 1, 1, 1);
        enemy = new UnitData("EnemyKiller", 1, true, 1, 100, 1, 1, 1, 1, 1, 1, 1);

    }
    void Start()
    {

        GameConstruct();
        GridConstruct();
        BenchConstruct();
        


    }


    void Update()
    {
        SetTilesOccupied();
        RoundStart();
    }

    void GameConstruct()
    {
        Instantiate(cameraPref);
        Instantiate(lightPref);
        enemy.gameObject = Instantiate(enemyPref);
        enemy.SetTag();
        //enemy.gameObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        enemy.gameObject.transform.position = new Vector3(3f, 7f, -0.5f);
        //enemy.gameObject.transform.eulerAngles = new Vector3(90f, 0f, 180f);
        //units.Add(enemy);

        Instantiate(uiShopPref);

        for (int i = 0; i < 3; i++)
        {
            unit.gameObject = Instantiate(unitPref);
            unit.gameObject.name = unit.gameObject.name + "" + i + "";
            unit.SetTag();
            unit.gameObject.transform.position = new Vector3(0f +i, 0f +i, -0.5f);
            units.Add(unit);
            
               

        }

        Debug.Log(unit.GetCoordinate());


    }

    private void GridConstruct()
    {


        for (int y = 0; y < gridheigth; y++)
        {
            for (int x = 0; x < gridwidth; x++)
            {
                tile = new GridElement(new Vector2Int(x, y));
                tile.gameObject = Instantiate(tilePref);
                tile.gameObject.transform.position = new Vector3(tile.coordinate.x, tile.coordinate.y, 0);
                tile.gameObject.name = "Tile " + x + "/" + y;
                tiles.Add(tile);
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

        if (Input.GetKey(KeyCode.G))
        {
            RoundIsStarted = true;
        }

        if (RoundIsStarted)
        {
            foreach (UnitData unit in units)
            {
                if (unit.gameObject.transform.position != enemy.gameObject.transform.position - new Vector3(-1f,-1f,0))
                {
                 //unit.gameObject.transform.LookAt(enemy.gameObject.transform);
                 unit.gameObject.transform.Translate((Vector3.up / 2f) * Time.deltaTime ,Space.Self);

                }
                else if (unit.gameObject.transform.position != enemy.gameObject.transform.position - new Vector3(-1, -1, 0))
                {
                    unit.gameObject.transform.Translate(Vector3.zero);
                }
            }
        }
    }

    private void SetTilesOccupied()
    {
        foreach (GridElement tile in tiles)
        {
            foreach (UnitData unit in units)
            {

                if (tile.coordinate == unit.GetCoordinate())
                {
                    tile.isOccupied = true;
                    Debug.Log(tile.coordinate + " ist belegt");


                }

            }
        }

    }
    
}
