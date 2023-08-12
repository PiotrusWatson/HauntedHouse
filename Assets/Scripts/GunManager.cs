using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    public float damage;
    public GameObject muzzleFlash;
    public GameObject bulletEffect;
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
        Instantiate(bulletEffect, muzzleFlash.transform.position, transform.rotation);
        RaycastHit hit;
        Physics.Raycast(muzzleFlash.transform.position, transform.forward, out hit);
        Health health = hit.collider.GetComponent<Health>();
        if (health){
            health.TakeDamage(damage);
        }

    }
    IEnumerator StopFlash(){
        yield return new WaitForSeconds(amountToStayUp);
        muzzleFlash.SetActive(false);
    }
}
