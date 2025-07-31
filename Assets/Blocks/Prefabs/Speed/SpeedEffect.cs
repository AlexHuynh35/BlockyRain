using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/SpeedEffect")]
public class SpeedEffect : BlockEffect
{
    public float speed_boost;
    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.speed *= speed_boost;
    }

    public override void RemoveEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.speed *= 1 / speed_boost;
    }
}
