using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�ł̏I��
#else
        Application.Quit(); // �r���h��̏I��
#endif
    }
}