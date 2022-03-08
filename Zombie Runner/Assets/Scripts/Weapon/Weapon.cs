using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float shootDelay = .2f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    bool youCanshoot = true;
    float destroyTime = .1f;

    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && youCanshoot == true)
        {
          StartCoroutine(Shoot());
            Debug.Log("Weapon Fired!");
        }
        DisplayAmmo();
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.AmountOfAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    private void OnEnable()
    {
        youCanshoot = true;

    }
   IEnumerator Shoot()
    {
        youCanshoot = false;
        if (ammoSlot.AmountOfAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            WeaponSound();
            ammoSlot.AmmoReducer(ammoType);
           
        }
        yield return new WaitForSeconds(shootDelay);
        youCanshoot = true;
    }


    private void PlayMuzzleFlash()
    {
          muzzleFlash.Play();        
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.collider != null)
        {
           GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, destroyTime);
        }
    }
    void WeaponSound()
    {
        if(ammoType == AmmoType.bullets)
        {
            FindObjectOfType<AudioManager>().Play("Pistol", false);
            Debug.Log("strzelilem");
        }
        if (ammoType == AmmoType.shells)
        {
            FindObjectOfType<AudioManager>().Play("Shotgun", false);
            Debug.Log("strzelilem");
        }
        if (ammoType == AmmoType.rockets)
        {
            FindObjectOfType<AudioManager>().Play("Sniper", false);
            Debug.Log("strzelilem");
        }
    }
}
