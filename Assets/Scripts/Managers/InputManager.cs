using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
/// <summary>
/// Manages player input
/// </summary>
public class InputManager : MonoBehaviour
{

    public static Block targetBlock;
    private float clickStartTime;
    private float clickDurationThreshold = 0.2f; // Adjust this value for the desired tap speed




    /// <summary>
    /// Called when the player initially touches the screen
    /// </summary>
    public void PointerDown()
    {
        clickStartTime = Time.time;
        HoldScreen(true);
    }

    /// <summary>
    /// Called when the player stops touching the screen
    /// </summary>
    public void PointerUp()
    {
        // How long the pointer was held down
        float clickDuration = Time.time - clickStartTime;

        HoldScreen(false);

        // Whether this should be considered a tap or end of a hold
        if (clickDuration <= clickDurationThreshold)
        {
            TapScreen();
        }
    }


    /// <summary>
    /// Called when the player taps the screen
    /// </summary>
    private void TapScreen()
    {
        if (targetBlock == null) return;
        targetBlock.Tap();

    }




    /// <summary>
    /// Called when the player is holding down on the screen
    /// </summary>
    /// <param name="down">Whether the hold is currently down or not</param>
    private void HoldScreen(bool down)
    {
        if (targetBlock == null) return;

        targetBlock.Hold(down);
    }


}





