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
        enemy = new UnitData("EnemyKiller", 1, true, 1, 200, 1, 1, 1, 1, 1, 1, 1);

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

        
            
            unit.gameObject = Instantiate(unitPref);
            unit.gameObject.name = unit.gameObject.name;
            unit.SetTag();
            unit.gameObject.transform.position = new Vector3(0f , 0f , -0.5f);
            units.Add(unit);
           
       

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
        unit.GettingHit();
        enemy.GettingHit();
        bool unitIsMoving;
        bool enemyIsMoving;
        Vector3 Ecoord;
        

        if (Input.GetKey(KeyCode.G))
        {
            RoundIsStarted = true;
        }

        if (RoundIsStarted)
        {
            unitIsMoving = true;
            enemyIsMoving = true;
            foreach (UnitData item in units)
            {
                 Vector3 coord;
                 coord = new Vector3( Mathf.RoundToInt( item.gameObject.transform.position.x), Mathf.RoundToInt(item.gameObject.transform.position.y),-1);
                
                if ((item.gameObject.transform.position - enemy.gameObject.transform.position).magnitude >= 1.25f && unitIsMoving)
                {
                 item.gameObject.transform.LookAt(enemy.gameObject.transform);
                 item.gameObject.transform.Translate((item.gameObject.transform.forward / 2f) * Time.deltaTime ,Space.World);
                    unitIsMoving = !unitIsMoving;
                }
                else 

                {
                    unitIsMoving = false;
                    item.gameObject.transform.position = coord;
                    item.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    float Dmg = (item.physicalDamage + item.magicDamage)/2;
                    enemy.healthPoints -= Dmg + Time.deltaTime;
                    
                    Debug.Log(enemy.healthPoints);
                
                }
                
            }
            
            Ecoord = new Vector3(Mathf.RoundToInt(enemy.gameObject.transform.position.x), Mathf.RoundToInt(enemy.gameObject.transform.position.y), -1);

            if ((enemy.gameObject.transform.position - unit.gameObject.transform.position).magnitude >= 1.5f && enemyIsMoving)
            {
                enemy.gameObject.transform.LookAt(unit.gameObject.transform);
                enemy.gameObject.transform.Translate((enemy.gameObject.transform.forward / 2f) * Time.deltaTime, Space.World);
                enemyIsMoving = true;
            }
            else

            {
                enemyIsMoving = false;
                enemy.gameObject.GetComponent<Renderer>().material.color = Color.green;
                enemy.gameObject.transform.position = Ecoord;

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
