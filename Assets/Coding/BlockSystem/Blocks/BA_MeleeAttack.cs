using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BA_AttackMelee : AttackBase
{
    public float range = 1f;  // 공격 범위
    private void Awake()
    {
        damage = 15f;       // 블록별 데미지
        knockback = 4f;     // 블록별 넉백
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        // 타겟과의 거리 체크
        Vector2 attackPos = runner.transform.position + Vector3.right * Mathf.Sign(runner.transform.localScale.x);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPos, range);

        foreach (var hit in hits)
        {
            if (hit.gameObject != runner.gameObject && (hit.CompareTag("P1") || hit.CompareTag("P2")))
            {
                DealDamage(hit.gameObject, runner.gameObject);
                Debug.Log($"[BA_MeleeAttack] {hit.name} {damage} 데미지로 근접공격");
            }
        }

        yield return null;
    }
}
