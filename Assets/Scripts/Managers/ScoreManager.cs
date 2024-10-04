using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int currentScore;

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreIndicatorPrefab;
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
        if(score < 0)
        {
            if(currentScore  + score < 0)
            {
                currentScore = 0;
            }
            else
            {
                currentScore += score;
            }
        }
        else
        {
        currentScore += score;
        }
        scoreText.text = currentScore.ToString();
        if (score >= GameManager.lastScore)
        {
            GameObject scoreIndicator = Instantiate(scoreIndicatorPrefab, transform);
            scoreIndicator.GetComponent<TMPro.TextMeshProUGUI>().text = "Previous: " + score.ToString();
        }
        if (score >= GameManager.bestScore)
        {
            GameObject scoreIndicator = Instantiate(scoreIndicatorPrefab, transform);
            scoreIndicator.GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + score.ToString();
        }

    }


}
