using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// Manages the state of each of the  powerups in the game
/// </summary>
public class PowerupManager : MonoBehaviour
{
    /// <summary>
    /// List of powerups in the game that can be activated
    /// </summary>
   [SerializeField] private List<Powerup> powerups;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetGameState() == GameStates.In_Game)
        {
            UpdatePowerups();
        }

    }

    private void UpdatePowerups()
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.UpdateButton();
        }
    }
}
