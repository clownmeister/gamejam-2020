using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask jumpCheckLayerMask;
    public GameObject head;
    
    private Rigidbody body;
    
    public float speed = 10;
    public float sprintModifier = 1.5f;
    public float rotationSpeed = 5;
    public float jumpForce = 5;
    
    //debug
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        RotateBody();
        RotateHead();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        Debug.Log(transform.position.y);
        if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y,transform.position.z), 0.3f, jumpCheckLayerMask))
        {
            body.velocity = new Vector3(body.velocity.x, jumpForce, body.velocity.z);
        }
    }
    
    public void RotateHead()
    {
        float xRot;

        xRot = -Input.GetAxis("Mouse Y") * rotationSpeed;
        
        head.transform.Rotate(xRot, 0, 0);
    }
    
    public void RotateBody()
    {
        float yRot;

        yRot = Input.GetAxis("Mouse X") * rotationSpeed;
        
        transform.Rotate(new Vector3(0,yRot,0));
    }
    
    public void Move()
    {
        Vector3 direction = Vector3.zero;
        float currentSpeed = speed;
        
        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintModifier;
        }
        
        //move
        //vertical
        direction += transform.forward * Input.GetAxisRaw("Vertical");
        
        //horizontal
        direction += transform.right * Input.GetAxisRaw("Horizontal");

        direction.Normalize();
        direction = currentSpeed * Time.deltaTime * direction;

        float realspeed = new Vector3(body.velocity.x, 0, body.velocity.z).magnitude;

        body.MovePosition(body.position + direction);

//        transform.Translate(direction);
//        body.velocity = new Vector3(direction.x, body.velocity.y, direction.z);

//        direction.y = body.velocity.y;
//        if (realspeed < 10)
//        {
//            body.AddForce(direction, ForceMode.Force);
//        }

//        if (body.velocity.y > 1)
//        {
//            body.velocity = new Vector3(body.velocity.x, 1, body.velocity.z);
//        }

        time = time + Time.fixedDeltaTime;
        if (time > 1.0f)
        {
            Debug.Log("Current speed = " + realspeed + " m/s");
            time = 0.0f;
        }
    }
}