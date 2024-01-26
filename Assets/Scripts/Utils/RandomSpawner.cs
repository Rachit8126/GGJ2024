using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnNodeArray;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnHeight;
    [SerializeField] private float spawnOffset;

    private GameObject prevNode;
    private GameObject currNode;
    private List<GameObject> objectsList;
    private float height;

    private void Start()
    {
        objectsList = new();

        foreach (GameObject obj in spawnNodeArray)
        {
            GameObject spawnedObj = Instantiate(obj, transform);
            spawnedObj.SetActive(false);
            objectsList.Add(spawnedObj);
        }

        height = spawnHeight;
    }

    private void FixedUpdate()
    {
        if (playerTransform.position.y >= height)
        {
            height += spawnHeight;
            SpawnNode();
        }
    }

    private void SpawnNode()
    {
        if (prevNode != null)
        {
            prevNode = currNode;
            prevNode.SetActive(false);
        }

        currNode = objectsList[Random.Range(0, objectsList.Count)];
        currNode.SetActive(true);

        Vector3 position = currNode.transform.position;
        position.y = playerTransform.position.y + spawnOffset;
        currNode.transform.position = position;
    }
}
