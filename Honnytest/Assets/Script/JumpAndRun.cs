using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndRun : MonoBehaviour
{
    public CharacterController characterController;
    public float jumpForce = 5f;
    public float gravity = 9.81f;

    private Vector3 playerVelocity;
    private Animator anim;
    private bool isGrounded;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        characterController.Move(move * Time.deltaTime * jumpForce);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetInteger("Transition", 5);
            playerVelocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        playerVelocity.y -= gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}