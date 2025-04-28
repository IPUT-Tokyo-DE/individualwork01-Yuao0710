using UnityEngine;
using TMPro; // TextMeshPro ���g�p����ꍇ

public class PlayerScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    public TMP_Text scoreText; // �X�R�A�\���p�� TextMeshPro Text �I�u�W�F�N�g�� Inspector ����A�T�C��

    private void Start()
    {
        // �����X�R�A�� UI �ɕ\��
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
            Debug.LogError("Score Text UI ���A�T�C������Ă��܂���I");
        }
    }
}