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
    public float coliderradius = 2f;    
    
    [Header("componentes")] 
    private Animator anim;
    private CapsuleCollider capsule;
    private BoxCollider box;
    private NavMeshAgent agent;

    [Header("outros")] 
    public Transform player;

    private bool atacking;
    private bool walking;
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lockradius)
        {
            agent.isStopped = false;

            if (!atacking)
            {
                agent.SetDestination(player.position);
                anim.SetBool("Slither Forward", true);
                walking = true;
            }
            if (distance <= agent.stoppingDistance)
            {
                StartCoroutine("Matack");
            }
            else
            {
                atacking = false;
            }
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("Slither Forward", false);
            atacking = false;
            walking = false;    
        }
    }
    
    IEnumerator Matack()
    {
        atacking = true;
        walking = false;
        anim.SetBool("Slither Forward", false);
        anim.SetBool("Bite Attack", true);
        yield return new WaitForSeconds(1f);

        GetPlayer();
        

       // yield return new WaitForSeconds(4f);
    }

    void GetPlayer()
    {
        foreach(Collider c in Physics.OverlapSphere((transform.position + transform.forward * coliderradius),coliderradius))
        {
            if (c.gameObject.CompareTag("Player"))
            {
                Debug.Log("Aiinnnn");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lockradius);
    }
}
