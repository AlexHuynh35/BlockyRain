using System.Collections.Generic;
using UnityEngine;

public class CloudSwitcher : MonoBehaviour
{
    [HideInInspector] public List<CloudManager> clouds;
    [HideInInspector] public List<SpriteRenderer> cloudSprites;
    [HideInInspector] public int size;
    private int current = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && current < size - 1)
        {
            clouds[current].active = false;
            cloudSprites[current].color = Color.gray;
            current++;
            clouds[current].active = true;
            cloudSprites[current].color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Q) && current > 0)
        {
            clouds[current].active = false;
            cloudSprites[current].color = Color.gray;
            current--;
            clouds[current].active = true;
            cloudSprites[current].color = Color.white;
        }
    }

    public void ResetSwitcher()
    {
        clouds.Clear();
        cloudSprites.Clear();
        size = 0;
        current = 0;
    }
}
