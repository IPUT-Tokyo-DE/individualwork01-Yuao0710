using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1; // �R�C���̉��l (�擾���ɉ��Z����X�R�A)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // GameScoreManager �̃C���X�^���X�����݂���΃X�R�A�����Z
            if (GameScoreManager.Instance != null)
            {
                GameScoreManager.Instance.AddScore(coinValue);
            }

            // �R�C�������ł�����
            Destroy(gameObject);
        }
    }
}