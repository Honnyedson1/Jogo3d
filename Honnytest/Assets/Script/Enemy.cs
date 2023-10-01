using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Atributos")]
    public float life;
    public float atack;
    public float speed;
    public float lockradius;
    
    [Header("componentes")] 
    private Animator anim;
    private CapsuleCollider capsule;
    private BoxCollider box;
    private NavMeshAgent agent;

    [Header("outros")] 
    public Transform player;
    void Start()
    {
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        box = GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lockradius)
        {
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lockradius);
    }
}
