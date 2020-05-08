using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    // LEMBRAR DE TESTAR TP SEM O IF

    public Transform horiontalTp;
    public Transform verticalTp;

    public GameObject player;
    GameObject newPlayer;
    public bool canClone = true;

    Vector3 clonePosition;

    void Update()
    {
        // LEMBRAR DE TESTAR TP SEM O IF

        if (Mathf.Abs(transform.position.x) >= 10.911f && canClone)
       {
            canClone = false;
            if (transform.position.x > 0)
            {
                clonePosition.x = horiontalTp.position.x * -1;
                clonePosition.y = transform.position.y;
                clonar(ref newPlayer);
            }
            else
            {
                clonePosition.x = horiontalTp.position.x;
                clonePosition.y = transform.position.y;
                clonar(ref newPlayer);
            }
       }

        if (transform.position.y >= 4.086f && canClone)
        {
            canClone = false;
            clonePosition.y = verticalTp.position.y * -1;
            clonePosition.x = transform.position.x;
            clonar(ref newPlayer);
        }
        else if (transform.position.y <= -4.1189f && canClone)
        {
            canClone = false;
            clonePosition.y = verticalTp.position.y;
            clonePosition.x = transform.position.x;
            clonar(ref newPlayer);
        }
    }

    void clonar(ref GameObject newPlayer)
    {
        newPlayer = Instantiate(player, clonePosition, Quaternion.identity);
    }

    // LEMBRAR DE TESTAR SEM O IF
    private void OnBecameInvisible()
    {
        if (this.gameObject.name == "hero")
        {
            newPlayer.name = "hero";
            newPlayer.GetComponent<TeleporterScript>().canClone = true;
            Destroy(this.gameObject);
        }
    }
}
