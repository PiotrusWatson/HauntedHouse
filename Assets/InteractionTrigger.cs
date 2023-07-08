using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;



public class InteractionTrigger : MonoBehaviour
{
    public bool protagonistIsClose;

    // Start is called before the first frame update
   // void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && protagonistIsClose)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            protagonistIsClose = true;
            Debug.Log("He's close");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            protagonistIsClose = false;
        }
    }
}
