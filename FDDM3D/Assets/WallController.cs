using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public int wallHealth = 2;
    public Material vulnerable;
    public Material invulnerable;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        EventManager.onGainStrength += canChangeColor;
        EventManager.onBulletDestroyed += canChangeColor;
    }

    private void OnDisable()
    {
        EventManager.onGainStrength -= canChangeColor;
        EventManager.onBulletDestroyed -= canChangeColor;

    }

    private void canChangeColor(int strength)
    {
        GetComponent<Renderer>().material = wallHealth <= strength ? vulnerable : invulnerable;
    }
    private void canChangeColor()
    {
        GetComponent<Renderer>().material = invulnerable;
    }
}
