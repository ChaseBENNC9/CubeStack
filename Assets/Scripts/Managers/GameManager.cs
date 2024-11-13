using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// global game manager class
/// </summary>
public static class GameManager
{
    public static int bestScore = 0;
    public static int lastScore = 0;
    public static int powerupRepair = 2, powerupRewind = 2, powerupPerfect = 2;
    private static GameStates gameState = GameStates.Pre_Game;

    public static SaveData saveData;

/// <summary>
/// Loads the main menu scene
/// </summary>
    public static void MainMenu()
    {

        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// sets the current global game state
    /// </summary>
    public static void SetGameState(GameStates state)
    {
        gameState = state;
    }
    /// <summary>
    /// gets the current global game state
    /// </summary>
    /// <returns></returns>
    public static GameStates GetGameState()
    {
        return gameState;
    }
    /// <summary>
    /// Updates the best score if the current score is higher
    /// </summary>
    /// <param name="score"></param>

    public static void UpdateBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
    }

    /// <summary>
    /// Saves the game data to player prefs
    ///    </summary>
    public static void SaveGame()
    {
        SaveData data = new SaveData(bestScore, lastScore, powerupRepair, powerupRewind, powerupPerfect);
        saveData = data;
        Debug.Log("Saving Data: " + saveData.bestScore + " " + saveData.lastScore);
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Loads the game data from player pref and updates the best and last score and powerups
    ///  </summary>
    public static SaveData LoadGame()
    {
        SaveData data ;
        string json = PlayerPrefs.GetString("SaveData");
        if (json != null)
        {
            data = JsonUtility.FromJson<SaveData>(json);
            if (data != null)
            {
                bestScore = data.bestScore;
                lastScore = data.lastScore;
                powerupRepair = data.powerupRepair;
                powerupRewind = 0; //data.powerupRewind;
                powerupPerfect = data.powerupPerfect;
                Debug.Log("Save Data Loaded " + bestScore + " " + lastScore);
            }
            else
            {
                data = new SaveData(0,0);
                json = JsonUtility.ToJson(data);
                PlayerPrefs.SetString("SaveData", json);
            }
            Debug.Log("Save Data Loaded");



        }
        else //the data does not exist or is corrupted
        {
            data = new SaveData();
            json = JsonUtility.ToJson(data);
            Debug.LogError("No Save Data Found");
            PlayerPrefs.SetString("SaveData", json);


        }

        lastScore = data.lastScore;
        bestScore = data.bestScore;
        powerupRepair = data.powerupRepair;
        powerupRewind = data.powerupRewind;
        powerupPerfect = data.powerupPerfect;

        Debug.Log("Best Score: " + bestScore + " Last Score: " + lastScore);



        return data;


    }







}
