using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitTheGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタでの終了
#else
        Application.Quit(); // ビルド後の終了
#endif
    }
}