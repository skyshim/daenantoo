using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BA_AttackMelee : AttackBase
{
    public float range = 1f;  // ���� ����
    private void Awake()
    {
        damage = 15f;       // ��Ϻ� ������
        knockback = 4f;     // ��Ϻ� �˹�
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        // Ÿ�ٰ��� �Ÿ� üũ
        Vector2 attackPos = runner.transform.position + Vector3.right * Mathf.Sign(runner.transform.localScale.x);
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPos, range);

        foreach (var hit in hits)
        {
            if (hit.gameObject != runner.gameObject && (hit.CompareTag("P1") || hit.CompareTag("P2")))
            {
                DealDamage(hit.gameObject, runner.gameObject);
                Debug.Log($"[BA_MeleeAttack] {hit.name} {damage} �������� ��������");
            }
        }

        yield return null;
    }
}
