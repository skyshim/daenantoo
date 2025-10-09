using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public abstract IEnumerator Execute(GameObject gameObject, BlockRunner runner);
}

public class ControlBlock : Block
{
    public List<Block> childBlocks = new List<Block>();
    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        // 간단히 childBlocks 순서대로 실행
        foreach (var child in childBlocks)
        {
            yield return runner.StartCoroutine(child.Execute(target, runner));
        }
    }
}

public class ActionBlock : Block
{
    public override IEnumerator Execute(GameObject target, BlockRunner runner) { yield break; }
}
