using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlBlockSelect : MonoBehaviour, IPointerClickHandler
{
    public Block blockPrefab;       // 이 블록이 나타내는 제어블록
    public GameManager gameManager; // GameManager 참조

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭 시 GameManager에 선택 이벤트 전달
        gameManager.OnControlBlockSelected(blockPrefab);
    }
}
