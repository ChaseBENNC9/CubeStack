using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform blockSpawnPoint; 
    private const float SPAWN_OFFSET = 2f;
    public static BlockManager instance;
    private int stackSize = 0;
     private List<Block> blockStack;
    [HideInInspector] public GameObject ghostBlock;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        blockStack = new List<Block>();
        CreateBlock();
    }


/// <summary>
/// Creates a new block and sets it as the ghost block
/// </summary>
    public void CreateBlock()
    {
        {
            if (ghostBlock != null)
            {
                Destroy(ghostBlock);
                Debug.Log("Destroying Ghost Block");
            }
            
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.position = blockSpawnPoint.position;
            block.transform.parent = gameObject.transform.parent;
            ghostBlock = block;
          
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
        blockSpawnPoint.position = new Vector3(transform.position.x,blockStack[blockStack.Count - 1].BlockHeight() + SPAWN_OFFSET,transform.position.z);
    }


/// <summary>
/// Adds a block to the stack
/// </summary>
/// <param name="block">The Block instance</param>
    public void AddToStack(Block block)
    {
        stackSize++;
        blockStack.Add(block);
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
