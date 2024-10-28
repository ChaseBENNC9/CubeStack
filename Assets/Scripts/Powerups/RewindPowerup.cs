using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindPowerup : Powerup
{

    private void Start()
    {
        powerupType = PowerupTypes.Rewind;

        count = GameManager.powerupRewind;
    }
    protected override void ActivatePowerup()
    {
        throw new System.NotImplementedException();
    }

    protected override bool PowerupRequirements()
    {
        //Either the current block is in the ready state or the block is moving and the block at the top of the stack below is weakened
        return InputManager.targetBlock.BlockState == BlockState.Ready 
        || (InputManager.targetBlock.BlockState == BlockState.Moving 
            && CameraController.instance.topCube != null 
            && CameraController.instance.topCube.gameObject.GetComponent<Block>().BlockState == BlockState.Weakened
            );
    }
        public override void PowerupPressed()
    {
        base.PowerupPressed();
        GameManager.powerupRewind = count;
    }

}
