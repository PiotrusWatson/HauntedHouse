using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MoraleManager : MonoBehaviour
{
    HashSet<Spooker> spookLedger;
    public Morale morale;
    // Start is called before the first frame update
    void Awake()
    {
        spookLedger = new HashSet<Spooker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveSpooker(Spooker spooker){
        spookLedger.Remove(spooker);
    }


    public void HandleSpook(Transform[] spooks){
        HashSet<Spooker> currentlySeenSpooks = spooks.Select(spook => spook.GetComponent<Spooker>()).ToHashSet<Spooker>();
        HashSet<Spooker> newSpooks = currentlySeenSpooks.Except(spookLedger).ToHashSet<Spooker>();
        foreach (Spooker spook in newSpooks){
            spook.CollectSpookData(transform.position);
            SubtractMorale(spook);
        }
        spookLedger.UnionWith(newSpooks);
        
    }

    public void SubtractMorale(Spooker spook){
        morale.amount -= spook.CalculateSpookiness();
        Debug.Log("New morale is " + morale.amount);
    }



    
}
