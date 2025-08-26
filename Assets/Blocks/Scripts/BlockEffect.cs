using UnityEngine;

public abstract class BlockEffect : ScriptableObject, IBlockEffect
{
    public abstract void OnStart(BlockManager block);
    public abstract void OnUpdate(BlockManager block);
    public abstract void HandleTriggerEnter(BlockManager block, GameObject other);
    public abstract void HandleTriggerExit(BlockManager block, GameObject other);
}
