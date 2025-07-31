using System;
using UnityEngine;

public interface IBlockEffect
{
    public void ApplyEffect(GameObject player);
    public void RemoveEffect(GameObject player);
}
