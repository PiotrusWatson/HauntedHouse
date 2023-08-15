using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationManager))]
[RequireComponent(typeof(DamageInRadius))]
public class ZombieBehaviour : MonoBehaviour
{
    public GameObject target;
    NavigationManager navigationManager;
    DamageInRadius damager;

    // Start is called before the first frame update
    void Awake()
    {
        navigationManager = GetComponent<NavigationManager>();
        damager = GetComponent<DamageInRadius>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationManager.SetDestination(target.transform.position);
        damager.Damage();

    }
}
