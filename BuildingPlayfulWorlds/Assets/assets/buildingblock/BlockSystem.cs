using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour {

    [SerializeField]
    private BlockType[] allBlockTypes;

    [HideInInspector]
    //int is key, Block is value
    public Dictionary<int, Block> allBlocks = new Dictionary<int, Block>();     //can call upon, use id

    private void Awake()
    {
        for (int i = 0; i < allBlockTypes.Length; i++)  //loop runs for adding blocks
        {
            BlockType newBlockType = allBlockTypes[i];
            Block newBlock = new Block(i, newBlockType.blockName, newBlockType.blockMat);  //public class Block used, giving block id, name and material
            allBlocks[i] = newBlock;    //assign new block to dictionary
            Debug.Log("Block added to dictionary" + allBlocks[i].blockName);
        }
    }
}

public class Block
{
    public int blockID;
    public string blockName;
    public Material blockMaterial;

    public Block (int id, string name, Material mat)
    {
        blockID = id;
        blockName = name;
        blockMaterial = mat;
    }
}

[Serializable]
public struct BlockType
{
    public string blockName;
    public Material blockMat;
}
