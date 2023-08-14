using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    MultipleAudioManager multipleAudioManager;
    public AudioClip brackabracka;
    public float damage;
    public GameObject muzzleFlash;
    public GameObject bulletEffect;
    //play animation
    Animator animator;
    AudioSource source;
    public bool DebugBang;
    public float amountToStayUp;
    

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        multipleAudioManager = GetComponentInChildren<MultipleAudioManager>();
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
        multipleAudioManager.Play(brackabracka);
        muzzleFlash.SetActive(true);
        StartCoroutine(StopFlash());
        Instantiate(bulletEffect, muzzleFlash.transform.position, transform.rotation);
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit);
        
        Health health = hit.collider.GetComponent<Health>();
        Debug.DrawLine(transform.position, hit.collider.transform.position);
        if (isHit && health){
            health.TakeDamage(damage);
        }

    }
    IEnumerator StopFlash(){
        yield return new WaitForSeconds(amountToStayUp);
        muzzleFlash.SetActive(false);
    }
}
