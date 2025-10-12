using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_IfAir1: ControlBlock
{
    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (var child in childBlocks)
            {
                yield return runner.StartCoroutine(child.Execute(target, runner));
            }
        }
    }
}
