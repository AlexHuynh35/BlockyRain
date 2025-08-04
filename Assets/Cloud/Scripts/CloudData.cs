using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "LevelAsset/CloudData")]
public class CloudData : ScriptableObject
{
    public Vector3 cloudLocation;
    public float startX;
    public float endX;
    public float speed;
    public List<GameObject> blocks;
}
