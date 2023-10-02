using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnim : MonoBehaviour
{
    // Player's rigidbody2d
    private Rigidbody2D rb;
    // Player's animator
    private Animator animator;
    // Player's sprite renderer
    private SpriteRenderer spr;

    // Can the player jump?
    private bool canJump;

    // How fast the player can move
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning the player variables
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input moving left and right
        float x = Input.GetAxis("Horizontal");
        // Get player input moving up and down
        float y = Input.GetAxis("Vertical");

        // Move the player!
        Vector2 movementVector = new Vector2(x * speed, rb.velocity[1]);
        rb.velocity = movementVector;

        if (Input.GetKeyDown("w") && canJump) {
            rb.AddForce(Vector2.up * 13.0f, ForceMode2D.Impulse);
            animator.SetFloat("yPos", 1.0f);
        }

        // Animation and Direction
        if (x < 0.0f) {
            spr.flipX = true;
        } else if (x > 0.0f) {
            spr.flipX = false;
        }
        animator.SetFloat("xPos", x);
        animator.SetFloat("yPos", y);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            canJump = true;
        }

        if (other.gameObject.CompareTag("Head")) {
            rb.AddForce(Vector2.up * 15.0f, ForceMode2D.Impulse);
            animator.SetFloat("yPos", 1.0f);
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor")) {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        canJump = false;
    }
}
