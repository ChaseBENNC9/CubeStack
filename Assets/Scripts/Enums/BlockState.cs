/// <summary>
/// Handles the possible states of a Block.
/// </summary>
public enum BlockState
{
    /// <summary>
    /// The Block is moving from one side of the screen to the other.
    /// </summary>
    Moving,
    /// <summary>
    /// The Block has stopped moving and is ready to be placed.
    /// </summary>
    Ready,
    /// <summary>
    /// The Block has been placed successfully.
    /// </summary>
    Placed,
    /// <summary>
    /// The Block has been placed successfully but is now weakened.
    /// </summary>
    Weakened,
    /// <summary>
    /// The Block was not placed successfully and is now broken.
    /// </summary>
    /// 
    Broken
}