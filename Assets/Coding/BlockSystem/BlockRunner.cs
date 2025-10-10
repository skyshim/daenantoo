using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockRunner : MonoBehaviour
{
    public GameObject target;
    public float actionDelay = 0.4f;

    public List<Block> blocks = new List<Block>();

    public void StartRun()
    {
        StartCoroutine(RunBlocks());
    }

    private IEnumerator RunBlocks()
    {

        foreach (var block in blocks)
        {
            yield return StartCoroutine(block.Execute(target, this));
            yield return new WaitForSeconds(actionDelay); // 블록 사이 딜레이
        }

        Debug.Log("모든 블록 실행 완료");
    }
}
