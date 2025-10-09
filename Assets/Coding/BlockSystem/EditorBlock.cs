using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class EditorBlock : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public SkillEditor skillEditor;

    public void OnPointerClick(PointerEventData eventData)
    {
        // ����Ʈ���� ����
        Block blockComponent = GetComponent<Block>();
        skillEditor.RemoveBlock(blockComponent);

        // �ð��� ����
        Destroy(gameObject);
    }
}