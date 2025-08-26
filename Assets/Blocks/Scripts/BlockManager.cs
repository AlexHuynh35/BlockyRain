using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public float fallSpeed = 2f;
    public bool falling = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        if (falling)
        {
            rb.MovePosition(rb.position + Vector2.down * fallSpeed * Time.fixedDeltaTime);
        }
    }
}
