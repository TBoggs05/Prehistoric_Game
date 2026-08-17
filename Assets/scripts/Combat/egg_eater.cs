using UnityEngine;

public class egg_eater : MonoBehaviour
{
    protected bool hasLineOfSight;
    [SerializeField] protected bool isPlayer;
    private GameObject parent;
    // Detects another Collider inside the trigger collider once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if (other.gameObject.tag == "Player")
        {
            //play munch noise
            //up stat for eggs eaten
            //up sustinance
            //destroy egg
            parent = (transform.parent).gameObject;
            (transform.parent).DetachChildren();
            Destroy(parent);
            Destroy(gameObject);
        }
    }


 
}
