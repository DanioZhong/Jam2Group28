using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_ThirdCam : MonoBehaviour
{
    //speed of movement
    public float speed;
    //current controller
    public CharacterController controller;
    //camera that you want the player to follow
    public Transform cam;


    float Angle;
    float smoothAngle;
    float turnSmooth_time = 0.1f;
    float turnSmooth_velocity;
    Vector3 direction;
    Vector3 actual_moveDirection;


    void Update()
    {
        //=================================================================
        /*                      player movement setup                    */

        //get key wasd and arrow key
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //find moving angle in vector
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*                             end                               */
        //=================================================================

        if (direction.magnitude >= 0.1f)
        {
            //=================================================================
            /*                       movement control                        */

            //convert vector3 into angle + add camera angle, so the player will go toward
            Angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //get smooth angle for turning
            smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref turnSmooth_velocity, turnSmooth_time);
            //make player rotate
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            //make finding moving direction of camera
            actual_moveDirection = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;
            //make player move
            controller.Move(actual_moveDirection.normalized * speed * Time.deltaTime);
           
            /*                             end                               */
            //=================================================================

        }


    }
}




