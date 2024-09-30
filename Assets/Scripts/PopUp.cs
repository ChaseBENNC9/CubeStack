using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PopUp : MonoBehaviour
{



/// <summary>
/// Creates a pop up message with the given message and color
/// </summary>
/// <param name="message"></param>
/// <param name="color"></param>
    public void CreatePopUp(string message, Color color)
    {
        GetComponent<TextMeshProUGUI>().text = message;
        GetComponent<TextMeshProUGUI>().color = color;
        GetComponent<Animator>().enabled = true;
    }


/// <summary>
/// Destroys the pop up message, called by the animation event
/// </summary>
    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
