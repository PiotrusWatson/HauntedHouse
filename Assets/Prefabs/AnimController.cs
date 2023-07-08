using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private NavMeshAgent agent;
    public Rigidbody rb;
    
    

   

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            animator.SetBool("IsMoving", true);
            transform.hasChanged = false;
        }

        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

}