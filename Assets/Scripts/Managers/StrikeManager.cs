using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StrikeManager : MonoBehaviour
{

    public static StrikeManager instance;
    [SerializeField] private GameObject strikes;
    [SerializeField] private GameObject strikePrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int strikeCount;
    public int StrikeCount
    {
        get { return strikeCount; }
        set
        {
            strikeCount = value;
            if (strikeCount >= MAX_STRIKES)
            {
                GameManager.lastScore = ScoreManager.instance.CurrentScore;
                Debug.Log("Last Score: " + GameManager.lastScore);
                if (ScoreManager.instance.CurrentScore > GameManager.bestScore)
                {
                    GameManager.UpdateBestScore(ScoreManager.instance.CurrentScore);
                    Debug.Log("Best Score: " + GameManager.bestScore);
                }

                Destroy(BlockManager.instance.GhostBlock.gameObject);
                Invoke("GameOver", .5f);

            }
        }
    }
    public const int MAX_STRIKES = 3;
    // Start is called before the first frame update
    void Start()
    {
        strikeCount = 0;
    }

    public void AddStrike()
    {
        if (strikeCount >= MAX_STRIKES)
        {
            return;
        }
        StrikeCount++;
        GameObject strike = Instantiate(strikePrefab, strikes.transform);
    }

    private void GameOver()
    {
        GameManager.SaveGame();
        PlayManager.instance.EndGame();
    }


}
