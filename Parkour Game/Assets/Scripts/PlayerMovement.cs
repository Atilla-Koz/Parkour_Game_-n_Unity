using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;

    public float speed = 1.0f;

    //Camera Controller
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
   
    //Jump & Gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool ÝsGround;

    public Transform groundChecker;
    public float groundChecherRadius;
    public LayerMask obstacleLayer;

    public float JumpHeight = 0.1f;
    public float gravityDivide = 100f;
    public float JumpSpeed = 100f;

    private float atimer;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //cursor
        Cursor.visible= false;
        Cursor.lockState= CursorLockMode.Locked;
    }

    private void Update()
    {
        //Check charcter is grounded
        ÝsGround = Physics.CheckSphere(groundChecker.position, groundChecherRadius, obstacleLayer);

        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);
        //Camere Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity,0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity; 
        xRotation = math.clamp(xRotation, -90f,90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        
        
        //Jump & Gravity
        if (!ÝsGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            atimer += Time.deltaTime / 3;
            speed = math.lerp(10, JumpSpeed, atimer);
        }
        else
        {
            velocity.y = -0.5f;
            speed = 10f;
            atimer = 0;
        }
        //Jump With Space
        if(Input.GetKeyDown(KeyCode.Space) && ÝsGround)
        {
            velocity.y = math.sqrt(JumpHeight * -2f * gravity / gravityDivide * Time.deltaTime);

        }

        
            controller.Move(velocity);

        


    }       
}
