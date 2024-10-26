using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;

    [SerializeField] private Image image;



    public void ToggleImage(bool isOn)
    {
        if (isOn)
        {
            image.sprite = onSprite;
        }
        else
        {
            image.sprite = offSprite;
        }
    }



}
