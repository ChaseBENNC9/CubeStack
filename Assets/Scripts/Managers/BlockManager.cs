using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform blockSpawnPoint; 
    private const float SPAWN_OFFSET = 2f;
    public static BlockManager instance;
    public int stackSize = 0;
     public List<Block> blockStack;
     public Block GhostBlock;
     public float placementThreshold = 3f;
     public float movementSpeed = 2f;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        blockStack = new List<Block>();
    }


/// <summary>
/// Creates a new block and sets it as the target block
/// </summary>
    public void CreateBlock()
    {
        {
            if (GhostBlock != null)
            {
                return;
            }
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.position = blockSpawnPoint.position;
            block.transform.parent = gameObject.transform.parent;
            InputManager.targetBlock = block.GetComponent<Block>();
            GhostBlock = block.GetComponent<Block>();
            GhostBlock.holdTime = placementThreshold;
          
        }
    }

    /// <summary>
    /// Sets where the next block will spawn
    /// </summary>
    public void SetSpawnLevel()
    {
        if (blockStack.Count == 0)
        {
            return;
        }
        blockSpawnPoint.position = new Vector3(transform.position.x,blockStack[0].BlockHeight() + SPAWN_OFFSET,transform.position.z);
    }

public float GetHighestBlock()
{
    Debug.Log("Highest Block: " + blockStack[0].BlockHeight());
    return blockStack[0].BlockHeight();
}
/// <summary>
/// Adds a block to the stack
/// </summary>
/// <param name="block">The Block instance</param>
    public void AddToStack(Block block)
    {
        stackSize++;
        blockStack.Insert(0, block);
        Camera.main.GetComponent<CameraController>().topCube = block.transform;

    }
    /// <summary>
    /// Removes a block from the stack
    /// </summary>
    /// <param name="block">The Block instance</param>
    public void RemoveFromStack(Block block)
    {
        if (blockStack.Count != 0 && blockStack.Contains(block))
        {
            blockStack.Remove(block);
            stackSize--;
            if (blockStack.Count != 0)
            {
                Camera.main.GetComponent<CameraController>().topCube = blockStack[0].transform;
            }
            else
            {
                Camera.main.GetComponent<CameraController>().topCube = null;
            }

        }

    }

    /// <summary>
    /// Gets the current stack size
    /// </summary>
    /// <returns>the current size of the block stack </returns>

    public int GetStackSize()
    {
        return stackSize;
    }
}
