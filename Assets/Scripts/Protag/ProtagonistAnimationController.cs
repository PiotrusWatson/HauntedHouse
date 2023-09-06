using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ProtagonistAnimationController : MonoBehaviour
{
    Animator animator;
    int searchParam;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        searchParam = Animator.StringToHash("Search");
    }

    // Update is called once per frame

    public void ToggleIsSearching(bool toggle){
        animator.SetTrigger(searchParam);
    }
}
