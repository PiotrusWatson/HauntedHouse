using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainRotation : MonoBehaviour
{
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = originalRotation;
    }
}
