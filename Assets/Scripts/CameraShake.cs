using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    static Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void randomShake()
    {
        int random = Random.Range(1, 3);

        anim.SetTrigger("Shake" + random);
    }
}
