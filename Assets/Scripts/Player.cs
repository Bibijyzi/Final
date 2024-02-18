using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int health;

    private Rigidbody2D rb;
    [SerializeField] public Collider2D collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
