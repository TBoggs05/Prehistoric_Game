using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class Combat : MonoBehaviour
{
    protected bool hasLineOfSight;

    public BoxCollider2D hurtBox;
    [SerializeField] private PlayerStats playerStats = new PlayerStats();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hasLineOfSight = false;
        hurtBox.size = new Vector2(playerStats.getRange() / 2, playerStats.getRange() / 2);
    }

    // Detects another Collider inside the trigger collider once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if (other.gameObject.tag == "Enemy")
        {
            hasLineOfSight = true;
            Debug.Log("Enemey in LOS");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if (other.gameObject.tag == "Enemy")
        {
            hasLineOfSight = false;
            Debug.Log("Enemey Left LOS");
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