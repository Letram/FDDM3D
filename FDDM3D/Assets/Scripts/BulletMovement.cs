using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    [Range(1f, 100f)]
    public float acceleration = 10f;
    public float maxSpeed = 5f;
    public float timeToDestroy = 5f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Time.deltaTime * acceleration))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        Vector3 v = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
        float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(90, rot, 0);
    }
    */
}
