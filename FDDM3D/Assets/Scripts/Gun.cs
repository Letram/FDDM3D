using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bullet;
    public float fireRate = 1;
    public int ammo = 5;
    public float secondsToDestroy = 4f;
    private float lastShot = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
            Fire();
	}

    private void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(bullet, transform.position, transform.parent.rotation);
            lastShot = Time.time;
        }
    }
}