using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 inVector{get; private set;}
    [SerializeField] string H_controller;
    [SerializeField] string V_controller;
    [SerializeField] string dash;
    [SerializeField] string taunt;
    private float dashing;
    private float taunting;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis(H_controller);//debugging
        float v = Input.GetAxis(V_controller);
        dashing = Input.GetAxis(dash);
        taunting = Input.GetAxis(taunt);
        inVector = new Vector2(h, v);
        getDash();
        getTaunt();
    }
    public bool getDash()
    {
        if (dashing > 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool getTaunt()
    {
        if (taunting > 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
