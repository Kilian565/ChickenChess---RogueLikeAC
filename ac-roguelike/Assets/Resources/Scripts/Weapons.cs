using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons
{
    public int unitClass;
    public float physicalDamage;
    public float magicalDamage;
    public float attackSpeed;
    public int attackRange;

    public Weapons()
    {

    }

    public Weapons(int unitClass,
                   float physicalDamage,
                   float magicalDamage,
                   float attackSpeed,
                   int attackRange
                  )
    {
        this.unitClass = unitClass;
        this.physicalDamage = physicalDamage;
        this.magicalDamage = magicalDamage;
        this.attackSpeed = attackSpeed;
        this.attackRange = attackRange;
    }

}
