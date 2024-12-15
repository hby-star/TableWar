using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
    #endregion



    public Button startButton;
    public Button pauseButton;
    public Button resetButton;

    public TextMeshProUGUI enemyKilledCountText;
    public TextMeshProUGUI enemyMissedCountText;

    private int enemyKilledCount = 0;
    private int enemyMissedCount = 0;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        pauseButton.onClick.AddListener(PauseGame);
        resetButton.onClick.AddListener(ResetGame);

        Time.timeScale = 0;
        enemyKilledCountText.text = enemyKilledCount.ToString();
        enemyMissedCountText.text = enemyMissedCount.ToString();
    }

    public void AddEnemyKilledCount()
    {
        enemyKilledCount++;
        enemyKilledCountText.text = enemyKilledCount.ToString();
    }

    public void AddEnemyMissedCount()
    {
        enemyMissedCount++;
        enemyMissedCountText.text = enemyMissedCount.ToString();
    }


    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
