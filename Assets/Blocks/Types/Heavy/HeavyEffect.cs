using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/HeavyEffect")]
public class HeavyEffect : BlockEffect
{
    public float fallMultiplier;

    public override void OnStart(BlockManager block)
    {
        block.fallSpeed *= fallMultiplier;
    }

    public override void OnUpdate(BlockManager block)
    {

    }

    public override void HandleTriggerEnter(BlockManager block, GameObject other)
    {
        
    }
    
    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {

    }
}
