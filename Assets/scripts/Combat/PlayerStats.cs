using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerStats : Stats
{

    [SerializeField] protected PlayerProgression progression;
    [SerializeField] protected int eggsEaten = 0;
    [SerializeField] protected int dinosKilled = 0;
    
    protected float exp = 0f;
    private float hunger = 100f;
    public float rateOfIncOrDec = 1.25f;

    public int getEggsEaten()
    {
        return eggsEaten;
    }

    public void addEggEaten(int eggs)
    {
        eggsEaten += eggs;
    }

    public int getDinosKilled()
    {
        return dinosKilled;
    }

    public void addDinoKilled(int numberKilled)
    {
        dinosKilled += numberKilled;
    }

    public float getHunger()
    {
        return hunger;
    }

    public void Starve()
    {
        hunger -= rateOfIncOrDec * Time.deltaTime;

        if(hunger < 0f)
            hunger = 0f;
    }

    public void Regen()
    {
        if(hunger/100 > 0.6 && health < 100)
            health += Convert.ToInt32(rateOfIncOrDec * 20.5 * Time.deltaTime);
    }

    public void Eat(float amountRestored)
    {
        float temp = hunger + amountRestored;

        if(temp > 100)
            hunger = 100f;
        else
            hunger = temp;
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

        if(hunger <= 0)
        {
            health -= Convert.ToInt32(rateOfIncOrDec * Time.deltaTime * 20);
        }
        
        if(health <= 0)
        {
            exp = 0f;
            hunger = 100f;
            rateOfIncOrDec = 1f;

            Died();
        }
    }

    void Died()
    {
       
        GameManager.Instance.GameOver();
    }
}
