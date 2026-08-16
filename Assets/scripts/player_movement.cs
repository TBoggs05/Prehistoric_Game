using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player_Movement : MonoBehaviour 
{

    [SerializeField] protected float speed = 6.7f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    GameObject player;
    Transform playerTransform;
    private bool facingLeft;
    private bool facingUp;
    //currently using rigidbody physics based movement
    int inputHandler(Rigidbody2D player)
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized; //normalize vectors to fix diagonal speedboost
        spriteHandler(movement);
        return 0;
    }
    //change sprite orientation based on current movement direction
    void spriteHandler(Vector2 movDir)
    {
      if(movDir.x < 0)
        {
            animator.SetInteger("Movdir", 0);
            
            playerTransform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
       else if (movDir.x > 0)
        {
            animator.SetInteger("Movdir", 1);

            playerTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if(movDir.y < 0)
        {
            animator.SetInteger("Movdir", 2);

            playerTransform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        
        else if (movDir.y > 0)
        {
            animator.SetInteger("Movdir", 3);

            playerTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Movdir", 0);
        facingLeft = true;
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
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