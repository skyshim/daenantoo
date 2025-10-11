using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float damage;
    public float knockback;
    public GameObject owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner) return; // 자기 자신은 무시

        PlayerControl pc = collision.GetComponent<PlayerControl>();
        if (pc != null)
        {
            pc.TakeDamage(damage);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float dir = Mathf.Sign(owner.transform.localScale.x);
                rb.AddForce(new Vector2(dir * knockback, knockback * 0.3f), ForceMode2D.Impulse);
            }
        }

        Destroy(gameObject); // 충돌하면 화염구 삭제
    }
}