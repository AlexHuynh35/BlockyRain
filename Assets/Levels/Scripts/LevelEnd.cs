using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private LevelManager lm;

    void Start()
    {
        lm = GetComponentInParent<LevelManager>();
    }

    void Update()
    {

    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("w"))
        {
            lm.PlayerWin();
        }
    }
}
