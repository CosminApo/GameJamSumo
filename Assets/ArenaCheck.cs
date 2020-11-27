using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCheck : MonoBehaviour
{

    public GameObject arena;
    public EnvironmentManager evm;

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == arena) //if player is exiting collision with arena then
        {
            evm.EndRound();
        }
    }
}
