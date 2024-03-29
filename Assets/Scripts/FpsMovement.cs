﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

[RequireComponent(typeof(CharacterController))]

// basic WASD-style movement control
public class FpsMovement : MonoBehaviour
{
    [SerializeField] private Camera headCam;

    public float speed = 6.0f;
    public float gravity = -9.8f;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float rotationVert = 0;

    public float rotationSpeed = 6.0f;
    public float smoothTime = 0.1f;
    public float smoothVar;
    public Transform camera;


    private CharacterController charController;


    //for jump : 
    public float jumpSpeed = 15.0f;
    public float velocity = -10.0f;
    public float minimunFalling = -1.5f;

    private float vSpeed;

    private ControllerColliderHit colision;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveCharacter();
       RotateCharacter();
      //  RotateCamera();
    }

    private void MoveCharacter()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);


        // rotation and moving : 
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 direction = (Quaternion.Euler(0, camera.eulerAngles.y, 0) * new Vector3(hor, 0f, vert)).normalized; // fix the player movement accroding to camera direction by multuply..
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;// camera.eulerAngles.y; // the + make player face the center of camera , when camera rotate his face rotate
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothVar, smoothTime);
        transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        charController.Move(direction * 12.0f * Time.deltaTime);


        // for jump :
        bool inGround = false;
            RaycastHit hit;
            if (vSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                float check = (charController.height + charController.radius) / 1.9f;
                inGround = hit.distance <= check;
            }
            if (inGround)
            {
                if (Input.GetButtonDown("Jump"))
                    vSpeed = jumpSpeed;
                else
                    vSpeed = minimunFalling;
            }

            else
            {
                vSpeed += gravity * 5 * Time.deltaTime;
                if (vSpeed < velocity)
                {
                    vSpeed = velocity;
                }
            movement.y = vSpeed;
            movement.y *= Time.deltaTime;

            charController.Move(movement);
        }
            /*  if(charController.isGrounded)
              {
                  if(Vector3.Dot(movement, colision.normal)<0)
                  {
                      movement = colision.normal * jumpSpeed;
                  }
                  else
                  {
                      movement += colision.normal * jumpSpeed;

                  }

              }
            */
           movement.y = vSpeed;
            movement.y *= Time.deltaTime;

           charController.Move(movement);
         
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        colision = hit;
    }


    private void RotateCharacter()
    {

        //  transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);

    }
     
    
    private void RotateCamera()
    {
        rotationVert -= Input.GetAxis("Mouse Y") * sensitivityVert;
        rotationVert = Mathf.Clamp(rotationVert, minimumVert, maximumVert);

        headCam.transform.localEulerAngles = new Vector3(
            rotationVert, headCam.transform.localEulerAngles.y, 0
        );
    }
    
}
