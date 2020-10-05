using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMovement : MonoBehaviour
{
    public float x, y, z;
    public float walkSpeed;
    public float speed;
    public float gravityRate;
    public float increaseRate;
    public float jumpHeight;

    public bool isGrounded;
    public bool stop;
    public Transform groundCheck;
    public float groundeDistance;

    public CharacterController controller;
    public float velocity;
    public Vector3 yVelocity;
    public Vector3 move;
    public Rigidbody rb;

    public float boostMultiplier;

    public LayerMask mask;

    // Update is called once per frame

    private void Start()
    {
        speed = walkSpeed;
    }
    void Update()
    {

        //if (transform.position.y < 0) print(transform.position.y);
        //if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        isGrounded = Physics.CheckSphere(groundCheck.position,groundeDistance,mask);
        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = 0f;
        }
        Move();
        Jump();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<BreakAtSpeed>()) 
        {
            if (velocity >= hit.gameObject.GetComponent<BreakAtSpeed>().speedBreeak)
            {
                hit.gameObject.GetComponent<BreakAtSpeed>().Poof();
            }
            stop = true;
        } 

        if(hit.gameObject.tag == "Win")
        {
            SceneManager.LoadScene(0);
        }
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
        if (stop)
        {
            z = 0;
            x = 0;
            velocity = 0;
            stop = false;
            boostMultiplier = 1;
        }
        else
        {
            if (Input.GetKey(KeyCode.W)) z = (z >= speed) ? z + increaseRate : speed;
            else if (Input.GetKey(KeyCode.S)) z = (z <= -speed) ? z - increaseRate : -speed;
            else
            {
                z = 0;
                boostMultiplier = 1;
                velocity = 0;
            }
            if (Input.GetKey(KeyCode.D)) x = (x >= speed) ? x + increaseRate : speed;
            else if (Input.GetKey(KeyCode.A)) x = (x <= -speed) ? x - increaseRate : -speed;
            else
            {
                x = 0;
            }
        }
       

            //if (Input.GetKey(KeyCode.W)) rb.velocity = transform.forward * speed;
            //else if (Input.GetKey(KeyCode.S)) rb.velocity = transform.forward* -speed;
            //if (Input.GetKey(KeyCode.D)) rb.velocity = transform.right * speed;
            //else if (Input.GetKey(KeyCode.A)) rb.velocity =  transform.right * -speed;


            //}     
        move = transform.right * x + transform.forward * z;
        controller.Move(move*Time.deltaTime * boostMultiplier);
        velocity += Mathf.Abs( ( (transform.right* (x == 0 ? 0 : 1) + transform.forward* (z == 0 ? 0 : 1))* increaseRate).magnitude )  ;
        yVelocity.y += gravityRate * Time.deltaTime;
        //else yVelocity.y = 0;
        controller.Move(yVelocity * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityRate);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundeDistance);
    }
}
