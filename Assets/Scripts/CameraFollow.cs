using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("追従するターゲットとなるプレイヤーオブジェクト")]
    public Transform target;

    [Tooltip("カメラがターゲットをどれだけオフセットするか (初期位置からの相対距離)")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    [Tooltip("カメラがターゲットに追いつくまでの滑らかさ (0に近いほど速い)")]
    [Range(0f, 1f)]
    public float smoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // ターゲットの目標位置をオフセットを加味して計算
            Vector3 targetPosition = target.position + offset;

            // SmoothDamp関数を使って、現在のカメラの位置を目標位置に向かって滑らかに移動
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

            // カメラの位置を更新
            transform.position = smoothedPosition;
        }
    }

    // PlayerSwitcherスクリプトからターゲットを設定するためのpublicメソッド
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}