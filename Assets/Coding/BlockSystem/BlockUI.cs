using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour, IPointerClickHandler
{
    public bool isPaletteBlock = true; // true: �г� ��ư, false: ������ ���
    private Block blockPrefab;
    private SkillEditor skillEditor;  // ���� Inspector���� �� �־ ��
    private void Awake()
    {
        skillEditor = FindObjectOfType<SkillEditor>();
        blockPrefab = this.GetComponent<Block>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPaletteBlock)
        {
            Block newBlock = skillEditor.AddBlock(blockPrefab);

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
