using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider2D attackCollider;
    public Vector2 knockback = Vector2.zero;
    public int attackDmg = 10;

    void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable != null) {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            bool gotHit = damageable.Hit(attackDmg, deliveredKnockback);

            if(gotHit) {
                Debug.Log(collision.name + " hit for " + attackDmg);
            }
           
        }    
    }
}
