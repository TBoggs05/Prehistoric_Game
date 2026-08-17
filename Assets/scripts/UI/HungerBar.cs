using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
public class HungerBar : MonoBehaviour
{
    public Slider slider;
    private float maxHunger;
    [SerializeField] protected PlayerStats playerStats;
    private PlayerStats stats;

    void Awake()
    {
        stats = playerStats.GetComponent<PlayerStats>();
        maxHunger = stats.getHealth();
    }

    void Start()
    {
        SetMaxHunger();
    }

    void Update()
    {
        SetHunger();
    }

    public void SetHunger()
    {
        slider.value = stats.getHealth();
    }
    public void SetMaxHunger()
    {
        slider.maxValue = maxHunger;
        slider.value = maxHunger;
    }
}
