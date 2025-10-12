using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

        ReloadControlCanvas();

    }
    private void ReloadControlCanvas()
    {
        HorizontalLayoutGroup hlg = BlockUI.currentControlBlock.transform.Find("ContentArea").GetComponent<HorizontalLayoutGroup>();

        for (int i = 0; i < 2; i++) //������ �𸣰ڴµ� 2�� ���ε��ؾ� �� ����..
        {
            hlg.childControlHeight = false;
            LayoutRebuilder.ForceRebuildLayoutImmediate(hlg.GetComponent<RectTransform>());
            // 1������ �ڿ� �ٽ� true��
            BlockUI.currentControlBlock.StartCoroutine(EnableChildControlHeightNextFrame(hlg));

            hlg.childControlHeight = false;
            LayoutRebuilder.ForceRebuildLayoutImmediate(hlg.GetComponent<RectTransform>());
            // 1������ �ڿ� �ٽ� true��
            BlockUI.currentControlBlock.StartCoroutine(EnableChildControlHeightNextFrame(hlg));
        }
    }
    private IEnumerator EnableChildControlHeightNextFrame(HorizontalLayoutGroup hlg)
    {
        yield return null;
        hlg.childControlHeight = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(hlg.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }
}
