using UnityEngine;
using TMPro;

public class ResultScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText; // �X�R�A�\���p�� TextMeshPro Text �I�u�W�F�N�g�� Inspector ����A�T�C��

    void Start()
    {
        // GameScoreManager �̃C���X�^���X�����݂���΃X�R�A���擾���ĕ\��
        if (GameScoreManager.Instance != null)
        {
            int finalScore = GameScoreManager.Instance.GetScore();
            if (scoreText != null)
            {
                scoreText.text = "Final Score: " + finalScore;
            }
            else
            {
                Debug.LogError("Result Score Text UI ���A�T�C������Ă��܂���I");
            }
        }
        else
        {
            Debug.LogError("GameScoreManager �̃C���X�^���X��������܂���I");
        }
    }
}