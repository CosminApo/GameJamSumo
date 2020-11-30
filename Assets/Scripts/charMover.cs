using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMover : MonoBehaviour
{
    private inputManager _in;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera mainCam;
    [SerializeField] private float rotSpeed;
    private Rigidbody rb;
    public float dashTimer;


    private void Awake()
    {
        _in = GetComponent<inputManager>();
        dashTimer = 0f;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetVec = new Vector3(_in.inVector.x, 0, _in.inVector.y);

        //move
        Vector3 movementVector = moveTowardTarget(targetVec);
        //rotate in the direction the character is traveling.
        facingForward(movementVector);
        dash(_in.getDash()); //-> function to allow dashing only once in a certain time.
        changeVelocity();
        dashTimer = countDown(dashTimer, 0.1f);
        //test
        
 
    }

    private Vector3 moveTowardTarget(Vector3 _targetVec)
    {
        float speed = moveSpeed * Time.deltaTime;

        _targetVec = Quaternion.Euler(0,mainCam.gameObject.transform.eulerAngles.y ,0) * _targetVec;
        //-> used to always move the character in relation to the camera
        //->[ e.g. moving right -> will always be the right side of the screen and not the character]

        Vector3 updatePosition = transform.position + _targetVec * speed;
        transform.position = updatePosition; 


        return _targetVec;
    }
    private void facingForward(Vector3 _target)
    {
        if(_target.magnitude == 0)
        {
            return;
            // -> this is done to prevent the player from instantly looking NORTH when nothing is pressed.
            // -> can be improved.
        }
        Quaternion rotation = Quaternion.LookRotation(_target);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotSpeed);
        
    }
    private void dash(bool _isDashing)
    {
        if (_isDashing == true && dashTimer < 0.1)
        {
            FindObjectOfType<AudioManager>().PlaySwish(); //play a sound
            rb.AddForce(transform.forward * 1500f, ForceMode.Impulse);
            dashTimer = 0.5f;
        }
    }
    private float countDown(float _timer,float _minimumTime)
    {
        if (_timer > _minimumTime)
        {
            _timer -= Time.deltaTime;
        }
        return _timer;
    }
    private void changeVelocity()
    {
        if (rb.velocity.magnitude > 1.4 || rb.velocity.magnitude < -1.4)
        {
            rb.mass = 10000f;
            lightUp();
        }
        else
        {
            rb.mass = 100f;
            lightsOut();
        }
    }
    private void lightUp()
    {
        if (gameObject.name == "p2 Variant")
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        }
        else if(gameObject.name == "p1 Variant")
        {
            gameObject.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", Color.blue);
        }
    }
    private void lightsOut()
    {
        if (gameObject.name == "p2 Variant")
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }
        else if (gameObject.name == "p1 Variant")
        {
            gameObject.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", Color.black);
        }
    }
}
