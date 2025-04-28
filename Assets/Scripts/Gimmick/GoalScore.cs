using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // コルーチンを使用するために必要

public class FinalGoal : MonoBehaviour
{
    public float scoreMultiplierTime = 10f; // 空中時間に対するスコア倍率
    public float scoreMultiplierDistance = 5f; // 移動距離に対するスコア倍率
    public float sceneLoadDelay = 3f; // シーン遷移までの遅延時間 (秒)
    public string nextSceneName = "ResultScene"; // 遷移先のシーン名 (Inspector から設定)

    private float startTime;
    private float startPositionX;
    private bool inGoalArea = false;
    private bool landed = false;
    private GameObject player;
    private MonoBehaviour playerScript; // プレイヤースクリプトを保持

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !inGoalArea && !landed)
        {
            inGoalArea = true;
            player = other.gameObject;
            startTime = Time.time;
            startPositionX = player.transform.position.x;

            // プレイヤースクリプトを取得
            playerScript = player.GetComponent<PlayerCircleController>();
            if (playerScript == null) playerScript = player.GetComponent<PlayerTriangleController>();
            if (playerScript == null) playerScript = player.GetComponent<PlayerSquareController>();

            Debug.Log("ゴールエリアに入りました！");
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
                    Debug.Log("着地！最終スコア: " + finalScore);
                }
                else
                {
                    Debug.LogError("GameScoreManager のインスタンスが見つかりません！");
                }

                // シーン遷移コルーチンを開始
                StartCoroutine(LoadNextSceneAfterDelay(sceneLoadDelay));
            }
        }
    }

    // 遅延後にシーンをロードするコルーチン
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}