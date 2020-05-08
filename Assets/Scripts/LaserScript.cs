using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
