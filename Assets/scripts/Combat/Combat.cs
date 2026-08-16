using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Combat : MonoBehaviour
{
    protected bool hasLineOfSight;
    [SerializeField] protected bool isPlayer;

    public BoxCollider2D hurtBox;
    [SerializeField] protected PlayerStats playerStats;
    [SerializeField] protected EnemyStats enemyStats;
    [SerializeField] protected float timer;
    [SerializeField] protected bool canAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hasLineOfSight = false;
        isPlayer = true;
        timer = 2f;
        canAttack = true;
    }

    // Detects another Collider inside the trigger collider once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if(other.gameObject.tag == "Enemy")
        {
            hasLineOfSight = true;
            enemyStats = other.gameObject.GetComponent<EnemyStats>();
            Debug.Log("Enemey in LOS");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if(other.gameObject.tag == "Enemy")
        {
            hasLineOfSight = false;
            enemyStats = null;
            Debug.Log("Enemey Left LOS");
        }
    }

    void Update()
    {
        if (hasLineOfSight && Input.GetMouseButtonDown(0))
        {
            Attack(isPlayer, canAttack, playerStats, enemyStats);
        }
        else if (Input.GetMouseButtonDown(0))
            canAttack = false;

        hurtBox.size = new Vector2(playerStats.getRange()/2, playerStats.getRange()/2);

        // Count down the time
        if (timer > 0 && canAttack == false)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            // Reset timer
            ResetTimer(isPlayer);
        }
    }

    public void Attack(bool player, bool attack, PlayerStats playerStat, EnemyStats enemyStat)
    {
        if(player && canAttack)
            enemyStat.takeDamage(playerStat.getDamage());
        else if (canAttack)
            playerStat.takeDamage(enemyStat.getDamage());

        canAttack = false;
    }

    public void ResetTimer(bool player)
    {
        if(player)
            timer = playerStats.getAttackSpeed();
        else
            timer = enemyStats.getAttackSpeed();

        canAttack = true;
    }
}
