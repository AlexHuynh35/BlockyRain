using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public GameObject door;
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
        door.transform.position = position;
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
        Tilemap tilemap = Instantiate(map, Vector3.zero, Quaternion.identity, mapContainer.transform).GetComponent<Tilemap>();
        SetCameraBounds(tilemap);
    }

    void SetCameraBounds(Tilemap tilemap)
    {
        BoundsInt bounds = GetUsedTileBounds(tilemap);
        CameraManager cm = cam.GetComponent<CameraManager>();
        cm.minBounds = tilemap.CellToWorld(bounds.min);
        cm.maxBounds = tilemap.CellToWorld(bounds.max);
    }

    BoundsInt GetUsedTileBounds(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        int xMin = bounds.xMax;
        int xMax = bounds.xMin;
        int yMin = bounds.yMax;
        int yMax = bounds.yMin;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                if (tilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    if (x < xMin) xMin = x;
                    if (x > xMax) xMax = x;
                    if (y < yMin) yMin = y;
                    if (y > yMax) yMax = y;
                }
            }
        }
        return new BoundsInt(xMin, yMin, 0, xMax - xMin + 1, yMax - yMin + 1, 1);
    }

    void CheckPlayerFail()
    {

    }

    void CheckPlayerWin()
    {

    }
}
