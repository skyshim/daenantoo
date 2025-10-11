using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public BlockRunner blockRunner1;
    public BlockRunner blockRunner2;
    public SkillUI skillUI1;
    public SkillUI skillUI2;
    public Image healthBar;

    private Rigidbody2D rb;
    private float cool1;
    private float cool2;

    public bool isUsingSkill = false;
    private bool canUse1Skill = true;
    private bool canUse2Skill = true;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cool1 = 0; cool2 = 0;

        if (gameObject.tag == "P1")
        {
            blockRunner1.blocks = SkillTransfer.Instance.player1Skill1;
            blockRunner2.blocks = SkillTransfer.Instance.player1Skill2;
        }
        else if (gameObject.tag == "P2")
        {
            blockRunner1.blocks = SkillTransfer.Instance.player2Skill1;
            blockRunner2.blocks = SkillTransfer.Instance.player2Skill2;
        }
    }

    void Update()
    {
        float move = 0f;


        if (gameObject.tag == "P1")
        {

            if (Input.GetKey(KeyCode.A)) move = -1f;
            if (Input.GetKey(KeyCode.D)) move = 1f;

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 9f);
                isGrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && canUse1Skill)
            {
                canUse1Skill = false;
                cool1 = 5;
                skillUI1.StartCooldown(cool1);
                blockRunner1.StartRun();
                StartCoroutine(ResetSkill1Cooldown());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && canUse2Skill)
            {
                canUse2Skill = false;
                cool2 = 15;
                skillUI2.StartCooldown(cool2);
                blockRunner2.StartRun();
                StartCoroutine(ResetSkill2Cooldown());
            }
        }
        else if (gameObject.tag == "P2")
        {
            if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) move = 1f;

            // ↑로 점프
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 9f);
                isGrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.Delete) && canUse1Skill)
            {
                canUse1Skill = false;
                cool1 = 5;
                skillUI1.StartCooldown(cool1);
                blockRunner1.StartRun();
                StartCoroutine(ResetSkill1Cooldown());
            }

            if (Input.GetKeyDown(KeyCode.End) && canUse2Skill)
            {
                canUse2Skill = false;
                cool2 = 15;
                skillUI2.StartCooldown(cool2);
                blockRunner2.StartRun();
                StartCoroutine(ResetSkill2Cooldown());
            }
        }

        if (!isUsingSkill && move != 0)
        {
            rb.velocity = new Vector2(move * 5f, rb.velocity.y);

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(move); // move가 양수면 오른쪽, 음수면 왼쪽
            transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private IEnumerator ResetSkill1Cooldown()
    {
        yield return new WaitForSeconds(cool1);
        canUse1Skill = true;
    }

    private IEnumerator ResetSkill2Cooldown()
    {
        yield return new WaitForSeconds(cool2);
        canUse2Skill = true;
    }

    //=================================================


    public float Health = 100f;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthBar.fillAmount = Health / 100;
    }
}