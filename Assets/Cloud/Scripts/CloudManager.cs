using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public bool active = false;
    public float startX;
    public float endX;
    public float speed;
    public GameObject blockContainer;
    public List<GameObject> blocks;
    [SerializeField] private TextMeshProUGUI indicatorText;
    private int numBlocks;
    private int currentBlock;
    private Color currentColor;
    private Vector3 target;

    void Start()
    {
        numBlocks = blocks.Count;
        currentBlock = 0;
        UpdateIndicator();
        target = new Vector3(endX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        SpawnBlock();
        MoveX();
    }

    private float RoundNumToHalf(float num)
    {
        float roundedNum = Mathf.Round(num);
        if (Mathf.Approximately(num, roundedNum))
        {
            return roundedNum + 0.5f;
        }
        float distance = Mathf.Sign(num - roundedNum);
        return roundedNum + distance * 0.5f;
    }

    private void SpawnBlock()
    {
        if (currentBlock < numBlocks && active && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 position = new Vector3(RoundNumToHalf(transform.position.x), RoundNumToHalf(transform.position.y), 0);
            Instantiate(blocks[currentBlock], position, Quaternion.identity, blockContainer.transform);
            currentBlock += 1;
            UpdateIndicator();
        }
    }

    private void MoveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == new Vector3(endX, transform.position.y, transform.position.z)) ? new Vector3(startX, transform.position.y, transform.position.z) : new Vector3(endX, transform.position.y, transform.position.z);
        }
    }

    public void UpdateIndicator()
    {
        if (currentBlock < numBlocks)
        {
            currentColor = blocks[currentBlock].GetComponentInChildren<SpriteRenderer>().color;
            indicatorText.text = (numBlocks - currentBlock).ToString();
            indicatorText.color = currentColor;
        }
        else
        {
            currentColor = Color.gray;
            indicatorText.text = "0";
            indicatorText.color = currentColor;
        }
    }
}
