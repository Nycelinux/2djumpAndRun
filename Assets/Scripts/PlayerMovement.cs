using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float directionX;
    [SerializeField] public float moveSpeed = 6f;
    [SerializeField] public float jumpForce=7f;

    private enum MovementState {idle, running, jump, falling }
    private MovementState state=MovementState.idle;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider= GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(directionX* moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

     UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state; 

        if (directionX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (directionX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state=MovementState.jump;
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
