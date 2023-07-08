using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectChaser : MonoBehaviour
{
    public GameObject thingToChase;
    private NavMeshAgent mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<NavMeshAgent>();
        mover.destination = thingToChase.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
