using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    public GameObject muzzleFlash;
    //play animation
    Animator animator;
    public bool DebugBang;
    public float amountToStayUp;
    

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DebugBang){
            Fire();
            DebugBang = false;
        }
    }
    //play animation
    public void Fire(){
        animator.SetTrigger("BangBang");
        muzzleFlash.SetActive(true);
        StartCoroutine(StopFlash());

    }
    IEnumerator StopFlash(){
        yield return new WaitForSeconds(amountToStayUp);
        muzzleFlash.SetActive(false);
    }
}
