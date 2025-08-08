using System.Collections.Generic;
using System.Linq;
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
    public GameObject blockContainer;
    public Grid mapContainer;
    public Camera cam;
    public List<LevelData> levels;

    private int currentLevel = 0;

    void Start()
    {
        LoadAllLevelsIntoList();
    }

    void Update()
    {

    }

    private void LoadAllLevelsIntoList()
    {
        Addressables.LoadAssetsAsync<LevelData>("leveldata", level =>
        {
            levels.Add(level);
        }).Completed += op =>
        {
            levels = levels.OrderBy(level => level.level).ToList();
            LoadLevel(levels[currentLevel]);
            currentLevel++;
        };
    }

    private void LoadLevel(LevelData data)
    {
        SetPlayerStart(data.playerStart);
        SetLevelEnd(data.levelEnd);
        SetClouds(data.clouds);
        SetMap(data.map);
    }

    private void SetPlayerStart(Vector3 position)
    {
        player.transform.position = position;
    }

    private void SetLevelEnd(Vector3 position)
    {
        door.transform.position = position;
    }

    private void SetClouds(List<CloudData> clouds)
    {
        foreach (CloudData cloud in clouds)
        {
            GameObject currentCloud = Instantiate(cloudPrefab, cloud.cloudLocation, Quaternion.identity, cloudContainer.transform);
            CloudManager cm = currentCloud.GetComponent<CloudManager>();
            cm.startX = cloud.startX;
            cm.endX = cloud.endX;
            cm.speed = cloud.speed;
            cm.blockContainer = blockContainer;
            cm.blocks = cloud.blocks;
        }
    }

    private void SetMap(GameObject map)
    {
        Tilemap tilemap = Instantiate(map, Vector3.zero, Quaternion.identity, mapContainer.transform).GetComponent<Tilemap>();
        SetCameraBounds(tilemap);
    }

    private void SetCameraBounds(Tilemap tilemap)
    {
        BoundsInt bounds = GetUsedTileBounds(tilemap);
        CameraManager cm = cam.GetComponent<CameraManager>();
        cm.minBounds = tilemap.CellToWorld(bounds.min);
        cm.maxBounds = tilemap.CellToWorld(bounds.max);
    }

    private BoundsInt GetUsedTileBounds(Tilemap tilemap)
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

    public void PlayerFail()
    {
        ResetLevel();
        LoadLevel(levels[currentLevel - 1]);
    }

    public void PlayerWin()
    {
        if (currentLevel >= levels.Count)
        {
            Debug.Log("You Win!");
        }
        else
        {
            ResetLevel();
            LoadLevel(levels[currentLevel]);
            currentLevel++;
        }
    }

    private void ResetLevel()
    {
        for (int i = cloudContainer.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(cloudContainer.transform.GetChild(i).gameObject);
        }

        for (int i = blockContainer.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(blockContainer.transform.GetChild(i).gameObject);
        }

        Destroy(mapContainer.transform.GetChild(0).gameObject);
    }
}
