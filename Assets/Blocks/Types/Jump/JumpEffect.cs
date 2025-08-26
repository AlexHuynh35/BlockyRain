using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/JumpEffect")]
public class JumpEffect : BlockEffect
{
    public float jumpBoost;

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
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.jumpForce *= jumpBoost;
        }
    }

    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.jumpForce *= 1 / jumpBoost;
        }
    }
}
