using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public static bool gameOver;
    public static bool nextScene;

    private static SceneManager instance;

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        nextScene = false;
        gameOverPanel.SetActive(false);
        gameOver = false;
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        gameOverPanel.SetActive(false);
    }

    public void NextLevel()
    {
        LoadNextScene();
    }

    private void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
        }

        if (nextScene)
        {
            NextLevel();
        }

    }
}
