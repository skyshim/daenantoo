using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text timerText;
    public SkillEditor skillEditor;

    private float currentTime;
    private int currentSkill = 1; // 1: ��ų1, 2: ��ų2
    private int currentPlayer = 1; 

    private void Start()
    {
        StartCoroutine(SkillCountdown());
    }

    private IEnumerator SkillCountdown()
    {
        currentTime = 3f;
        while (currentTime > 0)
        {
            timerText.text = $"{Mathf.Ceil(currentTime)}";
            currentTime -= Time.deltaTime;
            yield return null;
        }

        timerText.text = "0";
        SaveCurrentSkill();

        // ���� ��ų / ���� �÷��̾�
        if (currentSkill == 1)
        {
            currentSkill = 2;
            skillEditor.ClearAll();
            StartCoroutine(SkillCountdown());
        }
        else
        {
            if (currentPlayer == 1)
            {
                // �÷��̾�2 ����
                currentPlayer = 2;
                currentSkill = 1;
                skillEditor.ClearAll();
                StartCoroutine(SkillCountdown());
            }
            else
            {
                // ��� �÷��̾� ��ų �Ϸ� �� ��Ʋ��
                SceneManager.LoadScene("Battle");
            }
        }
    }

    private void SaveCurrentSkill()
    {
        List<Block> skillData = new List<Block>(skillEditor.blocks);

        foreach (var block in skillData)
        {
            block.transform.SetParent(null);   // ��Ʈ�� �ű�
            DontDestroyOnLoad(block.gameObject);
        }

        if (currentPlayer == 1)
        {
            if (currentSkill == 1)
                SkillTransfer.Instance.player1Skill1 = skillData;
            else
                SkillTransfer.Instance.player1Skill2 = skillData;
        }
        else
        {
            if (currentSkill == 1)
                SkillTransfer.Instance.player2Skill1 = skillData;
            else
                SkillTransfer.Instance.player2Skill2 = skillData;
        }
    }
}
