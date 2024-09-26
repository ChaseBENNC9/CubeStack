using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform blockSpawnPoint; 
    private const float SPAWN_OFFSET = 1.5f;
    public static BlockManager instance;
    private int stackSize = 0;
    [SerializeField] private Stack<Block> blockStack;

    public bool canCreate = true;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        blockStack = new Stack<Block>();
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
        if (blockStack.IsEmpty())
        {
            return;
        }
        blockSpawnPoint.position = new Vector3(transform.position.x,blockStack.Peek().BlockHeight() + SPAWN_OFFSET,transform.position.z);
    }

    public void AddToStack(Block block)
    {
        stackSize++;
        blockStack.Push(block);
    }
    public void RemoveFromStack(Block block)
    {
        if (!blockStack.IsEmpty() && blockStack.Peek() == block)
        {
            blockStack.Pop();
            stackSize--;
            
        }
        Destroy(block.gameObject, 0.1f);        
    }

    public int GetStackSize()
    {
        return stackSize;
    }
}
