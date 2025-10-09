using System.Collections;
using UnityEngine;

public class M_Jump : Block
{
    public float force = 5f;       // ������ �о��ִ� ��

    public override IEnumerator Execute(GameObject target, BlockRunner runner)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D�� �����ϴ�: " + target.name);
            yield break;
        }


        rb.velocity = new Vector2(rb.velocity.x, 0);
        Vector2 impulse = new Vector2(0, force);

        rb.AddForce(impulse, ForceMode2D.Impulse);
        Debug.Log($"[M_Forward] {target.name} ���� {force}��ŭ �̵�");

    }
}
