using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayManager : MonoBehaviour
{
    public GameObject placeholderBlock;
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public TextMeshProUGUI bestScoreText;
    public static PlayManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        placeholderBlock.SetActive(false);
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        GameManager.SetGameState(GameStates.In_Game);
        BlockManager.instance.CreateBlock();
    }
    private void Start()
    {
        GameManager.saveData = GameManager.LoadGame();
        UpdateUI();
        GameManager.SetGameState(GameStates.Pre_Game);
        placeholderBlock.SetActive(true);
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);

    }

    public void UpdateUI()
    {
        bestScoreText.text = GameManager.bestScore.ToString();
    }


}
