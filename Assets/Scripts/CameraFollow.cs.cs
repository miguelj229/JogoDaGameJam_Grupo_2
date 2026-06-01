using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float minZoom = 5f;
    public float maxZoom = 10f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 middle =
            (player1.position + player2.position) / 2f;

        transform.position = new Vector3(
            middle.x,
            middle.y,
            transform.position.z
        );

        float distance =
            Vector2.Distance(
                player1.position,
                player2.position
            );

        cam.orthographicSize =
            Mathf.Clamp(distance, minZoom, maxZoom);
    }
}