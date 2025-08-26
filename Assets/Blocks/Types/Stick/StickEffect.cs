using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/StickEffect")]
public class StickEffect : BlockEffect
{
    public override void OnStart(BlockManager block)
    {

    }

    public override void OnUpdate(BlockManager block)
    {

    }

    public override void HandleTriggerEnter(BlockManager block, GameObject other)
    {
        if (other.CompareTag("Puzzle"))
        {
            block.falling = false;
        }
    }
    
    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {

    }
}
