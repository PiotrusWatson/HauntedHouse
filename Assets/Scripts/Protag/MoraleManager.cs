using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class MoraleManager : MonoBehaviour
{
    HashSet<Spooker> spookLedger;
    public Morale morale;
    public float startingMorale;
    public UnityEvent BrainDed;
    // Start is called before the first frame update
    void Awake()
    {
        spookLedger = new HashSet<Spooker>();
        morale.amount = startingMorale;
    }

    // Update is called once per frame
    void Update() {
        if (morale.amount <= 0) {
            BrainDed.Invoke();
        }
    }

    public void RemoveSpooker(Spooker spooker){
        spookLedger.Remove(spooker);
    }


    public void HandleSpook(Transform[] spooks){
        HashSet<Spooker> currentlySeenSpooks = spooks.Select(spook => spook.GetComponent<Spooker>()).ToHashSet<Spooker>();
        HashSet<Spooker> newSpooks = currentlySeenSpooks.Except(spookLedger).ToHashSet<Spooker>();
        HashSet<Spooker> rejectedSpooks = new HashSet<Spooker>();
        foreach (Spooker spook in newSpooks){
            spook.CollectSpookData(transform.position);
            SubtractMorale(spook);
            if (spook.GetComponent<ZombieBehaviour>() != null){
                //zombie case :)
                rejectedSpooks.Add(spook);
            }
        }
        spookLedger.UnionWith(newSpooks.Except(rejectedSpooks));
        
    }

    public void SubtractMorale(Spooker spook){
        float spookiness = spook.CalculateSpookiness();
        morale.amount -= spookiness;
        Debug.Log("Spookiness is " +spookiness);
    }



    
}
