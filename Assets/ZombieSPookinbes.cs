using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spooker))]
public class ZombieSPookinbes : MonoBehaviour
{
    Spooker spooker;
    // Start is called before the first frame update
    void Start()
    {
        spooker = GetComponent<Spooker>();
        spooker.ToggleSpook(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
