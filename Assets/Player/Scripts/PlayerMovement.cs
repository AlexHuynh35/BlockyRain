using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* --- Movement --- */
    public float groundSpeed = 5f;
    public float airSpeed = 3.7f;
    public float groundAccel = 50f;
    public float airAccel = 37f;
    [SerializeField] private float airControlTime = 0.2f;

    /* --- Jump --- */
    public float jumpForce = 50f;
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    /* --- On Start --- */
    private Animator animator;
    private Rigidbody2D rb;
    private LevelManager lm;

    /* --- State --- */
    private bool isJumped = false;
    private bool isGrounded = true;
    private float timeSinceGrounded = 0f;
    private float coyoteTimeCounter;

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

        IsGrounded();
        CountTimeSinceGrounded();

        HandleMovement(move);
        HandleJump();

        animator.SetBool("isWalkingRight", move > 0);
        animator.SetBool("isWalkingLeft", move < 0);
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer);
    }

    private void CountTimeSinceGrounded()
    {
        if (isGrounded)
        {
            isJumped = false;
            timeSinceGrounded = 0f;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            timeSinceGrounded += Time.deltaTime;
            coyoteTimeCounter -= Time.deltaTime;
        }
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

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f && !isJumped)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumped = true;
            coyoteTimeCounter = 0f;
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
        return transform.position.y < -25;
    }
}
