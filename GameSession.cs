using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    // Config parameters
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay;
    [SerializeField] TextMeshProUGUI livesText;

    // State parameters
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLives = 3;
    [SerializeField] int prevScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        livesText.text = currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlay;
    }

    public void AddtoScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void SubtractLives()
    {
        currentLives = currentLives - 1;
        if(currentLives < 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            FindObjectOfType<Sceen_Loader>().LoadCurrentScene();
            livesText.text = currentLives.ToString();
        }

    }

    public void UpdatePrevScore()
    {
        prevScore = currentScore;
    }

    public void ResetCurScore()
    {
        currentScore = prevScore;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
