using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private LevelManager lm;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lm = GetComponentInParent<LevelManager>();
    }

    void Update()
    {
        PlayerMove();
        PlayerReset();
    }

    private void PlayerMove()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetBool("isWalkingRight", move > 0);
        animator.SetBool("isWalkingLeft", move < 0);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer);
    }

    private void PlayerReset()
    {
        if (Input.GetKeyDown("r") || PlayerOutOfBound())
        {
            lm.PlayerFail();
        }
    }

    private bool PlayerOutOfBound()
    {
        return transform.position.y < -100;
    }
}
