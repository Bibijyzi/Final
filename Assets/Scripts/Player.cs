using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapPointAll(clickPosition);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
