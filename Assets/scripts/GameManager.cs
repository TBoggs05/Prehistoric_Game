using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool gameInPlay = false;
    [SerializeField] private bool gameOver = false;
    [SerializeField] private GameManager instance;

    void Awake ()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
