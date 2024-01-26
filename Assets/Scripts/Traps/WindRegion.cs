using UnityEngine;

public class WindRegion : MonoBehaviour
{
    [SerializeField] private Vector3 windDirection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Rigidbody2D rb))
            {
                rb.AddForce(windDirection);
                gameObject.SetActive(false);
            }
        }
    }
}
