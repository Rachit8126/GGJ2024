using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState currentGameState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
                Debug.Log("Reloading Scene");
            }
        }
    }
    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

    public void SetCurrentGameState(GameState state)
    {
        currentGameState = state;
    }

    public bool CompareStateWithCurrent(GameState state)
    {
        if (currentGameState == state)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}