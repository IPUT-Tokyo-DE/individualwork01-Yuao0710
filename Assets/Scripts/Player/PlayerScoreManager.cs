using UnityEngine;
using TMPro; // TextMeshPro を使用する場合

public class PlayerScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    public TMP_Text scoreText; // スコア表示用の TextMeshPro Text オブジェクトを Inspector からアサイン

    private void Start()
    {
        // 初期スコアを UI に表示
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
        else
        {
            Debug.LogError("Score Text UI がアサインされていません！");
        }
    }
}