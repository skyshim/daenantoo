using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_ShootFireball : AttackBase
{
    public GameObject fireballPrefab;  // 화염구 프리팹
    public float speed = 8f;            // 화염구 이동 속도
    public float lifeTime = 3f;         // 화염구 사라지는 시간

    private void Awake()
    {
        damage = 20f;     // 블록별 데미지
        knockback = 3f;   // 블록별 넉백
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        if (fireballPrefab == null)
        {
            Debug.LogWarning("Fireball prefab not assigned!");
            yield break;
        }

        // 플레이어 방향 확인
        float dir = Mathf.Sign(runner.gameObject.transform.localScale.x);

        // 화염구 생성
        GameObject fireball = Instantiate(fireballPrefab, runner.transform.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(dir * speed, 0);

        }

        // 충돌 처리용 스크립트에 데미지 전달
        FireballProjectile proj = fireball.GetComponent<FireballProjectile>();
        if (proj != null)
        {
            proj.damage = damage;
            proj.knockback = knockback;
            proj.owner = runner.gameObject;
        }

        Destroy(fireball, lifeTime); // 일정 시간 후 삭제
        yield return null;
    }
}
