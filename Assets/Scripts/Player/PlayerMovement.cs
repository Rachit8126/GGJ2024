using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private float rotateBounds;
    [SerializeField] private float raiseSpeed;
    [SerializeField] private float forceScale;
    [SerializeField] private float rotateTime;
    [SerializeField] private EventsSo eventsSo;

    private void Awake()
    {
        DOTween.Init();
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = playerRigidBody.velocity;
        currentVelocity.y = raiseSpeed;
        playerRigidBody.velocity = currentVelocity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Force towards right
            ApplyForce(1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Force towards left
            ApplyForce(-1);
        }
    }

    private void ApplyForce(int direction)
    {
        eventsSo.InvokeOnPlayerMove(direction);
        Vector2 forceDirection = new Vector2(direction * forceScale, 0f);
        playerRigidBody.AddForce(forceDirection);

        Vector3 rotation = Vector3.zero;
        rotation.z = -1 * rotateBounds * direction;
        transform.DOLocalRotate(rotation, 1f);
    }
}
