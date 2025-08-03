using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "LevelAsset/LevelData")]
public class LevelData : ScriptableObject
{
    public GameObject map;
    public Vector3 playerStart;
    public Vector3 levelEnd;
    public List<CloudData> clouds;
}
