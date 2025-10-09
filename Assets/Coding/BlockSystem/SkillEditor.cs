using System.Collections.Generic;
using UnityEngine;

public class SkillEditor : MonoBehaviour
{
    public static SkillEditor Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Block> blocks = new List<Block>();

    public void AddBlock(Block block)
    {
        blocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        blocks.Remove(block);
    }
}
