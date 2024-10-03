using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public GameObject placeholderBlock;
    public GameObject menuCanvas;
    public GameObject gameCanvas;

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
        GameManager.SetGameState(GameStates.Pre_Game);
        placeholderBlock.SetActive(true);
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }


}
