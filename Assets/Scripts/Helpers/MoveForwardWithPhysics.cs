using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardWithPhysics : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start(){
        rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
