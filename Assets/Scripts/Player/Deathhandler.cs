using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public void HandleDeath()
    {
        Debug.Log(gameObject.name + " は死亡しました！");
        ReloadCurrentScene();
        // 必要であれば、死亡時のアニメーション再生や効果音再生などの処理を追加
        // Destroy(gameObject); // オブジェクトをすぐに破棄する場合はコメントアウトを外す
    }

    void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}