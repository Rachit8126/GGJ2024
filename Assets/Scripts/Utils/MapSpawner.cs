using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnNode;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnHeight;

    private GameObject prevNode;
    private GameObject currNode;
    private float height;

    private void FixedUpdate()
    {
        if (playerTransform.position.y >= height)
        {
            height += spawnHeight;
            if (currNode == null)
            {
                currNode = Instantiate(spawnNode, transform);
            }

            if (prevNode == null)
            {
                prevNode = Instantiate(spawnNode, transform);
            }
            GameObject temp = prevNode;
            prevNode = currNode;
            prevNode.SetActive(false);
            currNode = temp;
            currNode.SetActive(true);
            Vector3 position = currNode.transform.position;
            position.y = playerTransform.position.y;
            currNode.transform.position = position;
        }
    }
}
