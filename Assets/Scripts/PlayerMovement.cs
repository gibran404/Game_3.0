using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool alive = true;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public GameObject Boy;
    private SpriteRenderer spriteBoy;
    public GameObject Girl;
    private SpriteRenderer spriteGirl;

    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }


    // Start is called before the first frame update
    private void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteBoy = Boy.GetComponent<SpriteRenderer>();
        spriteGirl = Girl.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if alive = false, make spriteboy red
        if (!alive)
        {
            spriteBoy.color = Color.red;
            spriteGirl.color = Color.red;
            return;
        }
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }


    private void UpdateAnimationState()
    {
        MovementState state;
        state = MovementState.idle;

        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteBoy.flipX = false;
            spriteGirl.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            spriteBoy.flipX = true;
            spriteGirl.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        //anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }
}
