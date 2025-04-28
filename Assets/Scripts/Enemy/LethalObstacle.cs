using UnityEngine;

public class LethalObstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�� PlayerCircleController �������Ă���ꍇ (Circle)
        PlayerCircleController circleController = collision.gameObject.GetComponent<PlayerCircleController>();
        if (circleController != null && circleController.enabled)
        {
            Debug.Log(collision.gameObject.name + " (Circle) �͖W�Q�I�u�W�F�N�g�ɐڐG���Ď��S���܂����I");
            Destroy(collision.gameObject);
            return; // ���S�������s�����̂ŁA�ȍ~�̔���͕s�v
        }

        // �Փ˂����I�u�W�F�N�g�� PlayerTriangleController �������Ă���ꍇ (Triangle)
        PlayerTriangleController triangleController = collision.gameObject.GetComponent<PlayerTriangleController>();
        if (triangleController != null && triangleController.enabled)
        {
            Debug.Log(collision.gameObject.name + " (Triangle) �͖W�Q�I�u�W�F�N�g�ɐڐG���Ď��S���܂����I");
            Destroy(collision.gameObject);
            return; // ���S�������s�����̂ŁA�ȍ~�̔���͕s�v
        }

        // �Փ˂����I�u�W�F�N�g�� PlayerSquareController �������Ă��Ȃ��ꍇ (Square �ȊO)
        PlayerSquareController squareController = collision.gameObject.GetComponent<PlayerSquareController>();
        if (squareController == null)
        {
            // PlayerSquareController �X�N���v�g�������Ă��Ȃ��I�u�W�F�N�g�͎��S����
            Debug.Log(collision.gameObject.name + " (Square �ȊO) �͖W�Q�I�u�W�F�N�g�ɐڐG���Ď��S���܂����I");
            Destroy(collision.gameObject);
        }
        // PlayerSquareController �X�N���v�g�������Ă���ꍇ (Square)�A�������Ȃ� (����)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Square �L�����N�^�[�Ƃ̐ڐG�����m (Is Trigger ���I���̏ꍇ)
        PlayerSquareController squareController = other.GetComponent<PlayerSquareController>();
        if (squareController != null)
        {
            Debug.Log(other.gameObject.name + " (Square) �͖W�Q�I�u�W�F�N�g��ʂ蔲���܂����B");
            // Square �L�����N�^�[�Ƃ̐ڐG�ɑ΂�����ʂȏ������K�v�ł���΂����ɋL�q
        }
    }
}