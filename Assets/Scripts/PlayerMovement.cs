using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float move = Input.GetAxis("Horizontal"); // left/right keys
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocityY);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Map")) {
            isGrounded = true;
        }
    }
}
