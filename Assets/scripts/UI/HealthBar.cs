using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private int maxHealth;
    [SerializeField] protected PlayerStats playerStats;
    private PlayerStats stats;

    void Awake()
    {
        stats = playerStats.GetComponent<PlayerStats>();
        maxHealth = stats.getHealth();
    }

    void Start()
    {
        SetMaxHealth();
    }

    void Update()
    {
        stats.Regen();
        SetHealth();
    }

    public void SetHealth()
    {
        slider.value = stats.getHealth();
    }
    public void SetMaxHealth()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
