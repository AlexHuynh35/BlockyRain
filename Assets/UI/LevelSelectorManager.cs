using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Transform levelGrid;
    public int totalLevels;

    void Start()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);

        for (int i = 0; i < totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(levelButtonPrefab, levelGrid);
            Button button = buttonObj.GetComponent<Button>();
            TMP_Text label = buttonObj.GetComponentInChildren<TMP_Text>();

            label.text = "Level " + (i + 1).ToString();

            if (i <= unlockedLevels)
            {
                button.interactable = true;
                int levelIndex = i;
                button.onClick.AddListener(() => LoadLevel(levelIndex));
            }
            else
            {
                button.interactable = false;
            }
        }
    }

    void Update()
    {

    }

    void LoadLevel(int levelIndex)
    {
        LevelManager.SetLevel(levelIndex);
        SceneManager.LoadScene("Game");
    }
}