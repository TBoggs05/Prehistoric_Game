using System;
using UnityEngine;
public class Player_Movement : MonoBehaviour 
{

    [SerializeField] protected float speed = 6.7f;


    private Rigidbody2D rb;
    private Vector2 movement;


    //currently using rigidbody physics based movement
    int inputHandler(Rigidbody2D player)
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized; //normalize vectors to fix diagonal speedboost
        return 0;
    }

    void Start()
    {
        Debug.Log("Hello World! I'm the Player");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Debug.Log("YO");
        inputHandler(rb);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

}