using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool selected;
    
}
public class UnitData
{
    public string unitName;
    public int unitLevel;
    public bool isEnemey;
    public int race;

    public float healthPoints;
    public float MaxHealth;
    public float physicalDamage;
    public float magicDamage;
    public float attackSpeed;
    public int attackRange;
    public float armor;
    public float magicResistance;
    public int critChance;
    public GameObject gameObject;
    private Vector2Int coord;
    public Weapons weapon;


    public UnitData()
    {

    }

    public UnitData(
                    string unitName,
                    int unitLevel,
                    bool isEnemey,
                    int race,
                    float healthPoints,
                    float physicalDamage,
                    float magicDamage,
                    float attackSpeed,
                    int attackRange,
                    float armor,
                    float magicResistance,
                    int critChance
                    
                    )
    {
        this.unitName = unitName;
        this.unitLevel = unitLevel;
        this.isEnemey = isEnemey;
        this.race = race;
        this.healthPoints = healthPoints;
        this.physicalDamage = physicalDamage;
        this.magicDamage = magicDamage;
        this.attackSpeed = attackSpeed;
        this.attackRange = attackRange;
        this.armor = armor;
        this.magicResistance = magicResistance;
        this.critChance = critChance;
        healthPoints = this.MaxHealth;
       
    }

    

    public void FindEnemy()
    {


    }

    public Vector2Int GetCoordinate()
    {
        coord = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y);
        return coord;

    }
   public void SetTag()
    {
        if (isEnemey)
        {
            gameObject.tag = "Enemy"; 
        }
        else
        {
            gameObject.tag = "Unit";
        }

    }
    public void GettingHit()
    {
        if (MaxHealth > healthPoints && healthPoints > 75)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (healthPoints < 75 && healthPoints > 25)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (healthPoints > 0 && healthPoints <25 )
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (healthPoints <=0)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }

    }
}
