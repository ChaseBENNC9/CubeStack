using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static Block targetBlock;
    [SerializeField] private Block test;


    private void Update()
    {
        test = targetBlock;
    }
    public void TapScreen()
    {
        if(targetBlock == null) return;
            targetBlock.Tap();

    }
    

           public void HoldScreen(bool down)
    {
        if(targetBlock == null) return;

        targetBlock.Hold(down);
    }


    }





