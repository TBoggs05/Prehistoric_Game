using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float range = 1f;
    [SerializeField] protected int health = 1;
    [SerializeField] protected float attackSpeed = 2f;
    [SerializeField] protected int level = 1;
    
    public int getDamage()
    {
        return damage;
    }

    void setLevelDamage()
    {
        damage = damage * level;
    }

    public float getRange()
    {
        return range;
    }

    void setLevelRange()
    {
        range = range * level;
    }

    public int getHealth()
    {
        return health;
    }

    void setLevelHealth()
    {
        health += level;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public int getLevel()
    {
        return level;
    }

    public void setAttackSpeed(float speed)
    {
        attackSpeed = speed;
    }

    public float getAttackSpeed()
    {
        return attackSpeed; 
    }
}
