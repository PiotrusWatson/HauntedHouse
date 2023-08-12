using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraChanger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
