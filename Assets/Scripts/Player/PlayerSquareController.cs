using UnityEngine;

public class PlayerSquareController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 通り抜けたオブジェクトが EnemyController スクリプトを持っているか確認
        EnemyCircle enemy = other.GetComponent<EnemyCircle>();
        if (enemy != null)
        {
            Debug.Log(other.gameObject.name + " が " + gameObject.name + " を通り抜けました。");
            // 必要に応じて、通り抜けた際の処理を追加することもできます
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // 通り抜けている間の処理が必要であれば記述します
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 通り抜け終わった後の処理が必要であれば記述します
    }
}