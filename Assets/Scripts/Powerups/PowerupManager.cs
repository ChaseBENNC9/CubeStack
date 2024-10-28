using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private List<Powerup> powerups;
    void Start()
    {
    }

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
