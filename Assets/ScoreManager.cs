using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int currentScore;

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
