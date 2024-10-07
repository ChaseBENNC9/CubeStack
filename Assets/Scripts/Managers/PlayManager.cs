using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayManager : MonoBehaviour
{
    public GameObject placeholderBlock;
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public TextMeshProUGUI bestScoreText;
    public static PlayManager instance;
    public  bool onUI = false;
    public  PowerupTypes activePowerup;

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
        activePowerup = PowerupTypes.None;

    }

    public void UpdateUI()
    {
        bestScoreText.text = GameManager.bestScore.ToString();
    }

private void Update()
    {

        if (EventSystem.current.currentSelectedGameObject != null )
        {

            if (EventSystem.current.currentSelectedGameObject.tag == "UI")
            {
                onUI = true;
                Debug.Log("On UI");
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);

            }
            else
            {
                onUI = false;
                Debug.Log("Not on UI");
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            }
        }
        else
        {
            onUI = false;
            Debug.Log("Current Selected Game Object is null");
        }
    }

}
