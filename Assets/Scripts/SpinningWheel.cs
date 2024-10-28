using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningWheel : MonoBehaviour
{
    private const float MIN_SPEED = 450f;
    private const float MAX_SPEED = 550f;
    public float decelerationRate = 50f; // Rate at which the wheel slows down
    private float currentSpeed;
    public List<string> sections = new List<string>
    {
        "Rewind",
        "All",
        "Repair",
        "Block",
        "Rewind",
        "Nothing",
        "Repair",
        "Block"
    };
    public Button spinButton;
    public Button continueButton;

    private void Start()
    {
        // Set the current speed to the initial speed
        currentSpeed = 0;
        spinButton.interactable = true;
        continueButton.interactable = false;
    }

    private void Update()
    {
        // Check if the wheel is still spinning
        if (currentSpeed > 0)
        {
            // Rotate the wheel based on the current speed
            transform.Rotate(0, 0, currentSpeed * Time.deltaTime);

            // Gradually reduce the speed
            currentSpeed -= decelerationRate * Time.deltaTime;

            // Clamp the speed to zero to prevent it from going negative
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
                CheckLandedSection();
                continueButton.interactable = true;
            }
        }
    }

    public void StartSpinning()
    {
        spinButton.interactable = false;
        currentSpeed = Random.Range(MIN_SPEED, MAX_SPEED);
    }

    private void CheckLandedSection()
    {
        float finalAngle = transform.eulerAngles.z;
        float adjustedAngle = (finalAngle + 22.5f) % 360;
        int sectionIndex = Mathf.FloorToInt(adjustedAngle / 45) % sections.Count;

        Debug.Log("Landed on: " + sections[sectionIndex]);
        DoReward(sections[sectionIndex]);
    }

    private void DoReward(string section)
    {
        Debug.Log("Landed on: " + section);

        switch (section)
        {
            case "Rewind":
                GameManager.powerupRewind++;

                break;
            case "All":
                GameManager.powerupPerfect++;
                GameManager.powerupRepair++;
                GameManager.powerupRewind ++;
                break;
            case "Repair":
                GameManager.powerupRepair++;
                break;
            case "Block":
                GameManager.powerupPerfect++;
                break;
            case "Nothing":

                Debug.Log("Better luck next time!");
                break;
        }

        GameManager.SaveGame();
        Debug.Log("Rewards: " + GameManager.powerupPerfect + " " + GameManager.powerupRepair);
    }
}
