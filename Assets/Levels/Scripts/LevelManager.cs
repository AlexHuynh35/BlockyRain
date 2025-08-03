using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public List<LevelData> levels;

    void Start()
    {
        LoadAllLevelsIntoList();
    }

    void Update()
    {

    }

    void LoadAllLevelsIntoList()
    {
        Addressables.LoadAssetsAsync<LevelData>("leveldata", level =>
        {
            levels.Add(level);
        }).Completed += op =>
        {
            LoadLevel(levels[currentLevel - 1]);
        };
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
