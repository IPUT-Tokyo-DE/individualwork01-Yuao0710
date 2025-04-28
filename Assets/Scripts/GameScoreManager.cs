using UnityEngine;
using TMPro;

public class GameScoreManager : MonoBehaviour
{
    public static GameScoreManager Instance { get; private set; }

    private int currentScore = 0;
    public TMP_Text scoreText; // スコア表示用の TextMeshPro Text オブジェクトを Inspector からアサイン

    private void Awake()
    {
        // シングルトンインスタンスの管理
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン切り替え時に破棄しない
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は自身を破棄
        }
    }

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

    public int GetScore()
    {
        return currentScore;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
        else
        {
            Debug.LogWarning("Score Text UI がアサインされていません！");
        }
    }

    // スコアをリセットする関数 (必要に応じて)
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}