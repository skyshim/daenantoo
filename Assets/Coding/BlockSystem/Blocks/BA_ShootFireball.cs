using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_ShootFireball : AttackBase
{
    public GameObject fireballPrefab;  // ȭ���� ������
    public float speed = 8f;            // ȭ���� �̵� �ӵ�
    public float lifeTime = 3f;         // ȭ���� ������� �ð�

    private void Awake()
    {
        damage = 20f;     // ��Ϻ� ������
        knockback = 3f;   // ��Ϻ� �˹�
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        if (fireballPrefab == null)
        {
            Debug.LogWarning("Fireball prefab not assigned!");
            yield break;
        }

        // �÷��̾� ���� Ȯ��
        float dir = Mathf.Sign(runner.gameObject.transform.localScale.x);

        // ȭ���� ����
        GameObject fireball = Instantiate(fireballPrefab, runner.transform.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(dir * speed, 0);

        }

        // �浹 ó���� ��ũ��Ʈ�� ������ ����
        FireballProjectile proj = fireball.GetComponent<FireballProjectile>();
        if (proj != null)
        {
            proj.damage = damage;
            proj.knockback = knockback;
            proj.owner = runner.gameObject;
        }

        Destroy(fireball, lifeTime); // ���� �ð� �� ����
        yield return null;
    }
}
