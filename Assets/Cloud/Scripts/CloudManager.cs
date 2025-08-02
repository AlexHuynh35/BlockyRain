using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public BlockList blocks;
    public int startX;
    public int endX;
    public float speed = 2f;
    private int currentBlock;
    private int numBlocks;
    private Vector3 target;

    void Start()
    {
        currentBlock = 0;
        numBlocks = blocks.blocks.Count;
        target = new Vector3(endX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        SpawnBlock();
        MoveX();
    }

    void SpawnBlock()
    {
        if (currentBlock < numBlocks && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 position = new Vector3(Mathf.Round(transform.position.x * 2f) / 2f, Mathf.Round(transform.position.y * 2f) / 2f, 0);
            Instantiate(blocks.blocks[currentBlock], position, Quaternion.identity);
            currentBlock += 1;
        }
    }

    void MoveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == new Vector3(endX, transform.position.y, transform.position.z)) ? new Vector3(startX, transform.position.y, transform.position.z) : new Vector3(endX, transform.position.y, transform.position.z);
        }
    }
}
