using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform blockSpawnPoint; 
    public static BlockManager instance;
    private int stackSize = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
    }



    public void CreateBlock()
    {
        GameObject block = Instantiate(blockPrefab, transform);
        block.transform.position = blockSpawnPoint.position;
        block.transform.parent = gameObject.transform.parent;
    }

    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }

    public int GetStackSize()
    {
        return stackSize;
    }
}
