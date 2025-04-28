using UnityEngine;
using UnityEngine.UI;

public class CharacterWheelController : MonoBehaviour
{
    [Tooltip("�L�����N�^�[�؂�ւ��{�^��")]
    public KeyCode toggleButton = KeyCode.Tab;

    [Tooltip("PlayerSwitcher �X�N���v�g")]
    public PlayerSwitcher playerSwitcher;

    [Tooltip("�L�����N�^�[�I���{�^���̔z��")]
    public Button[] characterButtons;

    private bool isWheelOpen = false;
    private int selectedCharacterIndex = -1;

    void Start()
    {
        // ������Ԃł̓z�C�[�����\���ɂ���
        gameObject.SetActive(false);

        // �{�^�������������蓖�Ă��Ă��邩�m�F
        if (characterButtons.Length != playerSwitcher.playerPrefabs.Length)
        {
            Debug.LogError("�L�����N�^�[�{�^���̐��ƃv���C���[�v���n�u�̐�����v���܂���I");
            enabled = false;
        }

        // �e�{�^���ɃN���b�N���̃��X�i�[��ݒ�
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i; // ���[�v���Ŏg�p����ϐ��̓R�s�[���쐬
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    void Update()
    {
        // �z�C�[���̕\��/��\����؂�ւ���
        if (Input.GetKeyDown(toggleButton))
        {
            isWheelOpen = !isWheelOpen;
            gameObject.SetActive(isWheelOpen);

            // �z�C�[�����J�����Ƃ��ɑI�������Z�b�g
            if (isWheelOpen)
            {
                selectedCharacterIndex = -1;
                UpdateSelectionVisuals();
                Time.timeScale = 0f; // �Q�[�����ꎞ��~
            }
            else
            {
                Time.timeScale = 1f; // �Q�[�����ĊJ
                // �L�����N�^�[���I������Ă���ΐ؂�ւ���
                if (selectedCharacterIndex != -1)
                {
                    playerSwitcher.SwitchPlayer(selectedCharacterIndex);
                    selectedCharacterIndex = -1;
                }
            }
        }

        // �z�C�[�����J���Ă����
        if (isWheelOpen)
        {
            // �L�[���͂ŃL�����N�^�[��I�� (��: 1, 2, 3 �L�[)
            if (Input.GetKeyDown(KeyCode.Alpha1) && characterButtons.Length > 0)
            {
                SelectCharacter(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && characterButtons.Length > 1)
            {
                SelectCharacter(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && characterButtons.Length > 2)
            {
                SelectCharacter(2);
            }

            // �}�E�X���͂ɂ��I�� (�I�v�V����)
            // �����Ƀ}�E�X�J�[�\���̈ʒu�Ɋ�Â��ă{�^����I�����鏈����ǉ��ł��܂�
        }
    }

    void SelectCharacter(int index)
    {
        if (index >= 0 && index < characterButtons.Length)
        {
            selectedCharacterIndex = index;
            UpdateSelectionVisuals();
        }
    }

    void UpdateSelectionVisuals()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            // �I������Ă���{�^���������\������ȂǁA���o�I�ȃt�B�[�h�o�b�N���
            if (i == selectedCharacterIndex)
            {
                // ��: �{�^���̐F��ς���
                ColorBlock cb = characterButtons[i].colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = Color.yellow;
                cb.selectedColor = Color.yellow;
                characterButtons[i].colors = cb;
            }
            else
            {
                // �I������Ă��Ȃ��{�^���̐F�����ɖ߂�
                ColorBlock cb = characterButtons[i].colors;
                cb.normalColor = Color.white; // ���̐F�ɍ��킹�ĕύX
                cb.highlightedColor = Color.white; // ���̐F�ɍ��킹�ĕύX
                cb.selectedColor = Color.white; // ���̐F�ɍ��킹�ĕύX
                characterButtons[i].colors = cb;
            }
        }
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e != null && e.type == EventType.KeyDown && e.keyCode == KeyCode.Tab)
        {
            Debug.Log("OnGUI: Tab �L�[��������܂���");
        }
    }
}