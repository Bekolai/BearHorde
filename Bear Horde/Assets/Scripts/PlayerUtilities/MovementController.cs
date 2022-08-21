using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{


    [Header("Movement")]
    [SerializeField] public float playerSpeed = 10f; //temp playerspeed
    [SerializeField] public float xSpeed = 10f;//temp xspeed
    [SerializeField] public float xClamp = 3.5f;


    float _distanceToScreen;
    Vector3 _mousePos;
    float _playerSpeed; //used playerspeed
    float _xSpeed; //used xspeed
    float direction;
   
    Rigidbody rb;

  
    private void Start()
    {
        GetComponent<BearAnimController>().Sleep();
        // StartMovement();
        StopMovement();
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {

        Movement();
       

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            var position = Input.mousePosition;

            _distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
            direction = _xSpeed;
            direction = _mousePos.x > transform.position.x ? direction : -direction;


        }

    }


    void Movement()
    {
        Vector3 movement = Vector3.forward * _playerSpeed * Time.deltaTime;
        movement.y = rb.velocity.y; //saving y velocity to use gravity
        //  rb.velocity = Vector3.forward * _playerSpeed * Time.deltaTime;
        rb.velocity = movement; //add forward velocity
        if (Math.Abs(_mousePos.x - transform.position.x) > 0.5f)
        {
            transform.Translate(Time.deltaTime * direction, 0, 0);

        }

        var pos = transform.position; // TO CHECK IF CHARACTER IS IN X AXIS BORDER 
        pos.x = Mathf.Clamp(transform.position.x, -xClamp, xClamp);//
        transform.position = pos;//

    }
    public void StopMovement()
    {
        _xSpeed = 0f;
        _playerSpeed = 0f;
    }
    public void StartMovement()
    {
        GetComponent<BearAnimController>().StartRunning();
        _xSpeed = xSpeed;
        _playerSpeed = playerSpeed;
    }
    public void StopVerticalMovement()
    {
         _playerSpeed = 0f;
    }
    public void StartVerticalMovement()
    {
        _playerSpeed = playerSpeed;
    }
    public void StopHoriztontalMovement()
    {
        _xSpeed = 0f;
       

    }
    public void StartHorizontalMovement()
    {
        _xSpeed = xSpeed;
        
    }





}
