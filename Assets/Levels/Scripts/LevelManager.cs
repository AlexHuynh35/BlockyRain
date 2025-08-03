using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public GameObject cloudPrefab;
    public GameObject cloudContainer;
    public Grid mapContainer;
    public Camera cam;

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
            currentLevel++;
        };
    }

    void LoadLevel(LevelData data)
    {
        SetPlayerStart(data.playerStart);
        SetLevelEnd(data.levelEnd);
        SetClouds(data.clouds);
        SetMap(data.map);
    }

    void SetPlayerStart(Vector3 position)
    {
        player.transform.position = position;
    }

    void SetLevelEnd(Vector3 position)
    {

    }

    void SetClouds(List<CloudData> clouds)
    {
        foreach (CloudData cloud in clouds)
        {
            GameObject currentCloud = Instantiate(cloudPrefab, cloud.cloudLocation, Quaternion.identity, cloudContainer.transform);
            CloudManager cm = currentCloud.GetComponent<CloudManager>();
            cm.startX = cloud.startX;
            cm.endX = cloud.endX;
            cm.speed = cloud.speed;
            cm.blocks = cloud.blocks;
        }
    }

    void SetMap(GameObject map)
    {
        Instantiate(map, Vector3.zero, Quaternion.identity, mapContainer.transform);
    }

    void CheckPlayerFail()
    {

    }

    void CheckPlayerWin()
    {

    }
}
