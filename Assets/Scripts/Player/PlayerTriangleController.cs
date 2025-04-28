using UnityEngine;

public class PlayerTriangleController : MonoBehaviour
{
    public float moveSpeed = 5f;
    [Tooltip("�W�����v��")]
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAlive = true;


    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("このプレイヤーオブジェクトには Rigidbody2D コンポーネントが必要です。");
            enabled = false; // Rigidbody2D がなければスクリプトを無効にする
            return; // Rigidbody2D がなければ以降の処理を行わない
        }

        if (isAlive)
        {
            // 左右の移動
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, 0f);
            rb.linearVelocity = new Vector2(movement.normalized.x * moveSpeed, rb.linearVelocity.y);
            // 接地している場合のみ移動を許可
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

    void Update()
    {
        // �W�����v
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // �󒆂ɂ����Ԃɂ���
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面と衝突した場合、isGrounded を true に設定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // �Փ˂�������� EnemyCircle �X�N���v�g�����邩�m�F
        EnemyCircle enemy = collision.gameObject.GetComponent<EnemyCircle>();

        if (enemy != null)
        {
            // �G�ƏՓ˂����ꍇ�A���g��j�󂷂�i���S�����j
            Debug.Log(gameObject.name + " �͓G�ɏՓ˂��Ď��S���܂����I");
            Destroy(gameObject);
            // �K�v�ɉ����āA�Q�[���I�[�o�[�����Ȃǂ������ɋL�q���Ă�������
        }

        // �ڒn����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // �n�ʂɐڒn������Ԃɂ���
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 地面から離れた場合、isGrounded を false に設定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // FinalGoal スクリプトから参照できるように isGrounded プロパティを追加
    public bool IsGrounded { get { return isGrounded; } }
}