using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private EventsSo eventsSo;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER) || GameManager.Instance.CompareStateWithCurrent(GameState.MENU))
        {
            return;
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            eventsSo.InvokePlayerDeath();
            GameManager.Instance.SetCurrentGameState(GameState.GAMEOVER);
            Debug.Log("GameOver");
        }
    }
}
