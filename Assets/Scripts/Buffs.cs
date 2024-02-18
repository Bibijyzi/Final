using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{
    [SerializeField] private int healthRegen;
    [SerializeField] private bool invize;
    [SerializeField] private bool health;
    [SerializeField] private int timeInvize, timeHealth;
    [SerializeField] private AudioClip buffsSFX, noTimeSFX;
    [SerializeField] private AudioSource source;
    [SerializeField] private Image invizeIcon, healthIcon;
    [SerializeField] private ParticleSystem destroyHealthVFX, destroyInvizeVFX;

    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (invize)
        {
            invizeIcon.fillAmount -= 1 / timeInvize * Time.deltaTime;
            if(invizeIcon.fillAmount <= 0)
            {
                invizeIcon.fillAmount = 1;
                //invizeIcon.color = new Color(0, 0, 0, 0);
                invizeIcon.gameObject.SetActive(false);
            }
        }
        if (health)
        {
            healthIcon.fillAmount -= 1 / timeHealth * Time.deltaTime;
            if (healthIcon.fillAmount <= 0)
            {
                healthIcon.fillAmount = 1;
                //invizeIcon.color = new Color(0, 0, 0, 0);
                healthIcon.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            health = true;
            healthIcon.gameObject.SetActive(true);
            player.health += healthRegen;
            StartCoroutine(HealthTiemr());
            Instantiate(destroyHealthVFX, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            source.PlayOneShot(buffsSFX);
        }

        if (collision.gameObject.CompareTag("Invize"))
        {
            invize = true;
            invizeIcon.gameObject.SetActive(true);
            player.collider.enabled = false;
            StartCoroutine(InvizeTiemr());
            Instantiate(destroyInvizeVFX, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            source.PlayOneShot(buffsSFX);
        }
    }

    IEnumerator InvizeTiemr()
    {
        yield return new WaitForSeconds(timeInvize);
        invize = false;
        player.collider.enabled = true;
        source.PlayOneShot(noTimeSFX);
    }

    IEnumerator HealthTiemr()
    {
        yield return new WaitForSeconds(timeInvize);
        health = false;
        //source.PlayOneShot(noTimeSFX);
    }
}
