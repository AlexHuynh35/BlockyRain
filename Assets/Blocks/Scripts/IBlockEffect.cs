using System;
using UnityEngine;

public interface IBlockEffect
{
    public void OnStart(BlockManager block);
    public void OnUpdate(BlockManager block);
    public void HandleTriggerEnter(BlockManager block, GameObject other);
    public void HandleTriggerExit(BlockManager block, GameObject other);
}
