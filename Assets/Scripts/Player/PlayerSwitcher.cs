using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [Tooltip("�؂�ւ��\�ȃv���C���[�L�����N�^�[�̃v���n�u")]
    public GameObject[] playerPrefabs;

    private GameObject currentPlayer;
    private int currentPlayerIndex = 0; // ���݂̃v���C���[�L�����N�^�[�̃C���f�b�N�X��ǐ�
    private CameraFollow mainCameraFollow; // CameraFollow�X�N���v�g�ւ̎Q��

    void Start()
    {
        // ���C���J�����ɃA�^�b�`���ꂽCameraFollow�X�N���v�g���擾
        mainCameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (mainCameraFollow == null)
        {
            Debug.LogError("���C���J������ CameraFollow �X�N���v�g��������܂���B");
        }

        // �����L�����N�^�[��ݒ� (�ʏ�͔z��̍ŏ��̃L�����N�^�[)
        if (playerPrefabs.Length > 0)
        {
            SwitchPlayer(0);
        }
        else
        {
            Debug.LogError("�v���C���[�L�����N�^�[�̃v���n�u���ݒ肳��Ă��܂���B");
        }
    }

    void Update()
    {
        // �L�[���͂̌��o�ƃL�����N�^�[�̐؂�ւ�
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerPrefabs.Length > 0)
        {
            SwitchPlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerPrefabs.Length > 1)
        {
            SwitchPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && playerPrefabs.Length > 2)
        {
            SwitchPlayer(2);
        }
    }

    public void SwitchPlayer(int index)
    {
        if (index < 0 || index >= playerPrefabs.Length || playerPrefabs[index] == null)
        {
            Debug.LogError("�����ȃL�����N�^�[�C���f�b�N�X�ł��B");
            return;
        }

        // ���݂̃L�����N�^�[�����݂���ꍇ�͔j�����A�ʒu��ۑ�
        Vector3 previousPosition = Vector3.zero;
        if (currentPlayer != null)
        {
            previousPosition = currentPlayer.transform.position;
            Destroy(currentPlayer);
        }

        // �V�����L�����N�^�[���C���X�^���X�����A�����ʒu�ɔz�u
        currentPlayer = Instantiate(playerPrefabs[index], previousPosition, Quaternion.identity);
        currentPlayerIndex = index; // ���݂̃C���f�b�N�X���X�V

        // �V�����v���C���[�I�u�W�F�N�g���J�����Ǐ]�̃^�[�Q�b�g�ɐݒ�
        if (mainCameraFollow != null)
        {
            mainCameraFollow.SetTarget(currentPlayer.transform);
        }

        Debug.Log("�v���C���[�L�����N�^�[�� " + currentPlayer.name + " (�C���f�b�N�X: " + currentPlayerIndex + ") �ɐ؂�ւ��܂����B");
    }

    // ���݂̃v���C���[�L�����N�^�[�̃C���f�b�N�X��Ԃ� public �֐�
    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }
}