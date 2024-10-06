using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RepairPowerup : Powerup
{


    protected override void ActivatePowerup()
    {
        //active = true;
        //Functionality to repair the block


        //active = false;
        BeginCooldown();
    }
}
