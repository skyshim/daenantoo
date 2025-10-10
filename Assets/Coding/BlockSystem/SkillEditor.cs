using System.Collections.Generic;
using UnityEngine;

public class SkillEditor : MonoBehaviour
{
    public Transform blockParent;
    public static SkillEditor Instance;
    public List<Block> blocks = new List<Block>();

    private void Awake()
    {   
        Instance = this;
    }

    public Block AddBlock(Block blockPrefab)
    {
        Block newBlock = Instantiate(blockPrefab, blockParent);
        blocks.Add(newBlock);
        return newBlock;

    }

    public void RemoveBlock(Block block)
    {
        blocks.Remove(block);
        Destroy(block.gameObject);
    }

    public void ClearAll()
    {
        foreach (var b in blocks)
        {
            if (b.transform.parent == blockParent)  // editor 소속이면 삭제
                Destroy(b.gameObject);
        }
        blocks.Clear();
    }
}
