using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class Enemy_Movement : MonoBehaviour
{

    [SerializeField] protected float speed = 6f;
    private float interval = 0.7f;
    [SerializeField] protected BoxCollider2D horizontalHitbox;

    [SerializeField] protected CircleCollider2D alertHitbox;
    [SerializeField] protected GameObject player; // will need to draw force vector towards player

    private Vector2 movementDirection;

    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //currently using rigidbody physics based movement
    //change sprite orientation based on current movement direction
    void spriteHandler(Vector2 movDir)
    {
        
        if (movDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (movDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (movDir.y < 0)
        {
            spriteRenderer.flipY = true;
        }
        if (movDir.y > 0)
        {
            spriteRenderer.flipY = false;
        }
        if(Math.Abs(movDir.y) > Math.Abs(movDir.x))
        {
            
            animator.SetFloat("y_mov", 1.0f);
            animator.SetFloat("x_mov", 0.0f);
        }
        else if (Math.Abs(movDir.y) < Math.Abs(movDir.x))
        {
            animator.SetFloat("x_mov", 1.0f);
            animator.SetFloat("y_mov", 0.0f);
        }
        else
        {
            animator.SetFloat("x_mov", 0.0f);
            animator.SetFloat("y_mov", 0.0f);
        }

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Movdir", 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
       // huntPlayer();
    }
    void Update()
    {
        spriteHandler(movement);
        Debug.Log(movement.ToString());
    }
    void huntPlayer()
    {
        Debug.Log("GOING TO HURT PLAYER!");
        //calculate vector line to player
        movement = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y).normalized;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            huntPlayer();
            StartCoroutine(refindPlayer(interval));
            Debug.Log("Entered zone: Setting up initial effects.");
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    private IEnumerator refindPlayer(float interval)
    {
        yield return new WaitForSeconds(interval);
        huntPlayer();
            
        StartCoroutine(refindPlayer(interval));
        
    }
}