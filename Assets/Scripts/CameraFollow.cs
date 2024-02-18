using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.y = player.position.y + offsetY;
            transform.position = cameraPosition;
        }
    }
}
