using UnityEngine;
/// <summary>
/// Controls the camera's position and movement to follow the tower
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform topCube; // Reference to the top cube in the stack
    public float cameraYOffset = 3.5f; // Offset to maintain distance from the tower
    public float smoothSpeed = 0.125f; // How smoothly the camera moves

    private Vector3 initialPosition;
    public static CameraController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Store the camera's initial position
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        // Check if there is a cube to follow
        if (topCube != null)
        {
            // Calculate new camera position based on top cube's position
            Vector3 desiredPosition = new Vector3(transform.position.x, topCube.position.y + cameraYOffset, transform.position.z);
            
            // Smoothly move the camera to the new position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
