using UnityEngine;
using System.Collections.Generic;	

public class SpinningWheel : MonoBehaviour
{
    private const float MIN_SPEED = 450f;
    private const float MAX_SPEED = 550f;
    public float decelerationRate = 50f; // Rate at which the wheel slows down
    private float currentSpeed;
    public List<string> sections = new List<string> { "Rewind", "All", "Repair", "Block", "Rewind", "Nothing", "Repair", "Block" };


    private void Start()
    {
        // Set the current speed to the initial speed
        currentSpeed = 0;
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
            }
        }

    }

    public void StartSpinning()
    {
        currentSpeed = Random.Range(MIN_SPEED, MAX_SPEED);

    }

 private void CheckLandedSection()
{
    // Get the final angle of the wheel
    float finalAngle = transform.eulerAngles.z;

    // Adjust by subtracting 22.5 degrees to align with the center of each section
    float adjustedAngle = (finalAngle + 22.5f) % 360;

    // Calculate which section the wheel is pointing to
    int sectionIndex = Mathf.FloorToInt(adjustedAngle / 45) % sections.Count;

    // Display the result (can be replaced with other actions)
    Debug.Log("Landed on: " + sections[sectionIndex]);
}

}
