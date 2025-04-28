using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float deathPositionY = -500f; // ���S������s�� Y ���W
    private DeathHandler deathHandler; // DeathHandler �X�N���v�g�ւ̎Q��

    void Start()
    {
        // �A�^�b�`����Ă��� DeathHandler �X�N���v�g���擾
        deathHandler = GetComponent<DeathHandler>();
        if (deathHandler == null)
        {
            Debug.LogError(gameObject.name + " �� DeathHandler �X�N���v�g���A�^�b�`����Ă��܂���I");
            enabled = false; // �X�N���v�g�𖳌���
        }
    }

    void Update()
    {
        if (transform.position.y < deathPositionY)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathHandler != null)
        {
            deathHandler.HandleDeath();
        }
    }

    // ReloadCurrentScene �֐��� DeathHandler �Ɉړ������̂ō폜
    // void ReloadCurrentScene()
    // {
    //     string currentSceneName = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene(currentSceneName);
    // }
}