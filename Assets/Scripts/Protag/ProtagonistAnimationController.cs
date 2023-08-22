using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ProtagonistAnimationController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void ToggleIsSearching(bool toggle){
        animator.SetBool("IsSearch", toggle);
        Debug.Log("IsSearch IS NOW: " + toggle);
    }
}
