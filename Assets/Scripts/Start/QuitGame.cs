using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    /// <summary>
    /// �A�v���P�[�V�������I�����܂��B
    /// �G�f�B�^���ł͍Đ����[�h���I�����܂��B
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�ł̏I��
#else
        Application.Quit(); // �r���h��̏I��
#endif
    }
}