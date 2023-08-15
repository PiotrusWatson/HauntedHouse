using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//TODO REFACTOR LOL THIS IS IDENTICAL TO MORALEBAR
public class HealthBar : MonoBehaviour
{
    UIDocument doc;
    ProgressBar bar;
    public Health health;

    public float delayInUpdate;
    // Start is called before the first frame update
    void Awake()
    {
        doc = GetComponent<UIDocument>();
        bar = doc.rootVisualElement.Query<ProgressBar>("HealthBar");
    }

    void Start(){
        bar.highValue = health.maxHealth;
        StartCoroutine(UpdateHealth(delayInUpdate));
    }

    IEnumerator UpdateHealth(float delay){
        while (true){
            yield return new WaitForSeconds(delay);
            bar.value = health.GetHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
