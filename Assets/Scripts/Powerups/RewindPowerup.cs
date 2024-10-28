using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindPowerup : Powerup
{
    protected override void ActivatePowerup()
    {
        throw new System.NotImplementedException();
    }

    protected override bool PowerupRequirements()
    {
        throw new System.NotImplementedException();
    }
        public override void PowerupPressed()
    {
        base.PowerupPressed();
        GameManager.powerupRewind = count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
