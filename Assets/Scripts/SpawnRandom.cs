using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject prefab;
    public int amount = 0;
    public Vector2 min = Vector2.zero;
    public Vector2 max = Vector2.zero;


    void Awake()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            GameObject agent = Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
