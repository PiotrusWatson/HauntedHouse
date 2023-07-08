using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

// [RequireComponent(typeof(NavMeshAgent))]
public class GoToCUBE : MonoBehaviour
{
    NavMeshAgent protagonist;
    public GameObject thingToChase;
    public bool InRange = false;
    public GameObject WayPoint1;
    public GameObject WayPoint2;
    private float disTo1;
    private float disTo2;
    public Transform Goal;
    public float WayPointRange = 2;
    public float GoalRange = 10;
    // Vector3 destination;

    void Start()
    {
        protagonist = GetComponent<NavMeshAgent>();
    //    NavMeshAgent agent = GetComponent<NavMeshAgent>();
     //   protagonist = GetComponent<NavMeshAgent>();
       // destination = protagonist.destination;
    }

    void Update()
    {
        protagonist.SetDestination(thingToChase.transform.position);

      //  if (Vector3.Distance(protagonist.transform.position, WayPoint2.transform.position) < WayPointRange && InRange == false)
       // {
        //    protagonist.SetDestination(WayPoint1.transform.position);
      //  }
       // if (Vector3.Distance(protagonist.transform.position, WayPoint1.transform.position) < WayPointRange && InRange == false)
       // {
        //    protagonist.SetDestination(WayPoint2.transform.position);
       // }
       if (Vector3.Distance(protagonist.transform.position, Goal.transform.position) < GoalRange)
       {
           InRange = true;
           protagonist.SetDestination(Goal.transform.position);
       }
       // if (Vector3.Distance(protagonist.transform.position, Goal.transform.position) > GoalRange && InRange == true)
       // {
        //    InRange = false;
        //    protagonist.SetDestination(WayPoint1.transform.position);
       // }
        //  if (Vector3.Distance(destination, goal.position) > 1.0f)
        // {
        //   destination = goal.position;
        // protagonist.destination = destination;
        // }
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
