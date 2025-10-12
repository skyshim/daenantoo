using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public abstract class Block : MonoBehaviour
{
    public abstract IEnumerator Execute(GameObject gameObject, BlockRunner runner);
}

public class ControlBlock : Block
{
    public List<Block> childBlocks = new List<Block>();
    public Transform container;
    public void AddChild(Block b)
    {
        childBlocks.Add(b);
        container = BlockUI.currentControlBlock.transform.Find("ContentArea/BlockContainer");
        b.transform.SetParent(container, false);

    }
    

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
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
