using UnityEngine;
using UnityEngine.UI;

public class ClickEnemy : MonoBehaviour
{
    [SerializeField] private Text killEnemy;
    private int counterKill;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapPointAll(clickPosition);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject);
                counterKill++;
            }
        }
        killEnemy.text = "Объектов уничтожено: " + counterKill;
    }
}
