using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMaterialWatcher : MonoBehaviour
{
    Material parentMaterial;
    // Start is called before the first frame update
    void Start()
    {
        parentMaterial = GetComponentInParent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material = parentMaterial;

        Debug.Log(parentMaterial.name);
    }
}
