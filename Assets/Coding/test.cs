using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public BlockRunner runner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            runner.StartRun();
        }
    }
}
