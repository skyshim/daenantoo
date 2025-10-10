using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockData
{
    public string blockType;               // MoveForward, Jump 등
    public List<BlockData> childBlocks;    // ControlBlock 안쪽 블록
}