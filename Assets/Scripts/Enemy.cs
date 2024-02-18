using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private AudioSource source;
    [SerializeField] private ParticleSystem hitVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            source.PlayOneShot(damageSFX);
            Instantiate(hitVFX, transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }
}
