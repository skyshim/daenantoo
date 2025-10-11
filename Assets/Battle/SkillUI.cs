using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Image CoolFill;
    public TMP_Text CoolText;

    public float cool_org = 0;
    private float cool_cur = 0;

    void Update()
    {
        CoolFill.fillAmount = cool_cur / cool_org;
        if (cool_cur > 0)
        {
            cool_cur -= Time.deltaTime;
            CoolText.text = Mathf.CeilToInt(cool_cur).ToString();
        }
        else if (cool_cur <= 0)
        {
            cool_cur = 0;
            CoolText.text = "";
        }
    }

    public void StartCooldown(float cool)
    {
        cool_cur = cool;
    }
}
