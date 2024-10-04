using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int currentScore;

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreIndicatorPrefab;
    private bool passedLastScore = false;
    private bool passedBestScore = false;
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
            CreateScoreIndicator(true, score);
        }
        if (score >= GameManager.bestScore)
        {
            CreateScoreIndicator(false, score);
        }

    }
    private void CreateScoreIndicator(bool isPrevious, int score)
    {

        if (isPrevious && passedLastScore)
        {
            return;
        }
        if (!isPrevious && passedBestScore)
        {
            return;
        }

            GameObject scoreIndicator = Instantiate(scoreIndicatorPrefab, transform.parent);
            scoreIndicator.transform.position = new Vector3(-2.25f, BlockManager.instance.GetHighestBlock() + 0.5f, scoreIndicator.transform.position.z);
            scoreIndicator.transform.localScale = 3 * scoreIndicator.transform.localScale;
            if(isPrevious)
            {
                scoreIndicator.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().text = "Previous: " + score.ToString();
                passedLastScore = true;
            }
            else
            {
                scoreIndicator.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + score.ToString();
                passedBestScore = true;
            }
    }
     


}
