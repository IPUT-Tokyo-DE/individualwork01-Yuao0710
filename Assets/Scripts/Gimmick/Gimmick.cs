using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour
{
    [Tooltip("このギミックが反応するプレイヤーのタグ")]
    public string playerTag = "Player";

    [Tooltip("ギミックが一度だけ作動するかどうか")]
    public bool triggerOnce = true;

    [Tooltip("接触時に消去するオブジェクト")]
    public GameObject objectToDestroy;

    [Tooltip("復活までの時間 (秒)")]
    public float respawnDelay = 3f;

    private bool hasTriggered = false;
    private GameObject destroyedObjectInstance; // 消去したオブジェクトのインスタンスを保持

    protected virtual void ActivateGimmick()
    {
        // デフォルトでは何もしない
        Debug.Log(gameObject.name + " のギミックが作動しました。");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // まだ作動しておらず、接触したオブジェクトのタグが playerTag と一致する場合
        if (!hasTriggered && other.CompareTag(playerTag) && objectToDestroy != null)
        {
            Debug.Log(gameObject.name + " がプレイヤーに触れ、" + objectToDestroy.name + " を消去します。");

            // 消去するオブジェクトを非アクティブ化してインスタンスを保持
            destroyedObjectInstance = objectToDestroy;
            destroyedObjectInstance.SetActive(false);

            // 復活コルーチンを開始
            StartCoroutine(RespawnObject());

            // ギミックが一度だけ作動する場合はフラグを立てる
            if (triggerOnce)
            {
                hasTriggered = true;
            }
        }
    }

    // オブジェクトを復活させるコルーチン
    IEnumerator RespawnObject()
    {
        // 指定された時間だけ待つ
        yield return new WaitForSeconds(respawnDelay);

        // 消去したオブジェクトが存在すれば、再度アクティブ化する
        if (destroyedObjectInstance != null)
        {
            destroyedObjectInstance.SetActive(true);
            Debug.Log(destroyedObjectInstance.name + " が復活しました。");
            destroyedObjectInstance = null; // 復活後、参照をクリア
        }
    }
}