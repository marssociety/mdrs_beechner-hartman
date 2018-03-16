using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public bool teleported = false;
    public Teleporter destination;

    void OnTriggerEnter(Collider c)
    {

        if (c.CompareTag("Player"))
        {

            if (!teleported)
            {
                destination.teleported = true;
                c.gameObject.transform.position = destination.gameObject.transform.position;
            }
        }

    }

    void OnTriggerExit(Collider c)
    {

        if (c.CompareTag("Player"))
        {

            teleported = false;
        }

    }

}