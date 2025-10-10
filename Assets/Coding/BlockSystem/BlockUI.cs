using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour, IPointerClickHandler
{
    public bool isPaletteBlock = true; // true: 패널 버튼, false: 에디터 블록
    private Block blockPrefab;
    private SkillEditor skillEditor;  // 이제 Inspector에서 안 넣어도 됨
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
    }
}
