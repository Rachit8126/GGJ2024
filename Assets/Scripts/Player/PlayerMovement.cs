using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameObject startMenu;
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

    private void Start()
    {
        eventsSo.OnPlayerDie += OnPlayerDie;
        GameManager.Instance.SetCurrentGameState(GameState.MENU);
    }

    private void OnDestroy()
    {
        eventsSo.OnPlayerDie -= OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        playerRigidBody.velocity = Vector3.zero;
        this.enabled = false;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.CompareStateWithCurrent(GameState.MENU) || GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER))
        {
            return;
        }


        Vector2 currentVelocity = playerRigidBody.velocity;
        currentVelocity.y = raiseSpeed;
        playerRigidBody.velocity = currentVelocity;
    }

    private void Update()
    {

        if (GameManager.Instance.CompareStateWithCurrent(GameState.MENU))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space was pressed : Game started");
                GameManager.Instance.SetCurrentGameState(GameState.GAMEPLAY);
                startMenu.SetActive(false);
            }
        }


        if (GameManager.Instance.CompareStateWithCurrent(GameState.MENU) || GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER))
        {
            return;
        }



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
