using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1; // コインの価値 (取得時に加算するスコア)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // GameScoreManager のインスタンスが存在すればスコアを加算
            if (GameScoreManager.Instance != null)
            {
                GameScoreManager.Instance.AddScore(coinValue);
            }

            // コインを消滅させる
            Destroy(gameObject);
        }
    }
}