using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public static Block targetBlock;
    private float clickStartTime;
    private float clickDurationThreshold = 0.2f; // Adjust this value for the desired tap speed


    private void Update()
    {
    }

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
        Debug.Log("Tapped");

    }




    /// <summary>
    /// Called when the player is holding down on the screen
    /// </summary>
    /// <param name="down">Whether the hold is currently down or not</param>
    private void HoldScreen(bool down)
    {
        Debug.Log("Held");
    }


}






