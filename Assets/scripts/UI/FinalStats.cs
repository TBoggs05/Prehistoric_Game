using UnityEngine;
using TMPro;

public class FinalStats : MonoBehaviour
{
    public TextMeshProUGUI DinosKilled;
    public TextMeshProUGUI EggsKilled;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("No GameManager exists.");
            return;
        }

        DinosKilled.text =
            "Dinosaurs Eaten: " + GameManager.Instance.finalDinos;

        EggsKilled.text =
            "Eggs Eaten: " + GameManager.Instance.finalEggs;
    }
}