using UnityEngine;
using TMPro;

public class ResultScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText; // スコア表示用の TextMeshPro Text オブジェクトを Inspector からアサイン

    void Start()
    {
        // GameScoreManager のインスタンスが存在すればスコアを取得して表示
        if (GameScoreManager.Instance != null)
        {
            int finalScore = GameScoreManager.Instance.GetScore();
            if (scoreText != null)
            {
                scoreText.text = "Final Score: " + finalScore;
            }
            else
            {
                Debug.LogError("Result Score Text UI がアサインされていません！");
            }
        }
        else
        {
            Debug.LogError("GameScoreManager のインスタンスが見つかりません！");
        }
    }
}