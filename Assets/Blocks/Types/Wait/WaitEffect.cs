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
            block.falling = false;
            block.SetStatic(true);
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
