using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string firstGameSceneName = "GameScene"; // �ŏ��Ƀ��[�h����Q�[���V�[���̖��O�� Inspector ����ݒ�

    public void LoadFirstGameScene()
    {
        SceneManager.LoadScene(firstGameSceneName);
    }
}
