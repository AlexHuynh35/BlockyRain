using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/SpeedEffect")]
public class SpeedEffect : BlockEffect
{
    public float speedBoost;

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
            pm.groundSpeed *= speedBoost;
            pm.airSpeed *= speedBoost;
            pm.groundAccel *= speedBoost;
            pm.airAccel *= speedBoost;
        }
    }

    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.groundSpeed *= 1 / speedBoost;
            pm.airSpeed *= 1 / speedBoost;
            pm.groundAccel *= 1 / speedBoost;
            pm.airAccel *= 1 / speedBoost;
        }
    }
}
