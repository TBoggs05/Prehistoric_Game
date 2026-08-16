using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player_Movement : MonoBehaviour 
{

    [SerializeField] protected float speed = 6.7f;


    [SerializeField] protected CapsuleCollider2D hitbox;


    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 horizontalHitBoxSize = new Vector2(0.9565947f, 0.2712684f);
    private Vector2 veritcalHitBoxSize = new Vector2(0.2712684f, 0.9565947f);
    private Vector2 horizontalHitBoxOffset = new Vector2(-0.06698848f, -0.007702105f);
    private Vector2 veritcalHitBoxOffset = new Vector2(0.0f, -0.06f);
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

            SetHitBoxHorizontal();
        }
       if (movDir.x > 0)
        {
            //animator.SetInteger("Movdir", 1);
            animator.SetFloat("x_mov", 1.0f);
            spriteRenderer.flipX = false;

            SetHitBoxHorizontal();
        }
        if (movDir.y < 0)
        {
          //  spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY = true;
            animator.SetFloat("y_mov", 1.0f);
            //animator.SetInteger("Movdir", 2);

            SetHitBoxVeritcal();
        }
 
        if (movDir.y > 0)
        {
         //   spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY = false;
            animator.SetFloat("y_mov", 1.0f);
            //animator.SetInteger("Movdir", 3);

            SetHitBoxVeritcal();
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

    void SetHitBoxVeritcal()
    {
        hitbox.direction = CapsuleDirection2D.Vertical;
        hitbox.size = veritcalHitBoxSize;
        hitbox.offset = veritcalHitBoxOffset;
    }

    void SetHitBoxHorizontal()
    {
        hitbox.direction = CapsuleDirection2D.Horizontal;
        hitbox.size = horizontalHitBoxSize;
        hitbox.offset = horizontalHitBoxOffset;
    }
}