using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInRadius : MonoBehaviour
{
    Health thingToTrack;
    public string tagToTarget;
    public Morale damage;

    // Start is called before the first frame update
    void Awake()
    {
        
    }


    void OnTriggerEnter(Collider collider){
        Health hopefullyPerson = collider.GetComponent<Health>();
        if (hopefullyPerson && collider.CompareTag(tagToTarget)){
            thingToTrack = hopefullyPerson;
        }
    }

    void OnTriggerExit(Collider collider){
        if (!thingToTrack){
            return;
        }
        if (collider.gameObject.Equals(thingToTrack.gameObject)){
            thingToTrack = null;
        }
    }

    public void Damage(){
        if (thingToTrack){
            thingToTrack.TakeDamage(damage.amount);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
