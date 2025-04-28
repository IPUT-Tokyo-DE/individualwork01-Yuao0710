using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public void HandleDeath()
    {
        Debug.Log(gameObject.name + " �͎��S���܂����I");
        ReloadCurrentScene();
        // �K�v�ł���΁A���S���̃A�j���[�V�����Đ�����ʉ��Đ��Ȃǂ̏�����ǉ�
        // Destroy(gameObject); // �I�u�W�F�N�g�������ɔj������ꍇ�̓R�����g�A�E�g���O��
    }

    void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}