using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private EventsSo eventsSo;
    [SerializeField] private GameObject playerVisual;
    [SerializeField] private GameObject playerDeathAnim;
    [SerializeField] private GameObject gameoverPanel;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER) || GameManager.Instance.CompareStateWithCurrent(GameState.MENU))
        {
            return;
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            playerVisual.SetActive(false);
            playerDeathAnim.SetActive(true);
            eventsSo.InvokePlayerDeath();
            GameManager.Instance.SetCurrentGameState(GameState.GAMEOVER);
            gameoverPanel.SetActive(true);
            Debug.Log("GameOver");
        }
    }
}
