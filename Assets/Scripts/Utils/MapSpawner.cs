using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnNode;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnHeight;

    private GameObject currNode;
    private GameObject nextNode;
    private float height;

    private void FixedUpdate()
    {
        if (playerTransform.position.y >= height)
        {
            height += spawnHeight;
            if (currNode == null)
            {
                currNode = Instantiate(spawnNode, transform);
                currNode.transform.position = Vector3.zero;
                nextNode = Instantiate(spawnNode, transform);
                Vector3 pos = currNode.transform.position;
                pos.y += spawnHeight;
                nextNode.transform.position = pos;
                return;
            }

            Vector3 position = nextNode.transform.position;
            position.y += spawnHeight;
            currNode.transform.position = position;
            GameObject temp = nextNode;
            nextNode = currNode;
            currNode = temp;
        }
    }
}
