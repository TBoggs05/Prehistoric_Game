using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Play()
    {
        gameInPlay = true;

        // Check if on title screen and then load main scene and unload title scene
        if(SceneManager.GetActiveScene().name == "Title Screen")
            SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }
}
