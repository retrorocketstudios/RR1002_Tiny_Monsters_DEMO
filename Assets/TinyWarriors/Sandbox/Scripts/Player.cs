using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpHeight = 2.0f;
    public float groundDistance = 5.0f;
    public float dashDistance = 5f;

    public LayerMask Ground;
    
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    private void Start()
    {
   
     _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, Ground,
            QueryTriggerInteraction.Ignore);
        
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis(("Horizontal"));
        _inputs.z = Input.GetAxis(("Vertical"));

        if (_inputs != Vector3.zero)
        {
            transform.forward = _inputs;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1.0f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1.0f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * moveSpeed * Time.deltaTime);
    }
} // end of class
