using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player_Movement : MonoBehaviour 
{

    [SerializeField] protected float speed = 6.7f;

    [SerializeField] protected BoxCollider2D horizontalHitbox;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
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
            //animator.SetInteger("Movdir", 0);
            animator.SetFloat("x_mov", 1.0f);
            spriteRenderer.flipX = true;
        }
       if (movDir.x > 0)
        {
            //animator.SetInteger("Movdir", 1);
            animator.SetFloat("x_mov", 1.0f);
            spriteRenderer.flipX = false;
        }
        if (movDir.y < 0)
        {
          //  spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY = true;
            animator.SetFloat("y_mov", 1.0f);
            //animator.SetInteger("Movdir", 2);
        }
 
        if (movDir.y > 0)
        {
         //   spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY = false;
            animator.SetFloat("y_mov", 1.0f);
            //animator.SetInteger("Movdir", 3);
        }
        if(movDir.y == 0)
        {
            animator.SetFloat("y_mov", -1.0f);
            
        }
        if(movDir.x == 0)
        {
            animator.SetFloat("x_mov", -1.0f);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Movdir", 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputHandler(rb);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

}