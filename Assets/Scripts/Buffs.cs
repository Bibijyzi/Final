using System.Collections;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [SerializeField] private int healthRegen;
    [SerializeField] private bool invize;
    [SerializeField] private int timeInvize;
    [SerializeField] private AudioClip buffsSFX, noTimeSFX;
    [SerializeField] private AudioSource source;

    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            player.health += healthRegen;
            Destroy(collision.gameObject);
            source.PlayOneShot(buffsSFX);
        }

        if (collision.gameObject.CompareTag("Invize"))
        {
            StartCoroutine(InvizeTiemr());
            invize = true;
            player.collider.isTrigger = true;
            Destroy(collision.gameObject);
            source.PlayOneShot(buffsSFX);
        }
    }

    IEnumerator InvizeTiemr()
    {
        yield return new WaitForSeconds(timeInvize);
        invize = false;
        player.collider.isTrigger = false;
        source.PlayOneShot(noTimeSFX);
    }
}
