using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float x, y, z;
    public float walkSpeed;
    public float speed;
    public float gravityRate;
    public float increaseRate;
    public float jumpHeight;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundeDistance;

    public CharacterController controller;
    public Vector3 yVelocity;
    public Vector3 move;
    public Rigidbody rb;

    public bool inBoost;
    public float boostMultiplier;

    public LayerMask mask;

    // Update is called once per frame
    private void Start()
    {
        speed = walkSpeed;
    }
    void Update()
    {

        if (transform.position.y < 0) print(transform.position.y);
        //if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        isGrounded = Physics.CheckSphere(groundCheck.position,groundeDistance,mask);
        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = 0f;
        }
        Move();
        Jump();

        print(speed);
    }
    void Move()
    {
        //isGrounded = (Physics.Raycast(transform.position, -Vector3.up, distToGround))? true: false;
        //speed = (Input.GetKey(KeyCode.LeftShift))? runSpeed : walkSpeed;
        /*if (!isGrounded)
        {
            z = Input.GetAxis("Horizontal") * speed;
            x = Input.GetAxis("Vertical") * speed;
        }
        else 
        {
            */
        if (Input.GetKey(KeyCode.W)) z = (z >= speed) ? z + increaseRate : speed;
        else if (Input.GetKey(KeyCode.S)) z = (z <= -speed) ? z - increaseRate : -speed;
        else
        {
            z = 0;
            boostMultiplier = 1;
        }
        if (Input.GetKey(KeyCode.D)) x = (x >= speed) ? x + increaseRate : speed;
        else if (Input.GetKey(KeyCode.A)) x = (x <= -speed) ? x - increaseRate : -speed;
        else
        {
            x = 0;
            boostMultiplier = 1;
        }

            //if (Input.GetKey(KeyCode.W)) rb.velocity = transform.forward * speed;
            //else if (Input.GetKey(KeyCode.S)) rb.velocity = transform.forward* -speed;
            //if (Input.GetKey(KeyCode.D)) rb.velocity = transform.right * speed;
            //else if (Input.GetKey(KeyCode.A)) rb.velocity =  transform.right * -speed;


            //}     
            move = transform.right * x + transform.forward * z;
        controller.Move(move*Time.deltaTime * boostMultiplier);
        yVelocity.y += gravityRate * Time.deltaTime;
        //else yVelocity.y = 0;
        controller.Move(yVelocity * Time.deltaTime);
        //print(rb.velocity);/
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityRate);
    }
    void ApplyGravity()
    { 
        //if(isGrounded)
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundeDistance);
    }
}
