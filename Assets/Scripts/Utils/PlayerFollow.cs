using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 followAxis;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        if (followAxis.x == 1)
        {
            currentPosition.x = playerTransform.position.x;
        }

        if (followAxis.y == 1)
        {
            currentPosition.y = playerTransform.position.y;
        }

        transform.position = currentPosition;
    }
}
