using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour
{
    [SerializeField] private Transform moveable;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private float speed = 5;
    // Start is called before the first frame update
    Vector3 target;
    void Start()
    {
        moveable.localPosition = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable.transform.localPosition == startPos)
        {
            target = endPos;
        }

        if (moveable.transform.localPosition == endPos)
        {
            target = startPos;
        }


        moveable.localPosition = Vector3.MoveTowards(moveable.localPosition, target, speed * Time.deltaTime);
    }
}
