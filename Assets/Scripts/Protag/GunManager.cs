using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float fireDelay;
    public float bulletsPerBurst;
    

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
        if (isHit && health){
            health.TakeDamage(damage);
        }

    }
    IEnumerator StopFlash(){
        yield return new WaitForSeconds(amountToStayUp);
        muzzleFlash.SetActive(false);
    }

    IEnumerator FireBurst(){
        for (int i = 0; i < bulletsPerBurst; i++){
            yield return new WaitForSeconds(fireDelay);
            Fire();
        }
    }

    public void FireBullets(){
        StartCoroutine(FireBurst());
    }
}
