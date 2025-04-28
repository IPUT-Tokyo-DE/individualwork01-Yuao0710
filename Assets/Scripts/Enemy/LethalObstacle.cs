using UnityEngine;

public class LethalObstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが PlayerCircleController を持っている場合 (Circle)
        PlayerCircleController circleController = collision.gameObject.GetComponent<PlayerCircleController>();
        if (circleController != null && circleController.enabled)
        {
            Debug.Log(collision.gameObject.name + " (Circle) は妨害オブジェクトに接触して死亡しました！");
            Destroy(collision.gameObject);
            return; // 死亡処理を行ったので、以降の判定は不要
        }

        // 衝突したオブジェクトが PlayerTriangleController を持っている場合 (Triangle)
        PlayerTriangleController triangleController = collision.gameObject.GetComponent<PlayerTriangleController>();
        if (triangleController != null && triangleController.enabled)
        {
            Debug.Log(collision.gameObject.name + " (Triangle) は妨害オブジェクトに接触して死亡しました！");
            Destroy(collision.gameObject);
            return; // 死亡処理を行ったので、以降の判定は不要
        }

        // 衝突したオブジェクトが PlayerSquareController を持っていない場合 (Square 以外)
        PlayerSquareController squareController = collision.gameObject.GetComponent<PlayerSquareController>();
        if (squareController == null)
        {
            // PlayerSquareController スクリプトを持っていないオブジェクトは死亡する
            Debug.Log(collision.gameObject.name + " (Square 以外) は妨害オブジェクトに接触して死亡しました！");
            Destroy(collision.gameObject);
        }
        // PlayerSquareController スクリプトを持っている場合 (Square)、何もしない (透過)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Square キャラクターとの接触を検知 (Is Trigger がオンの場合)
        PlayerSquareController squareController = other.GetComponent<PlayerSquareController>();
        if (squareController != null)
        {
            Debug.Log(other.gameObject.name + " (Square) は妨害オブジェクトを通り抜けました。");
            // Square キャラクターとの接触に対する特別な処理が必要であればここに記述
        }
    }
}