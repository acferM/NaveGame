using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    bool dissolve = false;
    public float speed;
    Material material;
    float fade = 1;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;    
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * speed * 15 * Time.deltaTime, Space.World);

        if (dissolve)
        {
            speed = 0;
            fade -= Time.deltaTime;

            if (fade <= 0)
            {
                fade = 0;
                dissolve = false;
                Destroy(this.gameObject);
            }

            material.SetFloat("_Fade", fade);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraShake.randomShake();

        if (collision.gameObject.name.StartsWith("laser"))
        {
            Destroy(this.gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(collision.gameObject);
            dissolve = true;
        }

        if (collision.gameObject.name == "hero")
        {
            Destroy(this.gameObject);
        }
    }
}
