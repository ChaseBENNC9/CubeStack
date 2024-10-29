using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int currentScore;
    public int CurrentScore
    {
        get { return currentScore; }
    }

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreIndicatorPrefab;
    [SerializeField] private Color highScoreColor;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
    void Update()
    {

    }

    public void AddScore(int score)
    {
        if (currentScore + score < 0)
        {
            currentScore = 0;
        }
        else
        {
            currentScore += score;
        }


        scoreText.text = currentScore.ToString();
        Debug.Log("Current Score: " + currentScore + " Best Score: " + GameManager.bestScore + " Last Score: " + GameManager.lastScore);

        if (currentScore >= GameManager.bestScore)
        {
            scoreText.color = highScoreColor;
        }

        

    }
  



}
