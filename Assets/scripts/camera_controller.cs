using UnityEngine;

public class camera_controller : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed = 6.7f;
    [SerializeField] protected Vector3 offset = new Vector3(0f, 0f, -5f); //for z-axis
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
    }


}
