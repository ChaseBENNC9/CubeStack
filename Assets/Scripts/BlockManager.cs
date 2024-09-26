using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform blockSpawnPoint; 
    private const float SPAWN_OFFSET = 2f;
    public static BlockManager instance;
    private int stackSize = 0;
    [SerializeField] private List<Block> blockStack;

    public bool canCreate = true;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        blockStack = new List<Block>();
        CreateBlock();
    }



    public void CreateBlock()
    {
        if (canCreate)
        {
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.position = blockSpawnPoint.position;
            block.transform.parent = gameObject.transform.parent;
            canCreate = false;
        }
    }
    public void SetSpawnLevel()
    {
        if (blockStack.Count == 0)
        {
            return;
        }
        blockSpawnPoint.position = new Vector3(transform.position.x,blockStack[blockStack.Count - 1].BlockHeight() + SPAWN_OFFSET,transform.position.z);
    }

    public void AddToStack(Block block)
    {
        stackSize++;
        blockStack.Add(block);

    }
    public void RemoveFromStack(Block block)
    {
        if (blockStack.Count != 0 && blockStack.Contains(block))
        {
            blockStack.Remove(block);
            stackSize--;
        }

    }

    public int GetStackSize()
    {
        return stackSize;
    }
}
