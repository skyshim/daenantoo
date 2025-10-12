using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour, IPointerClickHandler
{
    public bool isPaletteBlock = true; // true: �г� ��ư, false: ������ ���
    private Block blockPrefab;
    private SkillEditor skillEditor;  // ���� Inspector���� �� �־ ��

    public static ControlBlock currentControlBlock = null;

    private void Awake()
    {
        skillEditor = FindObjectOfType<SkillEditor>();
        blockPrefab = GetComponent<Block>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPaletteBlock)
        {
            Block newBlock;
            if (currentControlBlock != null)
            {
                newBlock = skillEditor.AddBlockToControl(blockPrefab, currentControlBlock);
            }
            else
            {
                newBlock = skillEditor.AddBlock(blockPrefab);
            }

            // ������ ����� Editor������ �ٲٱ�
            BlockUI newBlockUI = newBlock.gameObject.GetComponent<BlockUI>();
            newBlockUI.isPaletteBlock = false;    // ������ ���
            newBlockUI.skillEditor = skillEditor;
        }
        else
        {
            // ����
            skillEditor.RemoveBlock(GetComponent<Block>());
        }
    }
}
