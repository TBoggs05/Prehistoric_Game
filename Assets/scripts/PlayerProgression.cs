using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    private Dictionary<float, int> expReq = new Dictionary<float, int>
    {
        {1, 500},
        {2, 1000},
        {3, 2250},
        {4, 5000},
        {5, 500000}
    };

    private int maxLevel = 5;
    private float expForEggs = 1.2f;
    private float expForDinos = 1.75f;

    public int getMaxLevel()
    {
        return maxLevel;
    }

    public float getExpForEggs()
    {
        return expForEggs;
    }

    public float getExpForDinos()
    {
        return expForDinos;
    }

    public Dictionary<float, int> GetLevelUpValues()
    {
        return expReq;
    }
}
