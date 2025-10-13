using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_IfAir: ControlBlock
{
    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        PlayerControl pc = target.GetComponent<PlayerControl>();
        if (!pc.IsGrounded())
        {
            foreach (var child in childBlocks)
            {
                yield return runner.StartCoroutine(child.Execute(target, runner));
                yield return new WaitForSeconds(runner.actionDelay);
            }
        }
    }
}
