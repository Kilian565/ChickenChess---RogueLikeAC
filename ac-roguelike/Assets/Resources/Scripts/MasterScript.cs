using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public bool RoundIsStarted;

    public static List<GridElement> tiles = new List<GridElement>();
    public static List<UnitData> units = new List<UnitData>();
    public static List<UnitData> enemies = new List<UnitData>();
    public GridElement tile;
    public int gridheigth = 8;
    public int gridwidth = 8;


    public static GameObject LastSelected;



    Canvas uiShopPref;

    GameObject weaponPref;
    GameObject tilePref;
    GameObject cameraPref;
    GameObject lightPref;
    GameObject enemyPref;
    GameObject shopPref;
    GameObject unitPref;
    UnitData unit;
    UnitData enemy;
    UnitData enemy2;

    private void Awake()
    {

        uiShopPref = Resources.Load<Canvas>("Prefabs/InGame_UI");
        tilePref = Resources.Load<GameObject>("Prefabs/Cube");
        cameraPref = Resources.Load<GameObject>("Prefabs/MainCamera");
        lightPref = Resources.Load<GameObject>("Prefabs/Light");
        enemyPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter4");
        unitPref = Resources.Load<GameObject>("Prefabs/PlatzhalterPrefabs/Platzhalter2");
        weaponPref = Resources.Load<GameObject>("Prefabs/Kanabo_Club_Weapon");
        unit = new UnitData("Killer", 2, false, 1, 100, 1, 1, 1, 1, 1, 1, 1);
        enemy = new UnitData("EnemyKiller", 1, true, 1, 200, 1, 1, 1, 1, 1, 1, 1);
        enemy2 = new UnitData("EnemyKiller2", 1, true, 1, 200, 1, 1, 1, 1, 1, 1, 1);

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
        enemy.gameObject.transform.position = new Vector3(3f, 7f, -1f);
        enemies.Add(enemy);
        //enemy2.gameObject = Instantiate(enemyPref);
        //enemy2.SetTag();
        //enemy2.gameObject.transform.position = new Vector3(1f, 7f, -1f);
        //enemies.Add(enemy2);
        //enemy.gameObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        //enemy.gameObject.transform.eulerAngles = new Vector3(90f, 0f, 180f);
        //units.Add(enemy);

        Instantiate(uiShopPref);



        unit.gameObject = Instantiate(unitPref);
        unit.gameObject.name = unit.gameObject.name;
        unit.SetTag();
        unit.gameObject.transform.position = new Vector3(0f, 0f, -1f);
        unit.weapon = new Weapons(1, 1, 1, 1, 1);
        unit.weapon.gameObject = Instantiate(weaponPref);
        unit.weapon.gameObject.transform.localScale = unit.gameObject.transform.localScale / 2;

        unit.weapon.gameObject.transform.Rotate(new Vector3(-45, 0, 0));

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
        unit.weapon.gameObject.transform.position = new Vector3(unit.gameObject.transform.position.x + unit.gameObject.transform.localScale.x / 2, unit.gameObject.transform.position.y, -1);


        if (Input.GetKey(KeyCode.G))
        {
            RoundIsStarted = true;
        }

        if (RoundIsStarted)
        {
            unitIsMoving = true;
            enemyIsMoving = true;

            foreach (UnitData einheit in units)
            {
                einheit.weapon.gameObject.transform.position = new Vector3(einheit.gameObject.transform.position.x + einheit.gameObject.transform.localScale.x / 2, einheit.gameObject.transform.position.y, -1);

                foreach (UnitData feind in enemies)
                {
                    Vector3 Ecoord;
                    Ecoord = new Vector3(Mathf.RoundToInt(feind.gameObject.transform.position.x), Mathf.RoundToInt(feind.gameObject.transform.position.y), -1);

                    if ((feind.gameObject.transform.position - einheit.gameObject.transform.position).magnitude >= 1.44f && enemyIsMoving)
                    {
                        feind.gameObject.transform.LookAt(einheit.gameObject.transform);
                        feind.gameObject.transform.Translate((feind.gameObject.transform.forward / 2f) * Time.deltaTime, Space.World);
                        //unitIsMoving = !unitIsMoving;
                    }
                    else

                    {
                        enemyIsMoving = !enemyIsMoving;
                        feind.gameObject.transform.position = new Vector3(feind.GetCoordinate().x, feind.GetCoordinate().y, -1);
                        feind.gameObject.GetComponent<Renderer>().material.color = Color.green;
                        float eDmg = (feind.physicalDamage + feind.magicDamage) / 2;
                        einheit.healthPoints -= eDmg + Time.deltaTime;

                        Debug.Log("your life : " + einheit.healthPoints);

                    }



                    Vector3 coord;
                    coord = new Vector3(Mathf.RoundToInt(einheit.gameObject.transform.position.x), Mathf.RoundToInt(einheit.gameObject.transform.position.y), -1);

                    if ((einheit.gameObject.transform.position - feind.gameObject.transform.position).magnitude >= 1.44f && unitIsMoving)
                    {
                        einheit.gameObject.transform.LookAt(feind.gameObject.transform);
                        einheit.gameObject.transform.Translate((einheit.gameObject.transform.forward / 2f) * Time.deltaTime, Space.World);
                        //unitIsMoving = !unitIsMoving;
                    }
                    else

                    {
                        unitIsMoving = !unitIsMoving;
                        einheit.gameObject.transform.position = new Vector3(einheit.GetCoordinate().x, einheit.GetCoordinate().y, -1);
                        einheit.gameObject.GetComponent<Renderer>().material.color = Color.green;
                        float yourDmg = (einheit.physicalDamage + einheit.magicDamage) / 2;
                        einheit.weapon.gameObject.transform.Rotate(new Vector3(45, 0, 0));

                        feind.healthPoints -= yourDmg + Time.deltaTime;

                        Debug.Log("Enemy life : " + enemy.healthPoints);

                    }
                }

            }





            //Ecoord = new Vector3(Mathf.RoundToInt(enemy.gameObject.transform.position.x), Mathf.RoundToInt(enemy.gameObject.transform.position.y), -1);

            //if ((enemy.gameObject.transform.position - unit.gameObject.transform.position).magnitude >= 1.5f && enemyIsMoving)
            //{
            //    enemy.gameObject.transform.LookAt(unit.gameObject.transform);
            //    enemy.gameObject.transform.Translate((enemy.gameObject.transform.forward / 2f) * Time.deltaTime, Space.World);
            //    enemyIsMoving = true;
            //}
            //else

            //{
            //    enemyIsMoving = false;
            //    enemy.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //    enemy.gameObject.transform.position = Ecoord;

            //}

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
