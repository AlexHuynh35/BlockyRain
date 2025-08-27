using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/WaitEffect")]
public class WaitEffect : BlockEffect
{
    public override void OnStart(BlockManager block)
    {

    }

    public override void OnUpdate(BlockManager block)
    {

    }

    public override void HandleTriggerEnter(BlockManager block, GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = block.transform.position;
            bool playerAbove = Physics2D.Raycast(new Vector2(pos.x, pos.y + 1f), Vector2.down, 0.3f, LayerMask.GetMask("Player")).collider != null;
            if (playerAbove)
            {
                block.falling = false;
                block.SetStatic(true);
            }
        }
    }

    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            block.falling = true;
            block.SetStatic(false);
        }
    }
}
