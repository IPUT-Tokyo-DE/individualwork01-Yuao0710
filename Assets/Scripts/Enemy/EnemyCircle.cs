using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    [Tooltip("敵の移動速度")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("この敵オブジェクトには Rigidbody2D コンポーネントが必要です。");
            enabled = false; // Rigidbody2D がなければスクリプトを無効にする
            return;
        }

        // 移動方向を常に左向きに設定 (-1, 0)
        moveDirection = Vector2.left;

        // 等速直線運動を開始
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EnemyCircleと " + collision.gameObject.name + " が衝突しました。");
        PlayerSwitcher playerSwitcher = collision.gameObject.GetComponent<PlayerSwitcher>();

        if (playerSwitcher != null)
        {
            int currentPlayerIndex = playerSwitcher.GetCurrentPlayerIndex();
            Debug.Log("現在のプレイヤーインデックス: " + currentPlayerIndex);

            if (currentPlayerIndex != 1)
            {
                Debug.Log("インデックス 1 以外のプレイヤーが敵に衝突して死亡します！");
                // ここにプレイヤー死亡時の処理を記述 (例: ゲームオーバー)
                // Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("インデックス 1 のプレイヤーは敵をすり抜けました！");
            }
        }
        else
        {
            Debug.Log(collision.gameObject.name + " は PlayerSwitcher コンポーネントを持っていません。");
        }
    }
}