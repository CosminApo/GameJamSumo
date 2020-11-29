using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(inputManager))]
public class charMan : MonoBehaviour
{
    private Animator charAnim;
    private Rigidbody rb;
    private bool isAttacking;
    Collision Obj;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();

        //attaching the animator so it can later be disabled.
    }

    // Update is called once per frame
    void Update()
    {
        attack();

    }

    private void attack()
    {
        if (rb.velocity.magnitude > 1.4 || rb.velocity.magnitude < -1.4) // uses the same rule as the dash power in charMover
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isAttacking)
        {
            if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("Destroyed");
                collision.gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }


}
