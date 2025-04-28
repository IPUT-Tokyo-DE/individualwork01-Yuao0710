using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string firstGameSceneName = "GameScene"; // 最初にロードするゲームシーンの名前を Inspector から設定

    public void LoadFirstGameScene()
    {
        SceneManager.LoadScene(firstGameSceneName);
    }
}
