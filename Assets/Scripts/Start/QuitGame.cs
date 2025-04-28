using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    /// <summary>
    /// アプリケーションを終了します。
    /// エディタ内では再生モードを終了します。
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタでの終了
#else
        Application.Quit(); // ビルド後の終了
#endif
    }
}