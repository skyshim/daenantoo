using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockRunner : MonoBehaviour
{
    public List<Block> blocks = new List<Block>();
    public GameObject target;
    public float actionDelay = 0.4f;

    public SkillEditor skillEditor;

    public void StartRun()
    {
        StartCoroutine(RunBlocks());
    }

    private IEnumerator RunBlocks()
    {
        if (skillEditor.blocks.Count == 0)
        {
            Debug.LogWarning("블록이 없습니다!");
            yield break;
        }

        foreach (var block in skillEditor.blocks)
        {
            yield return StartCoroutine(block.Execute(target, this));
            yield return new WaitForSeconds(actionDelay); // 블록 사이 딜레이
        }

        Debug.Log("모든 블록 실행 완료");
    }
}
