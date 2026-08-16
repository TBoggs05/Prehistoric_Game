using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    // Singleton Instance
    public static EnemyManager Instance { get; private set; }

    // Trackers
    public int EnemiesKilled { get; private set; } = 0;
    public int EnemiesRemaining { get; private set; } = 0;

    // Actions/Events that UI or other systems can listen to
    public static event Action<int> OnKillCountChanged;
    public static event Action<int> OnRemainingCountChanged;

    private void Awake()
    {
        // Enforce Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Called automatically by an enemy when they spawn
    public void RegisterEnemy()
    {
        EnemiesRemaining++;
        OnRemainingCountChanged?.Invoke(EnemiesRemaining);
    }

    // Called automatically by an enemy when they die
    public void EnemyDied()
    {
        EnemiesRemaining--;
        EnemiesKilled++;

        // Trigger updates to any listening scripts
        OnKillCountChanged?.Invoke(EnemiesKilled);
        OnRemainingCountChanged?.Invoke(EnemiesRemaining);

   
    }
}
