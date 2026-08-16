using UnityEngine;
//makes the player a locatable singleton
public class PlayerController : MonoBehaviour
{
    // Static reference that any script can see
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        // Enforce that there is only ever one player instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
