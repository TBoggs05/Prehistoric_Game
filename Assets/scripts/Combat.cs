using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class Combat : MonoBehaviour
{
    private bool hasLineOfSight;

    public BoxCollider2D hurtBox;
    [SerializeField] private PlayerStats playerStats = new PlayerStats();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hasLineOfSight = false;
        hurtBox.size = new Vector2(playerStats.getRange()/2, playerStats.getRange()/2);
    }

    // Detects another Collider inside the trigger collider once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if(other.gameObject.tag == "Enemy")
            hasLineOfSight = true;
        else
            hasLineOfSight = false;

        // If in line of sight, and left mouse is clicked, attack
        if(hasLineOfSight && Input.GetMouseButtonDown(0))
        {
            Attack(other);
        }
    }

    public void Attack(Collider2D other)
    {
        other.gameObject.GetComponent<Combat>().DamageReceived(playerStats.getDamage());
    }

    public void DamageReceived(float damage)
    {
        playerStats.takeDamage(damage);
    }
}
