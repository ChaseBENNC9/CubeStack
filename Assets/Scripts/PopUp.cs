using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PopUp : MonoBehaviour
{


    public void CreatePopUp(string message, Color color)
    {
        GetComponent<TextMeshProUGUI>().text = message;
        GetComponent<TextMeshProUGUI>().color = color;
        GetComponent<Animator>().enabled = true;
    }


    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
