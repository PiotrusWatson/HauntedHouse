using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class MoraleBar : MonoBehaviour
{
    UIDocument doc;
    ProgressBar bar;
    public Morale morale;

    public float delayInUpdate;

    IEnumerator UpdateHealth(float delay){
        while (true){
            yield return new WaitForSeconds(delay);
            bar.value = morale.amount;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        doc = GetComponent<UIDocument>();
        bar = doc.rootVisualElement.Query<ProgressBar>("MoraleBar");
        bar.highValue = morale.amount;
        StartCoroutine(UpdateHealth(delayInUpdate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
