using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMeWhenUrDone : MonoBehaviour
{

    public float countdownTimer;
    public float timerIncrement = 1f;
    public FinishSpookingEvent spookOver;

    IEnumerator CountdownUntilFinish(){
        for (float timer = 0f; timer < countdownTimer; timer+=timerIncrement){
            yield return new WaitForSeconds(timerIncrement);
        }
        spookOver.Invoke(gameObject);
    }
    // Start is called before the first frame update
    public void StartTheCountdown(){
        StartCoroutine(CountdownUntilFinish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
