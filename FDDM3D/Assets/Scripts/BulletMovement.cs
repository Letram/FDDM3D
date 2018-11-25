using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    [Range(1f, 100f)]
    public float speed = 10f;
    public float timeToDestroy = 5f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}
}
