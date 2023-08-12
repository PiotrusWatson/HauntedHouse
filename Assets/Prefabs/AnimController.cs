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
    public GameObject corpse;
    public float deathForce;
    
    

   

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

    public void Owie(){
        animator.SetTrigger("Ow");
    }

    public void Ded(){
        GameObject builtCorpse = Instantiate(corpse, transform.position, transform.rotation);
        Rigidbody corpseRigidbody = builtCorpse.GetComponentInChildren<Rigidbody>();
        corpseRigidbody.AddForce(transform.forward * deathForce);
        Destroy(gameObject); //todo: fix this so it doesn't break everything
    }

}