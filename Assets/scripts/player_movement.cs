using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player_Movement : MonoBehaviour 
{

    [SerializeField] protected float speed = 6.7f;
    [SerializeField] protected Sprite upSprite;
    [SerializeField] protected Sprite leftSprite; //default
    [SerializeField] protected Sprite rightSprite;
    [SerializeField] protected Sprite downSprite;

    [SerializeField] protected BoxCollider2D horizontalHitbox;
    [SerializeField] protected BoxCollider2D vertHitbox;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
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
            spriteRenderer.sprite = leftSprite;
            animator.SetInteger("Movdir", 0);
            spriteRenderer.flipX = false;
        }
       else if (movDir.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
            animator.SetInteger("Movdir", 1);
            spriteRenderer.flipX = true;
        }
        else if(movDir.y < 0)
        {
            spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY  = true;
            animator.SetInteger("Movdir", 2);
        }
        
        else if (movDir.y > 0)
        {
            spriteRenderer.sprite = upSprite;
            spriteRenderer.flipY = false;
            animator.SetInteger("Movdir", 3);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Movdir", 0);
        facingLeft = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
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