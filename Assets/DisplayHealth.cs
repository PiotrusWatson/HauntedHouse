using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Health healthScript;
    Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = healthScript.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthScript.GetHealth();
    }
}
