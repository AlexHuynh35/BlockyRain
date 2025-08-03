using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int level = 1;
    private List<LevelData> data;
    void Start()
    {
        LoadLevel(data[level - 1]);
    }

    void Update()
    {

    }

    void LoadLevel(LevelData data)
    {
        SetPlayerStart(data.playerStart);
        SetLevelEnd(data.levelEnd);
        SetClouds(data.clouds);
    }

    void SetPlayerStart(Vector3 position)
    {

    }

    void SetLevelEnd(Vector3 position)
    {

    }

    void SetClouds(List<CloudData> clouds)
    {
        for (int i = 0; i < clouds.Count; i++)
        {
            
        }
    }

    void CheckPlayerFail()
    {

    }

    void CheckPlayerWin()
    {
        
    }
}
