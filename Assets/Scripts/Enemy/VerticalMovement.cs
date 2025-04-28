using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [Tooltip("移動する距離")]
    public float moveDistance = 2f;

    [Tooltip("移動速度")]
    public float moveSpeed = 1f;

    [Tooltip("移動の開始位置（ローカル座標）")]
    public float startOffset = 0f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timer = 0f;

    void Start()
    {
        // 初期位置を記録
        startPosition = transform.localPosition;
        // 移動の終了位置を計算
        endPosition = startPosition + Vector3.up * (moveDistance + startOffset);
        // 開始位置をオフセット
        transform.localPosition = startPosition + Vector3.up * startOffset;
    }

    void Update()
    {
        // 時間を進行
        timer += Time.deltaTime * moveSpeed;

        // 現在の位置を計算
        float t = Mathf.PingPong(timer, 1f);
        transform.localPosition = Vector3.Lerp(startPosition + Vector3.up * startOffset, startPosition + Vector3.up * (moveDistance + startOffset), t);

        // 往復移動の方向を制御 (PingPong を使用するため不要になりましたが、残しておきます)
        // if (t >= 1f) direction = -1;
        // if (t <= 0f) direction = 1;
        // transform.localPosition += Vector3.up * direction * moveSpeed * Time.deltaTime;
    }
}