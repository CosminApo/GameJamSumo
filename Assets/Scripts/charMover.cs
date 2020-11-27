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


    private void Awake()
    {
        _in = GetComponent<inputManager>();
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
        //Debug.Log(_in.getDash());
        Vector3 movementVector = moveTowardTarget(targetVec);
        //rotate in the direction the character is traveling.
        facingForward(movementVector);
        if (_in.getDash() == true)
        {
            rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
           
        }
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
}
