using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [Tooltip("切り替え可能なプレイヤーキャラクターのプレハブ")]
    public GameObject[] playerPrefabs;

    private GameObject currentPlayer;
    private int currentPlayerIndex = 0; // 現在のプレイヤーキャラクターのインデックスを追跡
    private CameraFollow mainCameraFollow; // CameraFollowスクリプトへの参照

    void Start()
    {
        // メインカメラにアタッチされたCameraFollowスクリプトを取得
        mainCameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (mainCameraFollow == null)
        {
            Debug.LogError("メインカメラに CameraFollow スクリプトが見つかりません。");
        }

        // 初期キャラクターを設定 (通常は配列の最初のキャラクター)
        if (playerPrefabs.Length > 0)
        {
            SwitchPlayer(0);
        }
        else
        {
            Debug.LogError("プレイヤーキャラクターのプレハブが設定されていません。");
        }
    }

    void Update()
    {
        // キー入力の検出とキャラクターの切り替え
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerPrefabs.Length > 0)
        {
            SwitchPlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerPrefabs.Length > 1)
        {
            SwitchPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && playerPrefabs.Length > 2)
        {
            SwitchPlayer(2);
        }
    }

    public void SwitchPlayer(int index)
    {
        if (index < 0 || index >= playerPrefabs.Length || playerPrefabs[index] == null)
        {
            Debug.LogError("無効なキャラクターインデックスです。");
            return;
        }

        // 現在のキャラクターが存在する場合は破棄し、位置を保存
        Vector3 previousPosition = Vector3.zero;
        if (currentPlayer != null)
        {
            previousPosition = currentPlayer.transform.position;
            Destroy(currentPlayer);
        }

        // 新しいキャラクターをインスタンス化し、同じ位置に配置
        currentPlayer = Instantiate(playerPrefabs[index], previousPosition, Quaternion.identity);
        currentPlayerIndex = index; // 現在のインデックスを更新

        // 新しいプレイヤーオブジェクトをカメラ追従のターゲットに設定
        if (mainCameraFollow != null)
        {
            mainCameraFollow.SetTarget(currentPlayer.transform);
        }

        Debug.Log("プレイヤーキャラクターを " + currentPlayer.name + " (インデックス: " + currentPlayerIndex + ") に切り替えました。");
    }

    // 現在のプレイヤーキャラクターのインデックスを返す public 関数
    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }
}