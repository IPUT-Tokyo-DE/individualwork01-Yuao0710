using UnityEngine;

public class CoinSpowner : MonoBehaviour
{
    public GameObject CoinPrefab;
    int SpawnMax = 8;
    float x = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < SpawnMax; i++)
        {
            GameObject Coin = Instantiate(CoinPrefab, new Vector2(x, -0.5f),Quaternion.identity);
            x += 1;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
