using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Reflection;

[System.Serializable]
public class SeeingEvent : UnityEvent<Transform[]>{

}
public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public float pollDelay;
    
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets;
    List<Transform> visibleZombies;
    public SeeingEvent IsawANewThing;
    public SeeingEvent IsawAThingIWantToKill;
    
    void Start()
    {
        visibleTargets = new List<Transform>();
        StartCoroutine(FindTargetsWithDelay(pollDelay));
    }
    
    IEnumerator FindTargetsWithDelay(float delay){
        while(true)
        {
            yield return new WaitForSeconds(delay);
            List<Transform> lastCheckedTargets = new List<Transform>(visibleTargets);
            //fills the visibletargets 
            visibleTargets = FindVisibleTargets();

            visibleZombies = new List<Transform>();
            List<Transform> finalList = new List<Transform>();
            foreach (Transform target in visibleTargets)
            {
                if (target.GetComponent<ZombieBehaviour>() != null)
                {
                    visibleZombies.Add(target);
                }
            }
            bool seenNewThing = GuyHasSeenNewThing(lastCheckedTargets, visibleTargets);
            if (seenNewThing)
            {
                finalList.AddRange(visibleTargets);
            }
            if (ThereAreZombies())
            {
                finalList.AddRange(visibleZombies);
            }

            if (seenNewThing)
            {
                IsawANewThing.Invoke(finalList.ToArray());
                
            }

            if (ThereAreZombies()){
                IsawAThingIWantToKill.Invoke(visibleZombies.ToArray());
            }
            
        }
    }
    
    //is there anything newly visible that isn't something we've seen before?
    bool GuyHasSeenNewThing(List<Transform> currentlyVisible, List<Transform> newlyVisible){
        return newlyVisible.Except(currentlyVisible).ToList().Count > 0;
    }
    List<Transform> FindVisibleTargets(){
        visibleTargets = new List<Transform>();
        //gets everything in radius
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        //for each thing in radius
        for (int i=0; i < targetsInViewRadius.Length; i++){
            //check if it's within the angle
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2){
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //fire a laser at the thing, does it hit the thing? or does it hit a wall or smt
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask)){
                  visibleTargets.Add(target);
                }
            }

        }
        return visibleTargets;
    }
    public Vector3 DirectionFromAngle(float angle, bool angleIsGlobal){
        if (!angleIsGlobal) {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)); 
    }

    public Transform[] GetVisibleZombies(){
        return visibleZombies.ToArray();
    }

    public bool ThereAreZombies(){
        return visibleZombies.Count > 0;
    }
}
