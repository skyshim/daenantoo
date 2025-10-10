using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTransfer : MonoBehaviour
{
    public static SkillTransfer Instance;
    public List<Block> player1Skill1 = new List<Block>();
    public List<Block> player1Skill2 = new List<Block>();
    public List<Block> player2Skill1 = new List<Block>();
    public List<Block> player2Skill2 = new List<Block>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
