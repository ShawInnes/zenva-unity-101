using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private int level;

    [SerializeField]
    private bool lastLevel;

    private int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel = level + 1;
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        if (!lastLevel)
        {
            string sceneName = $"Level-{nextLevel}";
            LoadLevel(sceneName);
        }
        else
        {
            // goto main menu
            LoadLevel("Main-Menu");
        }
    }

    public void ReloadCurrentLevel()
    {
        LoadLevel($"Level-{level}");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
