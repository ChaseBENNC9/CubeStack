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
        IncreaseDifficulty();


        scoreText.text = currentScore.ToString();
        Debug.Log("Current Score: " + currentScore + " Best Score: " + GameManager.bestScore + " Last Score: " + GameManager.lastScore);

        if (currentScore >= GameManager.bestScore)
        {
            scoreText.color = highScoreColor;
        }

        

    }

    private void IncreaseDifficulty()
    {
        if (currentScore >= 0 && currentScore < 5)
        {
            BlockManager.instance.placementThreshold = 3f;
            BlockManager.instance.movementSpeed = 2f;
        }
        else if (currentScore >= 5 && currentScore < 10)
        {
            BlockManager.instance.placementThreshold = 2.5f;
            BlockManager.instance.movementSpeed = 2.5f;
        }
        else if (currentScore >= 10 && currentScore < 15)
        {
            BlockManager.instance.placementThreshold = 2f;
            BlockManager.instance.movementSpeed = 3f;
        }
        else if (currentScore >= 15 && currentScore < 20)
        {
            BlockManager.instance.placementThreshold = 1.5f;
            BlockManager.instance.movementSpeed = 3.5f;
        }
        else if (currentScore >= 20 && currentScore < 25)
        {
            BlockManager.instance.placementThreshold = 1.25f;
            BlockManager.instance.movementSpeed = 4f;
        }
        else if (currentScore > 25)
        {
            BlockManager.instance.placementThreshold = 0.75f;
            
        }
    }
  



}
