using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMovement player;

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9)
        {
            player.grounded = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 9)
        {
            player.grounded = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        player.grounded = false;
    }
}
