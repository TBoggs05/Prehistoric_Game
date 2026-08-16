using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerStats : Stats
{

    [SerializeField] protected PlayerProgression progression = new PlayerProgression();
    [SerializeField] protected float hunger = 0f;
    [SerializeField] protected int eggsEaten = 0;
    [SerializeField] protected int dinosKilled = 0;
    protected float exp = 0f;

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
