
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // �߂肽���Q�[���V�[���̖��O�� Inspector ����ݒ�

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
