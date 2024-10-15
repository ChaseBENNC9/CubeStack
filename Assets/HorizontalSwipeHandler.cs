using UnityEngine;
using UnityEngine.EventSystems;

public class HorizontalSwipeHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 startDragPosition;
    private float swipeThreshold = 50f; // Minimum distance for a swipe to be recognized

    // Called when the drag begins
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Record the initial drag position
        startDragPosition = eventData.position;
    }

    // Called while dragging (optional, can be used to show a real-time effect)
    public void OnDrag(PointerEventData eventData)
    {
        // Optional: Add visual effects during the drag here, if needed
    }

    // Called when the drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Calculate the swipe direction by comparing start and end drag positions
        Vector2 endDragPosition = eventData.position;
        DetectSwipe(startDragPosition, endDragPosition);
    }

    private void DetectSwipe(Vector2 start, Vector2 end)
    {
        float horizontalMove = end.x - start.x;

        // Only check for horizontal swipe
        if (Mathf.Abs(horizontalMove) > swipeThreshold)
        {
            if (horizontalMove > 0)
            {
                SwipeLeft();
            }
            else
            {
                SwipeRight();
            }
        }
    }

public GameObject[] helpScreens; // Assign your help screens in the Inspector
private int currentScreenIndex = 0;

private void SwipeLeft()
{
    Debug.Log("Swiped Left");
    // Navigate to the previous help screen
    if (currentScreenIndex > 0)
    {
        currentScreenIndex--;
    }
    else
    {
        currentScreenIndex = helpScreens.Length - 1;
    }
    MoveScreens();

}

private void SwipeRight()
{
    Debug.Log("Swiped Right");
    // Navigate to the next help screen
    if (currentScreenIndex < helpScreens.Length - 1)
    {
        currentScreenIndex++;
    }
    else
    {
        currentScreenIndex = 0;
    }
        MoveScreens();
}


private void MoveScreens()
{
    // Deactivate all screens first
    foreach (GameObject screen in helpScreens)
    {
        screen.SetActive(false);
    }
    
    // Activate the current screen
    helpScreens[currentScreenIndex].SetActive(true);
}
}
