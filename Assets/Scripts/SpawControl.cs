using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawControl : MonoBehaviour
{
    public GameObject asteroid, screenBorder;
    Vector3 position;

    void Start()
    {
        InvokeRepeating("spawn", 8f, 1f);
    }

    void spawn()
    {
        position = new Vector3(Random.Range(-screenBorder.transform.position.x + .5f, screenBorder.transform.position.x - .5f),
                               Random.Range(screenBorder.transform.position.y + 5, screenBorder.transform.position.y + 10));

        Instantiate(asteroid, position, Quaternion.identity);
    }
}
