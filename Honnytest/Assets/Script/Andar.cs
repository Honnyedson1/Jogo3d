using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public float speed = 10f;
    public float rotation = 180.00f;
    private Rigidbody rig;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        move();
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 direcao = new Vector3(x, 0, y) * speed;
        
        
        transform.Translate(direcao*Time.deltaTime);
        
        transform.Rotate(new Vector3(
            0, mouseX * rotation * Time.deltaTime, 0));
    }
}
