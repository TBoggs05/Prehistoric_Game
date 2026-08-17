using UnityEngine;

public class egg_eater : MonoBehaviour
{
    protected bool hasLineOfSight;
    [SerializeField] protected bool isPlayer;
    private GameObject parent;
    [SerializeField] protected float satitety = 20f;
    private PlayerStats player;
    // Detects another Collider inside the trigger collider once per frame



         

    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if enemy is in line of sight using the BoxCollider
        if (other.gameObject.tag == "Player")
        {
            //play munch noisew
            //up stat for eggs eaten
            //up sustinance
            player = FindAnyObjectByType<PlayerStats>();
            player.addEggEaten(3);
            player.Eat(satitety);
            //destroy egg
            parent = (transform.parent).gameObject;
            (transform.parent).DetachChildren();
            Destroy(parent);
            Destroy(gameObject);
        }
    }


 
}
