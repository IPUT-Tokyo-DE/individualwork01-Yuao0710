using UnityEngine;

public class DestroyObject : Gimmick
{
    [Tooltip("�ڐG���ɏ�������I�u�W�F�N�g")]
    public GameObject newDestroy;

    protected override void ActivateGimmick()
    {
        base.ActivateGimmick(); // �e�N���X�̃��O�o�͂����s����ꍇ

        if (newDestroy != null)
        {
            Destroy(newDestroy);
            Debug.Log(gameObject.name + " ���쓮���A" + newDestroy.name + " ���������܂����B");
        }
        else
        {
            Debug.LogError(gameObject.name + " �� DestroyObjectGimmick: ��������I�u�W�F�N�g���ݒ肳��Ă��܂���B");
        }
    }
}