using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce, lowJump, quickFall, speed, runSpeed;
    private Rigidbody rb;
    private float horizontalAxis = 0, verticalAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Walk();
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && !CheckIfHanging.isInAir)
        {
            rb.velocity = Vector3.up * jumpForce;
        }
            

        QuickFall();
    }

    private void QuickFall()
    {
        if (rb.velocity.y < 0)
            rb.velocity += Vector3.up * Physics.gravity.y * quickFall * Time.deltaTime;
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            rb.velocity += Vector3.up * Physics.gravity.y * lowJump * Time.deltaTime;
    }

    private void Walk()
    {
        Vector3 xMove, zMove;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            xMove = Vector3.right * Input.GetAxisRaw("Horizontal") * runSpeed;
            zMove = Vector3.forward * Input.GetAxisRaw("Vertical") * runSpeed;
        }
        else
        {
            xMove = Vector3.right * Input.GetAxisRaw("Horizontal") * speed;
            zMove = Vector3.forward * Input.GetAxisRaw("Vertical") * speed;
        }
        
        rb.velocity = xMove + zMove;
    }
}
