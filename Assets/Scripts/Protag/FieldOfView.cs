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
    public SeeingEvent IsawANewThing;
    



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
            FindVisibleTargets();
            List<Transform> zombies = new List<Transform>();
            List<Transform> finalList = new List<Transform>();
            foreach (Transform target in visibleTargets)
            {
                if (target.GetComponent<ZombieBehaviour>() != null)
                {
                    zombies.Add(target);
                }
            }
            bool seenNewThing = GuyHasSeenNewThing(lastCheckedTargets, visibleTargets);
            if (seenNewThing)
            {
                finalList.AddRange(visibleTargets);
            }
            if (zombies.Count > 0)
            {
                finalList.AddRange(zombies);
            }

            if (seenNewThing || zombies.Count > 0)
            {
                IsawANewThing.Invoke(finalList.ToArray());

            }
        }
    }
    
    bool GuyHasSeenNewThing(List<Transform> currentlyVisible, List<Transform> newlyVisible){
        return newlyVisible.Except(currentlyVisible).ToList().Count > 0;
    }
    void FindVisibleTargets(){
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i=0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2){
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

              //  if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask)){
                  visibleTargets.Add(target);
               // }
            }

        }
    }
    public Vector3 DirectionFromAngle(float angle, bool angleIsGlobal){
        if (!angleIsGlobal) {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)); 
    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
