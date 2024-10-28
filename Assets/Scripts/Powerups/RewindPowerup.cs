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
        if(InputManager.targetBlock.BlockState == BlockState.Ready)
        {
            BlockManager.instance.RemoveFromStack(InputManager.targetBlock);
            Destroy(InputManager.targetBlock.gameObject);
            BlockManager.instance.CreateBlock();
            Debug.Log("Rewind");
        }
else if(InputManager.targetBlock.BlockState == BlockState.Moving && CameraController.instance.topCube != null 
            && CameraController.instance.topCube.gameObject.GetComponent<Block>().BlockState == BlockState.Weakened)
        {
            GameObject temp = InputManager.targetBlock.gameObject;
            InputManager.targetBlock = CameraController.instance.topCube.gameObject.GetComponent<Block>();
            InputManager.targetBlock.ReadyBlock();
            
            Destroy(temp);
            ScoreManager.instance.AddScore(-1); //Removes the score for the block that was destroyed
        }
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
