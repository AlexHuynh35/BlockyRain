using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private LevelManager lm;
    private bool playerInGoal = false;

    void Start()
    {
        lm = GetComponentInParent<LevelManager>();
    }

    void Update()
    {
        if (playerInGoal && Input.GetKeyDown(KeyCode.W))
        {
            lm.PlayerWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInGoal = false;
        }
    }
}
