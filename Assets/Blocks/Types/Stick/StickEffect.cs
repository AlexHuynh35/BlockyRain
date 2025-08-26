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
        if (other.CompareTag("Map"))
        {
            block.falling = false;
            block.SetStatic(true);

            Vector3 pos = block.transform.position;
            bool nothingBelow = Physics2D.Raycast(new Vector2(pos.x, pos.y - 1f), Vector2.down, 0.3f, LayerMask.GetMask("Puzzle")).collider == null;
            if (nothingBelow)
            {
                pos.y = Mathf.Floor(pos.y) - 0.5f;
                block.transform.position = pos;
            }
        }
    }
    
    public override void HandleTriggerExit(BlockManager block, GameObject other)
    {

    }
}
