using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public BlockList blocks;
    private int currentBlock;
    private int numBlocks;

    void Start()
    {
        currentBlock = 0;
        numBlocks = blocks.blocks.Count;
    }

    void Update()
    {
        SpawnBlock();
    }

    void SpawnBlock()
    {
        if (currentBlock < numBlocks && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(blocks.blocks[currentBlock], transform.position, Quaternion.identity);
            currentBlock += 1;
        }
    }
}
