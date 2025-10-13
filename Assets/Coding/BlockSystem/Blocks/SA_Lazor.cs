using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Lazor : AttackBase
{
    public float range = 5f;      // 레이저 길이
    public float duration = 0.3f; // 레이저 유지 시간
    public LineRenderer linePrefab;

    private void Awake()
    {
        damage = 40f;
        knockback = 0f;
    }

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        yield return new WaitForSeconds(1f); // 1초 딜레이 후 발사

        Vector3 startPos = runner.transform.position;
        Vector3 dir = Vector3.right * Mathf.Sign(runner.transform.localScale.x);
        Vector3 endPos = startPos + dir * range;

        // 레이저 오브젝트 생성
        LineRenderer lr = Instantiate(linePrefab);
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);

        // 시각 효과용 (색깔, 두께 등)
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.startColor = Color.red;
        lr.endColor = Color.yellow;

        // 충돌 판정
        RaycastHit2D[] hits = Physics2D.LinecastAll(startPos, endPos);
        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject != runner.gameObject &&
                (hit.collider.CompareTag("P1") || hit.collider.CompareTag("P2")))
            {
                DealDamage(hit.collider.gameObject, runner.gameObject);
                Debug.Log($"[SA_Lazor] {hit.collider.name}에게 {damage} 데미지!");
            }
        }

        // 레이저 잠깐 유지
        yield return new WaitForSeconds(duration);
        Destroy(lr.gameObject);
    }
}
