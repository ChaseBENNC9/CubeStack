using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GameManager.GameOver();
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
        StrikeCount++;
        GameObject strike = Instantiate(strikePrefab, strikes.transform);
    }


}
