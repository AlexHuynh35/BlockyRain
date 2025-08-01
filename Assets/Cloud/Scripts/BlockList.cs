using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "LevelData/BlockList")]
public class BlockList : ScriptableObject
{
    public List<GameObject> blocks;
}
