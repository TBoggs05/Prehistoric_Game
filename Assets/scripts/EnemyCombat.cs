using UnityEngine;

public class EnemyCombat : Combat
{
    void OnTriggerStay2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if (other.gameObject.tag == "Player")
            hasLineOfSight = true;
        else
            hasLineOfSight = false;

        // If in line of sight, attack
        if (hasLineOfSight)
        {
            Attack(other);
        }
    }
}