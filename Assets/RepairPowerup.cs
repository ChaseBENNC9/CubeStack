using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RepairPowerup : Powerup
{
    [SerializeField] private GameObject repairButton;
    private List<GameObject> repairButtons = new List<GameObject>();
    private void Start()
    {
        powerupType = PowerupTypes.Repair;
    }



    protected override bool PowerupRequirements()
    {
        Debug.Log("Stack Size:  " + BlockManager.instance.GetStackSize());
        return BlockManager.instance.GetStackSize() > 0 && InputManager.targetBlock.BlockState == BlockState.Moving;
    }


    protected override void ActivatePowerup()
    {
        //active = true;
        if (BlockManager.instance.GetStackSize() == 0)
        {
            Debug.Log("No blocks to repair");
            return;
        }
            Destroy(InputManager.targetBlock.gameObject);
        foreach (Block block in BlockManager.instance.blockStack)
        {
            if (block.BlockState == BlockState.Weakened)
            {
                GameObject g = Instantiate(repairButton);
                repairButtons.Add(g);
                g.name = "RepairButton";
                g.transform.SetParent(block.gameObject.transform.Find("Canvas").transform.Find("ButtonCanvas"));
                block.gameObject.transform.Find("Canvas").transform.Find("ButtonCanvas").GetComponent<Canvas>().enabled = true;

                g.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                g.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                g.GetComponent<Button>().onClick.AddListener(() => RepairThisBlock(block));
                break;
            }
        }
        PlayManager.instance.activePowerup = powerupType;
        //Functionality to repair the block

        


        //active = false;
        BeginCooldown();
    }

    public void RepairThisBlock(Block block)
    {
        //Functionality to repair the block
        Block targetBlock = block;
        if (targetBlock != null)
        {
            Debug.Log("Repairing block");


            targetBlock.IncreaseStrength(25);
        }
        else
        {
            Debug.LogError("Block not found");
        }
        ClearButtons();
        PlayManager.instance.activePowerup = PowerupTypes.None;
        BlockManager.instance.CreateBlock();
    }


    private void ClearButtons()
    {
        foreach (GameObject g in repairButtons)
        {
            g.transform.parent.GetComponent<Canvas>().enabled = false;
            Destroy(g);
        }
        repairButtons.Clear();


    }
}
