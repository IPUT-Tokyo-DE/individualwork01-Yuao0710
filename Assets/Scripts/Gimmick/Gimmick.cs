using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour
{
    [Tooltip("���̃M�~�b�N����������v���C���[�̃^�O")]
    public string playerTag = "Player";

    [Tooltip("�M�~�b�N����x�����쓮���邩�ǂ���")]
    public bool triggerOnce = true;

    [Tooltip("�ڐG���ɏ�������I�u�W�F�N�g")]
    public GameObject objectToDestroy;

    [Tooltip("�����܂ł̎��� (�b)")]
    public float respawnDelay = 3f;

    private bool hasTriggered = false;
    private GameObject destroyedObjectInstance; // ���������I�u�W�F�N�g�̃C���X�^���X��ێ�

    protected virtual void ActivateGimmick()
    {
        // �f�t�H���g�ł͉������Ȃ�
        Debug.Log(gameObject.name + " �̃M�~�b�N���쓮���܂����B");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �܂��쓮���Ă��炸�A�ڐG�����I�u�W�F�N�g�̃^�O�� playerTag �ƈ�v����ꍇ
        if (!hasTriggered && other.CompareTag(playerTag) && objectToDestroy != null)
        {
            Debug.Log(gameObject.name + " ���v���C���[�ɐG��A" + objectToDestroy.name + " ���������܂��B");

            // ��������I�u�W�F�N�g���A�N�e�B�u�����ăC���X�^���X��ێ�
            destroyedObjectInstance = objectToDestroy;
            destroyedObjectInstance.SetActive(false);

            // �����R���[�`�����J�n
            StartCoroutine(RespawnObject());

            // �M�~�b�N����x�����쓮����ꍇ�̓t���O�𗧂Ă�
            if (triggerOnce)
            {
                hasTriggered = true;
            }
        }
    }

    // �I�u�W�F�N�g�𕜊�������R���[�`��
    IEnumerator RespawnObject()
    {
        // �w�肳�ꂽ���Ԃ����҂�
        yield return new WaitForSeconds(respawnDelay);

        // ���������I�u�W�F�N�g�����݂���΁A�ēx�A�N�e�B�u������
        if (destroyedObjectInstance != null)
        {
            destroyedObjectInstance.SetActive(true);
            Debug.Log(destroyedObjectInstance.name + " ���������܂����B");
            destroyedObjectInstance = null; // ������A�Q�Ƃ��N���A
        }
    }
}