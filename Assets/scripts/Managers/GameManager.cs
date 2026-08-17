using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public int finalEggs = 0;
    public int finalDinos = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 60;
    }

   

    public void Play()
    {
        finalEggs = 0;
        finalDinos = 0;

        SceneManager.LoadSceneAsync(
            "MainScene",
            LoadSceneMode.Single
        );
    }

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(
            "DeathScreen",
            LoadSceneMode.Single
        );
    }
}