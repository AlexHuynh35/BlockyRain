using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public float startX;
    public float endX;
    public float speed = 2f;
    public List<GameObject> blocks;
    private int currentBlock;
    private int numBlocks;
    private Vector3 target;

    void Start()
    {
        currentBlock = 0;
        numBlocks = blocks.Count;
        target = new Vector3(endX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        SpawnBlock();
        MoveX();
    }

    float RoundNumToHalf(float num)
    {
        float roundedNum = Mathf.Round(num);
        if (Mathf.Approximately(num, roundedNum))
        {
            return roundedNum + 0.5f;
        }
        float distance = Mathf.Sign(num - roundedNum);
        return roundedNum + distance * 0.5f;
    }

    void SpawnBlock()
    {
        if (currentBlock < numBlocks && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 position = new Vector3(RoundNumToHalf(transform.position.x), RoundNumToHalf(transform.position.y), 0);
            Instantiate(blocks[currentBlock], position, Quaternion.identity);
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
