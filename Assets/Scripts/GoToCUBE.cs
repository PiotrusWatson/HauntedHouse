using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// [RequireComponent(typeof(NavMeshAgent))]
public class GoToCUBE : MonoBehaviour
{

    public float distanceWhenWereBored;
    public bool ZOMBIEMODE = false;
    public int delay;
    public GameObject[] objectives;
    public bool seenSwitch = false;
    
    
    Animator controller;
    NavMeshAgent protagonist;
    int currentObj = 0;
    Vector3 destination;
    float oldSpeed;

    void Start()
    {
        controller = GetComponent<Animator>();
        protagonist = GetComponent<NavMeshAgent>();
        oldSpeed = protagonist.speed;
    }

   void Update()
   {

        if (Vector3.Distance(this.transform.position, objectives[currentObj].transform.position) < distanceWhenWereBored && !ZOMBIEMODE)
        {
            controller.SetBool("IsSearch", true);
            protagonist.speed = 0;
            StartCoroutine(Wait());
        }

        if (currentObj >= objectives.Length)
            currentObj = 0;

        destination = objectives[currentObj].transform.position;
        protagonist.SetDestination(destination);


    }

  IEnumerator Wait(){
    yield return Wait(delay);
  }
  IEnumerator Wait(int delay) 
  {
        if (!seenSwitch)
        {
            seenSwitch = true;
            yield return new WaitForSeconds(delay);
            currentObj++;
            protagonist.speed = oldSpeed;
            controller.SetBool("IsSearch", false);
            seenSwitch = false;
        }
    }

}
