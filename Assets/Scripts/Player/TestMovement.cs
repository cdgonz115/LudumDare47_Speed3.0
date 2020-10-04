using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Rigidbody rb;
    float x, y, z;
    public GameObject camera;
    public float walkSpeed;
    public float runSpeed;
    public float speed;
    public float gravityRate;
    public float increaseRate;

    public float distToGround;
    public float jumpHeight;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded; 

    public CharacterController controller;
    Vector3 yVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<CapsuleCollider>().bounds.center.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(controller.isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = -2f;
        }
        Move();
       Jump();

        //print(rb.velocity);
    }
    void Move()
    {
        //isGrounded = (Physics.Raycast(transform.position, -Vector3.up, distToGround))? true: false;
        speed = (Input.GetKey(KeyCode.LeftShift))? runSpeed : walkSpeed;
        /*if (!isGrounded)
        {
            z = Input.GetAxis("Horizontal") * speed;
            x = Input.GetAxis("Vertical") * speed;
        }
        else 
        {
            */
        if (Input.GetKey(KeyCode.W)) z = (z>=speed)?z+increaseRate:speed;
        else if (Input.GetKey(KeyCode.S)) z= (z <= -speed)? z - increaseRate : -speed;
        else z = 0;
        if (Input.GetKey(KeyCode.D)) x = (x >= speed) ? x + increaseRate : speed;
        else if (Input.GetKey(KeyCode.A)) x = (x <= -speed) ? x - increaseRate : -speed;
        else x = 0;

        //if (Input.GetKey(KeyCode.W)) rb.velocity = transform.forward * speed;
        //else if (Input.GetKey(KeyCode.S)) rb.velocity = transform.forward* -speed;
        //if (Input.GetKey(KeyCode.D)) rb.velocity = transform.right * speed;
        //else if (Input.GetKey(KeyCode.A)) rb.velocity =  transform.right * -speed;


        //}     
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*Time.deltaTime);
        yVelocity.y += gravityRate * Time.deltaTime;
        controller.Move(yVelocity * Time.deltaTime);
        //print(rb.velocity);/
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityRate);
    }
    void ApplyGravity()
    { 
        //if(isGrounded)
    }
}
