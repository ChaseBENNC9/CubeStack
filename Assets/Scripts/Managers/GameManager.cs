using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static int bestScore = 0;
    public static int lastScore = 0;
    public static int powerupRepair = 7, powerupRewind = 0, powerupPerfect = 2;
    private static GameStates gameState = GameStates.Pre_Game;

    public static SaveData saveData;

    public static void MainMenu()
    {
        Debug.Log("Game Over");

        SceneManager.LoadScene("Game");
    }

    public static void SetGameState(GameStates state)
    {
        gameState = state;
    }

    public static void UpdateBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
    }

    public static void SaveGame()
    {
        SaveData data = new SaveData(bestScore, lastScore, powerupRepair, powerupRewind, powerupPerfect);
        saveData = data;
        Debug.Log("Saving Data: " + saveData.bestScore + " " + saveData.lastScore);
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

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
        else
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
