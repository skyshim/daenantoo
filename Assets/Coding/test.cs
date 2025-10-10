using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public BlockRunner runner;
    public SkillEditor skillEditor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            runner.blocks = new List<Block>(skillEditor.blocks);
            runner.StartRun();
        }
    }
}
