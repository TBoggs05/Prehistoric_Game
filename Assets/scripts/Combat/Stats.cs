using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float range = 1f;
    [SerializeField] protected float health = 1f;
    [SerializeField] protected int level = 1;
    
    public float getDamage()
    {
        return damage;
    }

    void setLevelDamage()
    {
        damage = damage * level * 0.5f;
    }

    public float getRange()
    {
        return range;
    }

    void setLevelRange()
    {
        range = range * level;
    }

    public float getHealth()
    {
        return health;
    }

    void setLevelHealth()
    {
        health += level;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public int getLevel()
    {
        return level;
    }
}
