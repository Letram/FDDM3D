using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int wallHealth;
	// Use this for initialization
	void Start () {
        wallHealth = 2;
	}
	
    public int getWallHealth()
    {
        return wallHealth;
    }
}
