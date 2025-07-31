using UnityEngine;

public abstract class BlockEffect : ScriptableObject, IBlockEffect
{
    public abstract void ApplyEffect(GameObject player);

    public abstract void RemoveEffect(GameObject player);
}
