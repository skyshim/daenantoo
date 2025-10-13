using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class BA_SpearDash : AttackBase
{
    public float range = 1f;  // ���� ����
    public float force = 12f;
    private void Awake()
    {
        damage = 10f;       // ��Ϻ� ������
        knockback = 8f;     // ��Ϻ� �˹�
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D�� �����ϴ�: " + target.name);
            yield break;
        }


        rb.velocity = new Vector2(0, rb.velocity.y);
        float dir = Mathf.Sign(target.transform.localScale.x);
        Vector2 impulse = new Vector2(dir * force, 0.5f);

        rb.AddForce(impulse, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.15f);
        Vector2 attackPos = runner.transform.position;
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPos, range);

        foreach (var hit in hits)
        {
            if (hit.gameObject != runner.gameObject && (hit.CompareTag("P1") || hit.CompareTag("P2")))
            {
                DealDamage(hit.gameObject, runner.gameObject);
                Debug.Log($"[BA_SpearDash] {hit.name} {damage} �������� ��������");
            }
        }

        yield return null;
    }
}
