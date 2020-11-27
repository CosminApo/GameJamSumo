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
    private float dashing;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis(H_controller);//debugging
        float v = Input.GetAxis(V_controller);
        dashing = Input.GetAxis(dash);
        inVector = new Vector2(h, v);
        getDash();
    }
    public bool getDash()
    {
        if (dashing > 0.1f)
        {
            Debug.Log(Input.GetAxis(dash));
            return true;
        }
        else
        {
            return false;
        }
    }

}
