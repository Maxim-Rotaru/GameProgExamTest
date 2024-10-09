using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 playerVelocity;
    Vector3 move;
    public int speed = 8;
    private CharacterController controller;
    public float gravity = -9.18f;
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessGravity();
    }

    void ProcessMovement() { 
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        controller.Move(move * Time.deltaTime * speed);
    }
    public void ProcessGravity()
    {
        // Since there is no physics applied on character controller, apply gravity manually
        if (isGrounded)
        {
            if (playerVelocity.y < 0.0f) // Ensure player stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }
        }
        else // If not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);


    }
}
