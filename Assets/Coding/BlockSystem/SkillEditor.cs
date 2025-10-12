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

    public Block AddBlockToControl(Block blockPrefab, ControlBlock targetControl)
    {
        if (targetControl == null)
        {
            Debug.LogWarning("ControlBlock이 지정되지 않았습니다.");
            return null;
        }

        if (targetControl.transform.Find("ContentArea/BlockContainer").childCount == 1)
        {
            Transform blockContainer = targetControl.transform.Find("ContentArea/BlockContainer");
            if (blockContainer != null)
            {
                for (int i = blockContainer.childCount - 1; i >= 0; i--)
                {
                    GameObject child = blockContainer.GetChild(i).gameObject;
                    if (child.name.Contains("SampleBlock")) Destroy(child); // 이름이 SampleBlock이면
                }
            }
        }

        // ControlBlock 안에 블록 생성
        Block newBlock = Instantiate(blockPrefab, targetControl.container);
        targetControl.AddChild(newBlock); // childBlocks 리스트에 등록
        return newBlock;
    }


    public void RemoveBlock(Block block)
    {
        if (!(block.gameObject.CompareTag("controlBlock")))
        {
            blocks.Remove(block);
            Destroy(block.gameObject);
        }
    }

    public void ClearAll()
    {
        foreach (var b in blocks)
        {
            if (b.transform.parent == blockParent && !(b.CompareTag("controlBlock")))  // editor 소속이면 삭제
                Destroy(b.gameObject);
        }
        blocks.Clear();
    }
}
