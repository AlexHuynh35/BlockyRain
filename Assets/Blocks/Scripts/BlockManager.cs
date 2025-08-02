using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public float fallSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        rb.MovePosition(rb.position + Vector2.down * fallSpeed * Time.fixedDeltaTime);
    }
}
