using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [Tooltip("�ړ����鋗��")]
    public float moveDistance = 2f;

    [Tooltip("�ړ����x")]
    public float moveSpeed = 1f;

    [Tooltip("�ړ��̊J�n�ʒu�i���[�J�����W�j")]
    public float startOffset = 0f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float timer = 0f;

    void Start()
    {
        // �����ʒu���L�^
        startPosition = transform.localPosition;
        // �ړ��̏I���ʒu���v�Z
        endPosition = startPosition + Vector3.up * (moveDistance + startOffset);
        // �J�n�ʒu���I�t�Z�b�g
        transform.localPosition = startPosition + Vector3.up * startOffset;
    }

    void Update()
    {
        // ���Ԃ�i�s
        timer += Time.deltaTime * moveSpeed;

        // ���݂̈ʒu���v�Z
        float t = Mathf.PingPong(timer, 1f);
        transform.localPosition = Vector3.Lerp(startPosition + Vector3.up * startOffset, startPosition + Vector3.up * (moveDistance + startOffset), t);

        // �����ړ��̕����𐧌� (PingPong ���g�p���邽�ߕs�v�ɂȂ�܂������A�c���Ă����܂�)
        // if (t >= 1f) direction = -1;
        // if (t <= 0f) direction = 1;
        // transform.localPosition += Vector3.up * direction * moveSpeed * Time.deltaTime;
    }
}