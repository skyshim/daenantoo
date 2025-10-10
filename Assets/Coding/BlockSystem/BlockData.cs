using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockData
{
    public string blockType;               // MoveForward, Jump ��
    public List<BlockData> childBlocks;    // ControlBlock ���� ���
}