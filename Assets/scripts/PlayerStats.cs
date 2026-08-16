using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private PlayerProgression progression = new PlayerProgression();
    [SerializeField] private float damage = 1f;
    [SerializeField] private float range = 1f;
    [SerializeField] private float health = 1f;
    [SerializeField] private float hunger = 0f;
    [SerializeField] private int eggsEaten = 0;
    [SerializeField] private int dinosKilled = 0;
    [SerializeField] private int level = 1;
    private float exp = 0f;
    
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

    public int getEggsEaten()
    {
        return eggsEaten;
    }

    public void addEggEaten(int eggs)
    {
        eggsEaten += eggs;
    }

    public int getDinosKileld()
    {
        return dinosKilled;
    }

    public void addDinoKilled(int numberKilled)
    {
        dinosKilled += numberKilled;
    }

    public int getLevel()
    {
        return level;
    }

    void LevelUp()
    {
        if(exp > progression.GetLevelUpValues()[level])
            level++;
    }

    void ExpCalc()
    {
        exp = (eggsEaten * progression.getExpForEggs()) + (dinosKilled * progression.getExpForDinos());
    }

    void Update()
    {
        LevelUp();
        ExpCalc();
    }
}
