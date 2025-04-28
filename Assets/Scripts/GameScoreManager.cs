using UnityEngine;
using TMPro;

public class GameScoreManager : MonoBehaviour
{
    public static GameScoreManager Instance { get; private set; }

    private int currentScore = 0;
    public TMP_Text scoreText; // �X�R�A�\���p�� TextMeshPro Text �I�u�W�F�N�g�� Inspector ����A�T�C��

    private void Awake()
    {
        // �V���O���g���C���X�^���X�̊Ǘ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���؂�ւ����ɔj�����Ȃ�
        }
        else
        {
            Destroy(gameObject); // ���ɃC���X�^���X�����݂���ꍇ�͎��g��j��
        }
    }

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
            Debug.LogWarning("Score Text UI ���A�T�C������Ă��܂���I");
        }
    }

    // �X�R�A�����Z�b�g����֐� (�K�v�ɉ�����)
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}