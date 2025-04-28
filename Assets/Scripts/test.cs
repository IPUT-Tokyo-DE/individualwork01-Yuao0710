using UnityEngine;

public class InputTest : MonoBehaviour
{
    public KeyCode testKey = KeyCode.Tab;

    void Update()
    {
        if (Input.GetKeyDown(testKey))
        {
            Debug.Log("InputTest Update: " + testKey + " キーが押されました");
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e != null && e.type == EventType.KeyDown && e.keyCode == testKey)
        {
            Debug.Log("InputTest OnGUI: " + testKey + " キーが押されました");
        }
    }
}