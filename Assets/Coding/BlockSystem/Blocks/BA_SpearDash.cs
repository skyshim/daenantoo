using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class BA_SpearDash : AttackBase
{
    public float range = 1f;  // 공격 범위
    public float force = 12f;
    private void Awake()
    {
        damage = 10f;       // 블록별 데미지
        knockback = 8f;     // 블록별 넉백
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D가 없습니다: " + target.name);
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
                Debug.Log($"[BA_SpearDash] {hit.name} {damage} 데미지로 근접공격");
            }
        }

        yield return null;
    }
}
