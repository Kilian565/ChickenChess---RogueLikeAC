using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}

public class UnitData
{
    public string unitName;
    public int unitLevel;
    public bool isEnemey;
    public int race;

    public float healthPoints;
    public float physicalDamage;
    public float magicDamage;
    public float attackSpeed;
    public int attackRange;
    public float armor;
    public float magicResistance;
    public int critChance;


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
    }
}
