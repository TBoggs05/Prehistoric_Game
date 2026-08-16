using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyStats : Stats
{
    void Update()
    {
        Debug.Log("Enemy Health: " + getHealth());
    }
}
