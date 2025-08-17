using UnityEngine;

[CreateAssetMenu(menuName = "BlockEffects/SpeedEffect")]
public class SpeedEffect : BlockEffect
{
    public float speed_boost;

    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.groundSpeed *= speed_boost;
        pm.airSpeed *= speed_boost;
        pm.groundAccel *= speed_boost;
        pm.airAccel *= speed_boost;
    }

    public override void RemoveEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.groundSpeed *= 1 / speed_boost;
        pm.airSpeed *= 1 / speed_boost;
        pm.groundAccel *= 1 / speed_boost;
        pm.airAccel *= 1 / speed_boost;
    }
}
