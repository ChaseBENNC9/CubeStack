using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    public static int bestScore = 0;

    public static void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("Game");
    }
}
