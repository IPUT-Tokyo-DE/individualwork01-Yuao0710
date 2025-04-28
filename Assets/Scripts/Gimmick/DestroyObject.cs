using UnityEngine;

public class DestroyObject : Gimmick
{
    [Tooltip("接触時に消去するオブジェクト")]
    public GameObject newDestroy;

    protected override void ActivateGimmick()
    {
        base.ActivateGimmick(); // 親クラスのログ出力も実行する場合

        if (newDestroy != null)
        {
            Destroy(newDestroy);
            Debug.Log(gameObject.name + " が作動し、" + newDestroy.name + " を消去しました。");
        }
        else
        {
            Debug.LogError(gameObject.name + " の DestroyObjectGimmick: 消去するオブジェクトが設定されていません。");
        }
    }
}