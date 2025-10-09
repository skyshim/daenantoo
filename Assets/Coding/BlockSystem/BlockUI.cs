using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockUI : MonoBehaviour
{
    public Transform editorParent; // StartBlock �� Transform
    public SkillEditor skillEditor; // ����Ʈ ����

    public void OnPointerClick(PointerEventData eventData)
    {
        // �����Ϳ� ��� ����
        GameObject newBlockGO = Instantiate(gameObject, editorParent);
        EditorBlock editorBlock = newBlockGO.AddComponent<EditorBlock>();
        editorBlock.skillEditor = skillEditor;

        // BlockRunner ����� ����Ʈ�� �߰�
        Block blockComponent = newBlockGO.GetComponent<Block>();
        skillEditor.AddBlock(blockComponent);
    }
}
