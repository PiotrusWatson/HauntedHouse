using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //REALLY HACKY WE GOTTA USE OBJECT POOLING WHEN WE WANT THGE GAME NOT TO RUN LIKE SHIT
    public float timeUntilDeath;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySoon());
    }

    // Update is called once per frame
    IEnumerator DestroySoon(){
        yield return new WaitForSeconds(timeUntilDeath);
        Destroy(gameObject);
    }
}
