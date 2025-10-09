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
        // 리스트에서 제거
        Block blockComponent = GetComponent<Block>();
        skillEditor.RemoveBlock(blockComponent);

        // 시각적 제거
        Destroy(gameObject);
    }
}