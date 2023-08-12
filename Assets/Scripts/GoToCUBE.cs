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
    public float rotationSpeed;
    
    
    Animator controller;
    NavMeshAgent protagonist;
    int currentObj = 0;
    Vector3 destination;
    float oldSpeed;
    GameObject target;

    void Start()
    {
        controller = GetComponent<Animator>();
        protagonist = GetComponent<NavMeshAgent>();
        oldSpeed = protagonist.speed;
    }

   void Update()
   {

    if (!ZOMBIEMODE){
         target = FindNearestZombie();
         transform.rotation = GetRotationToPoint(target);
    }
       
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

    GameObject FindNearestZombie(){
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject closestZombie = zombies[0];
        float shortestDistance = Vector3.Distance(transform.position, closestZombie.transform.position);

        foreach (GameObject zombie in zombies){
            float distance = Vector3.Distance(transform.position, zombie.transform.position);
            if (distance < shortestDistance){
                shortestDistance = distance;
                closestZombie = zombie;
            }            
        }
        return closestZombie;
    }

    Quaternion GetRotationToPoint(GameObject point){
        Vector3 targetDirection = point.transform.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        return Quaternion.LookRotation(newDirection);
    }

}
