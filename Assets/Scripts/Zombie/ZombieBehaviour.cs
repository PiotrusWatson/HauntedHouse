using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationManager))]
[RequireComponent(typeof(DamageInRadius))]
public class ZombieBehaviour : MonoBehaviour
{
    public GameObject target;
    public float chaseDelay;
    NavigationManager navigationManager;
    DamageInRadius damager;




    // Start is called before the first frame update
    void Awake()
    {
        navigationManager = GetComponent<NavigationManager>();
        damager = GetComponent<DamageInRadius>();
    }

    void Start(){
        StartCoroutine(ChaseWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        damager.Damage();

    }

    IEnumerator ChaseWithDelay(){
        while(true){
            navigationManager.SetDestination(target.transform.position);
            yield return new WaitForSeconds(chaseDelay);
        }
    }
}
