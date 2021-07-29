using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigidBody;

    public float playerSpeed = 20;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    public float jumpHeight = 3f;
    public float mouseSensitivity = 2f;
    //private bool isMoving = false;
    //private bool isSprinting = false;
    private float yRot;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        playerSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            rigidBody.velocity = transform.right * playerSpeed;
            //rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            //isMoving = true;
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rigidBody.velocity = -transform.right * playerSpeed;
            //rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            //isMoving = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            anim.SetInteger("Idle", 0);
            rigidBody.velocity = transform.forward * playerSpeed;
            //rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            //isMoving = true;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetInteger("Walk", 2);
            }
            else
            {
                anim.SetInteger("Walk", 1);
            }
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            anim.SetInteger("Idle", 0);
            rigidBody.velocity = -transform.forward * playerSpeed;
            //rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            //isMoving = true;

            if (Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetInteger("Walk", 2);
            }
            else
            {
                anim.SetInteger("Walk", 1);
            }
        }
        else
        {
            anim.SetInteger("Walk", 0);
            //anim.SetInteger("Idle", 0);

            if (Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetInteger("Idle", 1);
            }
            else
            {
                anim.SetInteger("Idle", 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.Translate(Vector3.up * jumpHeight);
            rigidBody.AddForce(0, 10, 0);
            anim.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
    }
}
