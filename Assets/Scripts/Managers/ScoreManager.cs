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
    public bool passedLastScore = false;
    public bool passedBestScore = false;
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
        if (score < 0)
        {
            if (currentScore + score < 0)
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
        Debug.Log("Current Score: " + currentScore + " Best Score: " + GameManager.bestScore + " Last Score: " + GameManager.lastScore);
        if (currentScore >= GameManager.lastScore && !passedLastScore)
        {
            if (currentScore >= GameManager.bestScore && !passedBestScore && GameManager.bestScore != 0)
            {
                CreateScoreIndicator(false, currentScore);
            }
            else if (GameManager.lastScore != 0)
                CreateScoreIndicator(true, currentScore);
        }

    }
    private void CreateScoreIndicator(bool isPrevious, int score)
    {
        return;


        GameObject scoreIndicator = scoreIndicatorPrefab;
        
        if (isPrevious)
        {


                scoreIndicator.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().text = "Previous: " + GameManager.lastScore.ToString();
                Instantiate(scoreIndicator,new Vector3(-2.25f, BlockManager.instance.GetHighestBlock() + 0.5f, scoreIndicator.transform.position.z),Quaternion.identity,transform.parent);
                passedLastScore = true;
            
        }
        else if (!isPrevious)
        {
  
            
                scoreIndicator.transform.Find("text").GetComponent<TMPro.TextMeshProUGUI>().text = "Best: " + GameManager.bestScore.ToString();
                Instantiate(scoreIndicator,new Vector3(-2.25f, BlockManager.instance.GetHighestBlock() + 0.5f, scoreIndicator.transform.position.z),Quaternion.identity,transform.parent);
                passedBestScore = true;
            
        }
            Debug.Log(scoreIndicator.transform.position + " " + scoreIndicator.transform.localPosition);
    }



}
