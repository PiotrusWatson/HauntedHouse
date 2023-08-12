using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    float health;
    public UnityEvent Ouch;
    public UnityEvent Ded;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            Ded.Invoke();
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
        
        Ouch.Invoke();
    }
}
