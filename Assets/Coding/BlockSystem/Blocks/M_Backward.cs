using System.Collections;
using UnityEngine;

public class M_Backward : Block
{
    public float force = 9f;       // 앞으로 밀어주는 힘

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
        Vector2 impulse = new Vector2(dir * force * -1, 1f);

        rb.AddForce(impulse, ForceMode2D.Impulse);
        Debug.Log($"[M_Forward] {target.name} 뒤로 {force}만큼 이동");

    }
}
