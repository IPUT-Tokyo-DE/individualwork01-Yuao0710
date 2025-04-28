using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCircleController : MonoBehaviour
{
    [Tooltip("移動速度")]
    public float moveSpeed = 5f;

    [Tooltip("ジャンプ力")]
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isAlive = true;
    private bool isGrounded = false;
    public bool IsGrounded { get { return isGrounded; } }

    void Start()
    {
        // Rigidbody2D コンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("このプレイヤーオブジェクトには Rigidbody2D コンポーネントが必要です。");
            enabled = false; // Rigidbody2D がなければスクリプトを無効にする
        }

        isAlive = true; // 初期状態は生存
    }

    void Update()
    {
        if (isAlive)
        {
            // 左右の移動 (空中にいる間も可能)
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, 0f);
            rb.linearVelocity = new Vector2(movement.normalized.x * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    DeathHandler playerDeathHandler = collision.gameObject.GetComponent<DeathHandler>();
                    if (playerDeathHandler != null)
                    {
                        playerDeathHandler.HandleDeath();
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // 敵との衝突判定 (EnemyCircle スクリプトを持つオブジェクトと衝突したら死亡)
        EnemyCircle enemy = collision.gameObject.GetComponent<EnemyCircle>();
        if (enemy != null && isAlive)
        {
            Debug.Log(gameObject.name + " は敵に衝突して死亡しました！");
            isAlive = false;
            Destroy(gameObject); // 死亡したらオブジェクトを破壊 (必要に応じて変更)
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}