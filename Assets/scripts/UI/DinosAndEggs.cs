using UnityEngine;
using TMPro; // 1. Include the TextMeshPro namespace

public class TextChanger : MonoBehaviour
{
    public TextMeshProUGUI DinosKilled; 
    public TextMeshProUGUI EggsKilled;
    protected PlayerStats playerStats;

    void Start()
    {
        // 3. Edit the text by assigning a new string
        DinosKilled.text = "Dinosaurs Eaten: 0";
        EggsKilled.text = "Eggs Eaten: 0";
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    void Update()
    {
        DinosKilled.text = "Dinosaurs Eaten: " + playerStats.getDinosKileld();
        EggsKilled.text = "Eggs Eaten: " + playerStats.getEggsEaten();
    }
}