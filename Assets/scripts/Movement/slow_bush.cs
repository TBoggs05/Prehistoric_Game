using UnityEngine;

public class slow_bush : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_Movement>().speed /= 2;

            
            // Debug.Log("Entered zone: Setting up initial effects.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_Movement>().speed *= 2;

            // Debug.Log("Entered zone: Setting up initial effects.");
        }
    }
}
