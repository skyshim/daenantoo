using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlBlockSelect : MonoBehaviour, IPointerClickHandler
{
    public Block blockPrefab;       // �� ����� ��Ÿ���� ������
    public GameManager gameManager; // GameManager ����

    public void OnPointerClick(PointerEventData eventData)
    {
        // Ŭ�� �� GameManager�� ���� �̺�Ʈ ����
        gameManager.OnControlBlockSelected(blockPrefab);
    }
}
