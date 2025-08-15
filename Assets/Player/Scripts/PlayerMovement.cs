using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float groundSpeed = 5f;
    public float airSpeed = 3f;
    public float airControlTime = 0.2f;
    public float groundAccel = 50f;
    public float airAccel = 20f;
    public float speed;
    private float timeSinceGrounded = 0f;
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
        float move = Input.GetAxisRaw("Horizontal");
        bool isGrounded = IsGrounded();

        CountTimeSinceGrounded(isGrounded);
        HandleMovement(move);

        if (Input.GetButtonDown("Jump") && isGrounded)
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

    private void HandleMovement(float move)
    {
        float airControlFactor = Mathf.Clamp01(timeSinceGrounded / airControlTime);

        float currentMaxSpeed = Mathf.Lerp(groundSpeed, airSpeed, airControlFactor);
        float currentAccel = Mathf.Lerp(groundAccel, airAccel, airControlFactor);

        float targetVelX = move * currentMaxSpeed;
        float velX = Mathf.MoveTowards(rb.linearVelocity.x, targetVelX, currentAccel * Time.deltaTime);

        rb.linearVelocity = new Vector2(velX, rb.linearVelocity.y);
    }

    private void CountTimeSinceGrounded(bool isGrounded)
    {
        if (isGrounded)
        {
            timeSinceGrounded = 0f;
        }
        else
        {
            timeSinceGrounded += Time.deltaTime;
        }
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
