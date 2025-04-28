using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("�Ǐ]����^�[�Q�b�g�ƂȂ�v���C���[�I�u�W�F�N�g")]
    public Transform target;

    [Tooltip("�J�������^�[�Q�b�g���ǂꂾ���I�t�Z�b�g���邩 (�����ʒu����̑��΋���)")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    [Tooltip("�J�������^�[�Q�b�g�ɒǂ����܂ł̊��炩�� (0�ɋ߂��قǑ���)")]
    [Range(0f, 1f)]
    public float smoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // �^�[�Q�b�g�̖ڕW�ʒu���I�t�Z�b�g���������Čv�Z
            Vector3 targetPosition = target.position + offset;

            // SmoothDamp�֐����g���āA���݂̃J�����̈ʒu��ڕW�ʒu�Ɍ������Ċ��炩�Ɉړ�
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

            // �J�����̈ʒu���X�V
            transform.position = smoothedPosition;
        }
    }

    // PlayerSwitcher�X�N���v�g����^�[�Q�b�g��ݒ肷�邽�߂�public���\�b�h
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}