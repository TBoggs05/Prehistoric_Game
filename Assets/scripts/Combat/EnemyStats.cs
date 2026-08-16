using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : Stats
{
    void Awake()
    {
        attackSpeed = 4f;
    }

    private void Start()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy();
        }
    }

    void Update()
    {
        if(getHealth() == 0)
            Die();
    }


    //handle cleanup and alert enemymanager
    void Die()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.EnemyDied();
        }

        Destroy(gameObject);
    }
}