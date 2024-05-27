using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool hasDealtDamage = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasDealtDamage) return;

        if (collision.CompareTag("Damageable"))
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                hasDealtDamage = true;
                Destroy(gameObject);
            }
        }
    }
}
