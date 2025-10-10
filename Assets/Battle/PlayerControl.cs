using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public BlockRunner blockRunner1;
    public BlockRunner blockRunner2;
    public SkillUI skillUI1;
    public SkillUI skillUI2;

    private Rigidbody2D rb;
    private float cool1;
    private float cool2;

    private bool isGrounded = true;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        float move = 0;


        if (gameObject.tag == "P1")
        {
            if (Input.GetKey(KeyCode.A)) move = -1f;
            if (Input.GetKey(KeyCode.D)) move = 1f;

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.AddForce(Vector2.up * 11f, ForceMode2D.Impulse);
                isGrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && cool1 <= 0)
            {
                cool1 = 5;
                skillUI1.StartCooldown(cool1);
                blockRunner1.StartRun();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && cool2 <= 0)
            {
                cool2 = 15;
                skillUI2.StartCooldown(cool2);
                blockRunner2.StartRun();
            }
        }
        else if (gameObject.tag == "P2")
        {
            if (Input.GetKey(KeyCode.LeftArrow)) move = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) move = 1f;

            // ¡è·Î Á¡ÇÁ
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.AddForce(Vector2.up * 11f, ForceMode2D.Impulse);
                isGrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                cool1 = 5;
                skillUI1.StartCooldown(cool1);
                blockRunner1.StartRun();
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                cool2 = 15;
                skillUI2.StartCooldown(cool2);
                blockRunner2.StartRun();
            }
        }

        rb.velocity = new Vector2(move * 5f, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
