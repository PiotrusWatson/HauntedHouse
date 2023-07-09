using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

// [RequireComponent(typeof(NavMeshAgent))]
public class GoToCUBE : MonoBehaviour
{
    NavMeshAgent protagonist;
    public float distanceWhenWereBored;
    public bool ZOMBIEMODE = false;
    public bool InRange = false;
    public int delay;
    public GameObject[] objectives;
    int currentObj = 0;
    
    Vector3 destination;

    void Start()
    {
        protagonist = GetComponent<NavMeshAgent>();
        StartCoroutine(Wait());
    //    NavMeshAgent agent = GetComponent<NavMeshAgent>();
     //   protagonist = GetComponent<NavMeshAgent>();
       // destination = protagonist.destination;
    }

    //void Update()
    // {
       // protagonist.SetDestination(thingToChase.transform.position);

      //  if (Vector3.Distance(protagonist.transform.position, WayPoint2.transform.position) < WayPointRange && InRange == false)
       // {
        //    protagonist.SetDestination(WayPoint1.transform.position);
      //  }
       // if (Vector3.Distance(protagonist.transform.position, WayPoint1.transform.position) < WayPointRange && InRange == false)
       // {
        //    protagonist.SetDestination(WayPoint2.transform.position);
       // }
      // if (Vector3.Distance(protagonist.transform.position, Goal.transform.position) < GoalRange)
      // {
        //   InRange = true;
       //    protagonist.SetDestination(Goal.transform.position);
     //  }
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
   // }
   void Update()
   {

        //      protagonist.destination = thingToChase.transform.position;
        if (Vector3.Distance(this.transform.position, objectives[currentObj].transform.position) < distanceWhenWereBored && !ZOMBIEMODE)
         //   Wait();
        currentObj++;


        if (currentObj >= objectives.Length)
            currentObj = 0;

        destination = objectives[currentObj].transform.position;
        protagonist.SetDestination(destination);
        // this.transform.LookAt(objectives[currentObj].transform);
        // this.transform.Translate(0,0, speed*Time.deltaTime);

    }

  IEnumerator Wait() 
  { 
     yield return new WaitForSeconds(delay);
     //Thread.Sleep(delay);
        Debug.Log("Moving on");
  }

  //  public static void Main()
  //  {
 //       TimeSpan interval = new Time
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
