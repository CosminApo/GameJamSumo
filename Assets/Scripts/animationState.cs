using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(charMover))]
public class animationState : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animationCheck();
    }

    void animationCheck()
    {
        //// Moving Animation
        if(gameObject.GetComponent<inputManager>().inVector.x != 0.00f || gameObject.GetComponent<inputManager>().inVector.y != 0.00f)
        {
            anim.SetBool("isMoving", true);
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if(gameObject.GetComponent<inputManager>().inVector.x == 0.0f || gameObject.GetComponent<inputManager>().inVector.y == 0.0f)
        {
            anim.SetBool("isMoving", false);
        }

        //// Taunting Animation
        if (gameObject.GetComponent<inputManager>().getTaunt() == true)
        {
            anim.SetBool("isTaunting", true);
        }
        else
        {
            anim.SetBool("isTaunting", false);
        }
    }
}
