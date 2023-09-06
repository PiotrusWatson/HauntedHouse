using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationManager : MonoBehaviour
{
    NavMeshAgent mover;
    bool isWaiting = false;
    float oldSpeed;
    public UnityEvent FinishedWaiting;

    
    
    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<NavMeshAgent>();
        oldSpeed = mover.speed;
        
    }

    public void Wait(float delay){
        mover.speed = 0;
        StartCoroutine(WaitNumerator(delay));
    }


    public void InvokeWaitingOver(){
        FinishedWaiting.Invoke();
    }
    
    IEnumerator WaitNumerator(float delay) 
  {
        if (!isWaiting)
        {
            isWaiting = true;
            yield return new WaitForSeconds(delay);
            isWaiting = false;
            mover.speed = oldSpeed;
            FinishedWaiting.Invoke();
        }
    }

    public bool AreWeWaiting(){
        return isWaiting;
    }

    public void SetDestination(Vector3 newDestination){
        mover.destination = newDestination;
    }
}
