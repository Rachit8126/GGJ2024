using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;

    private void OnEnable()
    {
        score = 0;
        scoreText.text = "Distance: 0m";
    }

    private void Update()
    {
        if (GameManager.Instance.CompareStateWithCurrent(GameState.MENU) || GameManager.Instance.CompareStateWithCurrent(GameState.GAMEOVER))
        {
            return;
        }
        score += Time.deltaTime;
        scoreText.text = "Distance: " + Mathf.Floor(score).ToString() + "m";
    }
}
