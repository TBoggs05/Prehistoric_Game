using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main manager for title and all of the game. Main fuctions will go here for gameplay loop
public class GameManager : MonoBehaviour
{
    [SerializeField] public bool gameOver = false;
    
    public static GameManager Instance { get; private set; }

    void Awake ()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            GameOver();
        }
    }

    public void Play()
    {
        gameOver = false;

        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadSceneAsync("DeathScreen", LoadSceneMode.Single);
    }
}
