using UnityEngine;

public class BlockEffectManager : MonoBehaviour
{
    public BlockEffect effect;
    private BlockManager block;
    
    void Start()
    {
        block = GetComponent<BlockManager>();
        effect.OnStart(block);
    }

    void Update()
    {
        effect.OnUpdate(block);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && effect != null)
        {
            effect.HandleTriggerEnter(block, other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null && effect != null)
        {
            effect.HandleTriggerExit(block, other.gameObject);
        }
    }
}
