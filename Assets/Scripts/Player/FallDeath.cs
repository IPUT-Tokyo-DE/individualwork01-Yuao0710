using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float deathPositionY = -500f; // 死亡判定を行う Y 座標
    private DeathHandler deathHandler; // DeathHandler スクリプトへの参照

    void Start()
    {
        // アタッチされている DeathHandler スクリプトを取得
        deathHandler = GetComponent<DeathHandler>();
        if (deathHandler == null)
        {
            Debug.LogError(gameObject.name + " に DeathHandler スクリプトがアタッチされていません！");
            enabled = false; // スクリプトを無効化
        }
    }

    void Update()
    {
        if (transform.position.y < deathPositionY)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathHandler != null)
        {
            deathHandler.HandleDeath();
        }
    }

    // ReloadCurrentScene 関数は DeathHandler に移動したので削除
    // void ReloadCurrentScene()
    // {
    //     string currentSceneName = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene(currentSceneName);
    // }
}