using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    // Singleton Instance
    public static EnemyManager Instance { get; private set; }

    // Trackers
    public int EnemiesKilled { get; private set; } = 0;
    public int EnemiesRemaining { get; private set; } = 0;
    private int maxEnemies = 30;
    public bool enemiesCapped = false;
    // Actions/Events that UI or other systems can listen to
    public static event Action<int> OnKillCountChanged;
    public static event Action<int> OnRemainingCountChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 60;
    }

    // Called automatically by an enemy when they spawn
    public void RegisterEnemy()
    {
        EnemiesRemaining++;
        OnRemainingCountChanged?.Invoke(EnemiesRemaining);
        if (EnemiesRemaining >= maxEnemies)
        {
            enemiesCapped = true;
        }
    }

    // Called automatically by an enemy when they die
    public void EnemyDied()
    {
        EnemiesRemaining--;
        EnemiesKilled++;

        // Trigger updates to any listening scripts
        OnKillCountChanged?.Invoke(EnemiesKilled);
        OnRemainingCountChanged?.Invoke(EnemiesRemaining);
        if (EnemiesRemaining < maxEnemies)
        {
            enemiesCapped = false;
        }

    }
}
