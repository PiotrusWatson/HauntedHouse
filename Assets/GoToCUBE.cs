using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

[RequireComponent(typeof(NavMeshAgent))]
public class GoToCUBE : MonoBehaviour
{
    NavMeshAgent protagonist;
   // public GameObject thingToChase;
    public Transform goal;
    Vector3 destination;

    void Start()
    {
    //    NavMeshAgent agent = GetComponent<NavMeshAgent>();
        protagonist = GetComponent<NavMeshAgent>();
        destination = protagonist.destination;
    }

    void Update()
    {
        if (Vector3.Distance(destination, goal.position) > 1.0f)
        {
            destination = goal.position;
            protagonist.destination = destination;
        }
    }
    // {
     //   destination = goal.position;
      //  agent.destination = destination;
        // protagonist.destination = thingToChase.transform.position;
   // }

   // void Update()
    //{
      //  if (Input.GetMouseButtonDown(0))
       // {
        //    SetDestinationToMousePostion();
       // }
   // }

  //  void SetDestinationToMousePostion()
   // {
     //   RaycastHit hit;
       // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         //   if (Physics.Raycast(ray, out hit))
       // {
         //   boundary.SetDestination(hit.point);
       // }
            
   // }
}
