using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/JumpEffect")]
public class JumpEffect : BlockEffect
{
    public float jumpBoost;
    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.jumpForce *= jumpBoost;
    }

    public override void RemoveEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.jumpForce *= 1 / jumpBoost;
    }
}
