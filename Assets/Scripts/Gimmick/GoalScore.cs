using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // �R���[�`�����g�p���邽�߂ɕK�v

public class FinalGoal : MonoBehaviour
{
    public float scoreMultiplierTime = 10f; // �󒆎��Ԃɑ΂���X�R�A�{��
    public float scoreMultiplierDistance = 5f; // �ړ������ɑ΂���X�R�A�{��
    public float sceneLoadDelay = 3f; // �V�[���J�ڂ܂ł̒x������ (�b)
    public string nextSceneName = "ResultScene"; // �J�ڐ�̃V�[���� (Inspector ����ݒ�)

    private float startTime;
    private float startPositionX;
    private bool inGoalArea = false;
    private bool landed = false;
    private GameObject player;
    private MonoBehaviour playerScript; // �v���C���[�X�N���v�g��ێ�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !inGoalArea && !landed)
        {
            inGoalArea = true;
            player = other.gameObject;
            startTime = Time.time;
            startPositionX = player.transform.position.x;

            // �v���C���[�X�N���v�g���擾
            playerScript = player.GetComponent<PlayerCircleController>();
            if (playerScript == null) playerScript = player.GetComponent<PlayerTriangleController>();
            if (playerScript == null) playerScript = player.GetComponent<PlayerSquareController>();

            Debug.Log("�S�[���G���A�ɓ���܂����I");
        }
    }

    void Update()
    {
        if (inGoalArea && player != null && !landed)
        {
            bool grounded = false;
            if (playerScript is PlayerCircleController circle) grounded = circle.IsGrounded;
            else if (playerScript is PlayerTriangleController triangle) grounded = triangle.IsGrounded;

            if (grounded)
            {
                landed = true;
                float airTime = Time.time - startTime;
                float distance = player.transform.position.x - startPositionX;
                int finalScore = Mathf.RoundToInt(airTime * scoreMultiplierTime + distance * scoreMultiplierDistance);

                if (GameScoreManager.Instance != null)
                {
                    GameScoreManager.Instance.AddScore(finalScore);
                    Debug.Log("���n�I�ŏI�X�R�A: " + finalScore);
                }
                else
                {
                    Debug.LogError("GameScoreManager �̃C���X�^���X��������܂���I");
                }

                // �V�[���J�ڃR���[�`�����J�n
                StartCoroutine(LoadNextSceneAfterDelay(sceneLoadDelay));
            }
        }
    }

    // �x����ɃV�[�������[�h����R���[�`��
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}