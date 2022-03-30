﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This is not a functional weapon script. It just shows how to implement shooting and reloading with buttons system.
/// </summary>
public class WeaponExample : MonoBehaviour
{
    public FP_Input playerInput;

    public float shootRate = 0.15F;
    public float reloadTime = 1.0F;
    public int ammoCount = 15;
    public float projectileSpeed = 1;
    public int damage = 1;

    public GameObject projectile;

    private int ammo;
    private float delay;
    private bool reloading;

    void Start()
    {
        ammo = ammoCount;

        if (projectile == null)
        {
            projectile = Resources.Load<GameObject>("Prefabs/Projectile");
        }
    }

    void Update()
    {
        if (playerInput.Shoot())                         //IF SHOOT BUTTON IS PRESSED (Replace your mouse input)
            if (Time.time > delay)
                Shoot();

        if (playerInput.Reload())                        //IF RELOAD BUTTON WAS PRESSED (Replace your keyboard input)
            if (!reloading && ammoCount < ammo)
                StartCoroutine("Reload");
    }

    void Shoot()
    {
        if (ammoCount > 0)
        {
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = transform.rotation;
            newProjectile.GetComponent<ProjectileBehavior>().Speed = projectileSpeed;
            newProjectile.GetComponent<ProjectileBehavior>().Damage = damage;
            newProjectile.layer = 11;

            Debug.Log("Shoot");
            ammoCount--;
        }
        else
            Debug.Log("Empty");

        delay = Time.time + shootRate;
    }

    IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        ammoCount = ammo;
        Debug.Log("Reloading Complete");
        reloading = false;
    }

    void OnGUI()
    {
        GUILayout.Label("AMMO: " + ammoCount);
    }
}
