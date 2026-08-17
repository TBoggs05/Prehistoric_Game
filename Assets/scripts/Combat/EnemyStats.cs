using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : Stats
{
    [SerializeField] protected float satitety = 20f;
    [SerializeField] protected PlayerStats player;

    void Awake()
    {
        attackSpeed = 4f;
    }

    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>();

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy();
        }
    }

    void Update()
    {
        if(getHealth() <= 0)
        {
            player.Eat(satitety);
            player.addDinoKilled(1);
            Die();
        }
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