using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationManager))]
public class ZombieBehaviour : MonoBehaviour
{
    public GameObject target;
    NavigationManager navigationManager;

    // Start is called before the first frame update
    void Awake()
    {
        navigationManager = GetComponent<NavigationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationManager.SetDestination(target.transform.position);
    }
}
