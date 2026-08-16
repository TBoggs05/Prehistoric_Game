using UnityEngine;

public class EnemyCombat : Combat
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if(other.gameObject.tag == "Player")
        {
            hasLineOfSight = true;
            playerStats = other.gameObject.GetComponent<PlayerStats>();
            Debug.Log("Player in LOS");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if(other.gameObject.tag == "Player")
        {
            hasLineOfSight = false;
            playerStats = null;
            Debug.Log("Player Left LOS");
        }
    }

    void Awake()
    {
        isPlayer = false;
        timer = 4f;
        hasLineOfSight = false;
    }

    void Update()
    {
        if (hasLineOfSight)
        {
            Attack(isPlayer, canAttack, playerStats, enemyStats);
        }

                // Count down the time
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            // Reset timer
            ResetTimer(isPlayer);
        }
    }
}
