using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> Funits = new List<GameObject>();

    private void Awake()
    {
    }

    void Start()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
            Debug.Log(enemies);
        }
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            Funits.Add(unit);
            Debug.Log("Friendly unit Count : " + Funits.Capacity);
        }
    }

    void Update()
    {

    }
}
