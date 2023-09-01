using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        move();
    }

    void move()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.x);
        
        float frent = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(frent * speed, rig.velocity.x);
    }
}
