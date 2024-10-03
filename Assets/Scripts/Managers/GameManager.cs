using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    public static int bestScore = 0;
    private static GameStates gameState = GameStates.Pre_Game;

    public static void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("Game");
    }

    public static void SetGameState(GameStates state)
    {
        gameState = state;
    }




}
