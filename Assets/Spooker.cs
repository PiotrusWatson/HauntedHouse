using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spooker : MonoBehaviour
{
    int SPOOKY_LAYER = 9;
    public Spook spook;

    float spookDecayTime = 30f;
    Vector3 positionAtTimeOfSpook;

    float distanceOfSpook;
    MoraleManager spookLedger;
    IEnumerator SpookTimer(){
        while (spookDecayTime > 0){
            yield return new WaitForSeconds(1);
            spookDecayTime -= 1;
        }
        spookLedger.RemoveSpooker(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        spookLedger = GameObject.FindGameObjectWithTag("Player").GetComponent<MoraleManager>();
        //gameObject.layer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleSpook(bool isSpooky){
        if (!isSpooky){
            gameObject.layer = 0;
        }
        else {
            gameObject.layer = SPOOKY_LAYER;
        }
    }
    public void CollectSpookData(Vector3 playerPosition)
    {
        positionAtTimeOfSpook = transform.position;
        distanceOfSpook = Vector3.Distance(transform.position, playerPosition);
    }


// spookiness
// spook cap
// distance
    public float CalculateSpookiness(){
        float spookCalculation;
        if (spook.isSubtle){
            spookCalculation = spook.spookiness * Mathf.Log10(distanceOfSpook);
            return Mathf.Clamp(spookCalculation, 0, spook.spookCap);
        }
        else {
            spookCalculation = spook.spookiness * 1/distanceOfSpook;
            return Mathf.Clamp(spookCalculation, 0, spook.spookCap);
        }
    }
}
