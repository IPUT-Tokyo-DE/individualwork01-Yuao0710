using UnityEngine;
using UnityEngine.UI;

public class CharacterWheelController : MonoBehaviour
{
    [Tooltip("キャラクター切り替えボタン")]
    public KeyCode toggleButton = KeyCode.Tab;

    [Tooltip("PlayerSwitcher スクリプト")]
    public PlayerSwitcher playerSwitcher;

    [Tooltip("キャラクター選択ボタンの配列")]
    public Button[] characterButtons;

    private bool isWheelOpen = false;
    private int selectedCharacterIndex = -1;

    void Start()
    {
        // 初期状態ではホイールを非表示にする
        gameObject.SetActive(false);

        // ボタンが正しく割り当てられているか確認
        if (characterButtons.Length != playerSwitcher.playerPrefabs.Length)
        {
            Debug.LogError("キャラクターボタンの数とプレイヤープレハブの数が一致しません！");
            enabled = false;
        }

        // 各ボタンにクリック時のリスナーを設定
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i; // ループ内で使用する変数はコピーを作成
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    void Update()
    {
        // ホイールの表示/非表示を切り替える
        if (Input.GetKeyDown(toggleButton))
        {
            isWheelOpen = !isWheelOpen;
            gameObject.SetActive(isWheelOpen);

            // ホイールが開いたときに選択をリセット
            if (isWheelOpen)
            {
                selectedCharacterIndex = -1;
                UpdateSelectionVisuals();
                Time.timeScale = 0f; // ゲームを一時停止
            }
            else
            {
                Time.timeScale = 1f; // ゲームを再開
                // キャラクターが選択されていれば切り替える
                if (selectedCharacterIndex != -1)
                {
                    playerSwitcher.SwitchPlayer(selectedCharacterIndex);
                    selectedCharacterIndex = -1;
                }
            }
        }

        // ホイールが開いている間
        if (isWheelOpen)
        {
            // キー入力でキャラクターを選択 (例: 1, 2, 3 キー)
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

            // マウス入力による選択 (オプション)
            // ここにマウスカーソルの位置に基づいてボタンを選択する処理を追加できます
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
            // 選択されているボタンを強調表示するなど、視覚的なフィードバックを提供
            if (i == selectedCharacterIndex)
            {
                // 例: ボタンの色を変える
                ColorBlock cb = characterButtons[i].colors;
                cb.normalColor = Color.yellow;
                cb.highlightedColor = Color.yellow;
                cb.selectedColor = Color.yellow;
                characterButtons[i].colors = cb;
            }
            else
            {
                // 選択されていないボタンの色を元に戻す
                ColorBlock cb = characterButtons[i].colors;
                cb.normalColor = Color.white; // 元の色に合わせて変更
                cb.highlightedColor = Color.white; // 元の色に合わせて変更
                cb.selectedColor = Color.white; // 元の色に合わせて変更
                characterButtons[i].colors = cb;
            }
        }
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e != null && e.type == EventType.KeyDown && e.keyCode == KeyCode.Tab)
        {
            Debug.Log("OnGUI: Tab キーが押されました");
        }
    }
}