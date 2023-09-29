using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController Controler;
    public float speed;
    public float smoothRotRime;
    public float turnsmoothvelocity;
    private Transform cam;
    
    void Start()
    {
        Controler = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }
    
    
    void Update()
    {
        move();
    }

    void move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, y);

        if (direction.magnitude > 0)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float smothAngle =
                Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnsmoothvelocity, smoothRotRime);
            transform.rotation = Quaternion.Euler(0f, smothAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            
            Controler.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    void GetMoouseinput()
    {
        if (Controler.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
            }
        }
    }
    
}
