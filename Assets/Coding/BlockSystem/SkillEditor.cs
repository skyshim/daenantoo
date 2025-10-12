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
            Debug.LogWarning("ControlBlock�� �������� �ʾҽ��ϴ�.");
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
                    if (child.name.Contains("SampleBlock")) Destroy(child); // �̸��� SampleBlock�̸�
                }
            }
        }

        // ControlBlock �ȿ� ��� ����
        Block newBlock = Instantiate(blockPrefab, targetControl.container);
        targetControl.AddChild(newBlock); // childBlocks ����Ʈ�� ���
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
            if (b.transform.parent == blockParent && !(b.CompareTag("controlBlock")))  // editor �Ҽ��̸� ����
                Destroy(b.gameObject);
        }
        blocks.Clear();
    }
}
