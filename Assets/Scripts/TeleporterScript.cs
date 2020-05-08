using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject horiontalTp;
    public GameObject verticalTp;
    public GameObject adapter;

    public GameObject player;
    GameObject newPlayer;
    public bool canClone;

    Vector3 clonePosition;

    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= adapter.transform.position.x && canClone)
        {
            canClone = false;
            if (transform.position.x > 0)
            {
                clonePosition = new Vector3(horiontalTp.transform.position.x * -1, transform.position.y);
                clonar(ref newPlayer);
            }
            else
            {
                clonePosition = new Vector3(horiontalTp.transform.position.x, transform.position.y);
                clonar(ref newPlayer);
            }
        }

        if (transform.position.y >= adapter.transform.position.y && canClone)
        {
            canClone = false;
            clonePosition = new Vector3(transform.position.x, verticalTp.transform.position.y * -1);
            clonar(ref newPlayer);
        }
        else if (transform.position.y <= -adapter.transform.position.y - 0.0329f && canClone)
        {
            canClone = false;
            clonePosition = new Vector3(transform.position.x, verticalTp.transform.position.y);
            clonar(ref newPlayer);
        }
    }

    void clonar(ref GameObject newPlayer)
    {
        newPlayer = Instantiate(player, clonePosition, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        newPlayer.name = "hero";
        newPlayer.GetComponent<TeleporterScript>().canClone = true;
        Destroy(this.gameObject);
    }
}
