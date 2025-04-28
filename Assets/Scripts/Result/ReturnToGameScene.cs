
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // 戻りたいゲームシーンの名前を Inspector から設定

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
