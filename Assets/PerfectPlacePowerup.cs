using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PerfectPlacePowerup : Powerup
{

    private void Start()
    {
        powerupType = PowerupTypes.Perfect;
    }



    protected override bool PowerupRequirements()
    {
        if(InputManager.targetBlock == null) return false;
        return InputManager.targetBlock.BlockState == BlockState.Ready;
    }


    protected override void ActivatePowerup()
    {
        Block b = InputManager.targetBlock;
        b.PlacePerfectBlock();
        
        PlayManager.instance.activePowerup = powerupType;
        //Functionality to repair the block

        

        PlayManager.instance.activePowerup = PowerupTypes.None;

        //active = false;
        BeginCooldown();
    }





}
