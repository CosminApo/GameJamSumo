using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBtns : MonoBehaviour
{
    public void PlayClickSound()
    {
        FindObjectOfType<AudioManager>().Play("btnClick"); //play a sound
    }
}
