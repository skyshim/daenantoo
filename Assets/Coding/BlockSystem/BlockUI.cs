using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour
{
    public Transform editorParent; // StartBlock 밑 Transform
    public SkillEditor skillEditor; // 리스트 관리

    public void OnPointerClick(PointerEventData eventData)
    {
        // 에디터에 블록 생성
        GameObject newBlockGO = Instantiate(gameObject, editorParent);
        EditorBlock editorBlock = newBlockGO.AddComponent<EditorBlock>();
        editorBlock.skillEditor = skillEditor;

        // BlockRunner 실행용 리스트에 추가
        Block blockComponent = newBlockGO.GetComponent<Block>();
        skillEditor.AddBlock(blockComponent);
    }
}
