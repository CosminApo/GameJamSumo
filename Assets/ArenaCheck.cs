using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArenaCheck : MonoBehaviour
{
    public PointsManager ptm;
    public GameObject arena;

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == arena) //if player is exiting collision with arena then
        {
            ptm.addOppositePoints(this.gameObject); //give points to players still in it
        }
    }
}
