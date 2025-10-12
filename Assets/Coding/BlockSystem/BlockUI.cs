using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockUI : MonoBehaviour, IPointerClickHandler
{
    public bool isPaletteBlock = true; // true: 패널 버튼, false: 에디터 블록
    private Block blockPrefab;
    private SkillEditor skillEditor;  // 이제 Inspector에서 안 넣어도 됨

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

            // 생성된 블록을 Editor용으로 바꾸기
            BlockUI newBlockUI = newBlock.gameObject.GetComponent<BlockUI>();
            newBlockUI.isPaletteBlock = false;    // 에디터 블록
            newBlockUI.skillEditor = skillEditor;
        }
        else
        {
            // 삭제
            skillEditor.RemoveBlock(GetComponent<Block>());
        }

        ReloadControlCanvas();

    }
    private void ReloadControlCanvas()
    {
        HorizontalLayoutGroup hlg = BlockUI.currentControlBlock.transform.Find("ContentArea").GetComponent<HorizontalLayoutGroup>();

        for (int i = 0; i < 2; i++) //왠지는 모르겠는데 2번 리로드해야 됨 ㅇㅇ..
        {
            hlg.childControlHeight = false;
            LayoutRebuilder.ForceRebuildLayoutImmediate(hlg.GetComponent<RectTransform>());
            // 1프레임 뒤에 다시 true로
            BlockUI.currentControlBlock.StartCoroutine(EnableChildControlHeightNextFrame(hlg));

            hlg.childControlHeight = false;
            LayoutRebuilder.ForceRebuildLayoutImmediate(hlg.GetComponent<RectTransform>());
            // 1프레임 뒤에 다시 true로
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
