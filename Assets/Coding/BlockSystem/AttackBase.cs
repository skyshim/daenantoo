using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : Block
{
    public float damage = 10f; 
    public float knockback = 5f;
    //기본값이라 개별블록에서 수정될 예정

    protected void DealDamage(GameObject target, GameObject attacker)
    {
        PlayerControl pc = target.GetComponent<PlayerControl>();
        if (pc != null) pc.TakeDamage(damage);

        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float dir = Mathf.Sign(attacker.transform.localScale.x);
            rb.AddForce(new Vector2(dir * knockback, knockback * 0.3f), ForceMode2D.Impulse);
        }
    }
}
