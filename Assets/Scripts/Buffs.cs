using UnityEngine;

public class Buffs : MonoBehaviour
{
    [SerializeField] private int healthRegen;
    [SerializeField] public bool invize;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = GetComponent<Player>();
        if (collision.gameObject.CompareTag("Health"))
        {
            player.health += healthRegen;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Invize"))
        {
            invize = true;
            player.collider.isTrigger = true;
        }
    }
}
