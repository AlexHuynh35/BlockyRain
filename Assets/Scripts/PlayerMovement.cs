using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        animator.SetBool("isWalkingRight", move > 0);
        animator.SetBool("isWalkingLeft", move < 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Map")) {
            isGrounded = true;
        }
    }
}
