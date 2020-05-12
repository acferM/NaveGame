using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    public float speed;

    public GameObject laser;

    void Update()
    {
        move();

        if(Input.GetKeyDown(KeyCode.X))
        {
            shoot();
        }
    }

    void move()
    {
        GetComponent<Animator>().SetFloat("Speed", Input.GetAxis("Horizontal"));

        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }

    void shoot()
    {
        Instantiate(laser, new Vector3(transform.position.x, transform.position.y + 1.2f), Quaternion.identity);
    }
}
