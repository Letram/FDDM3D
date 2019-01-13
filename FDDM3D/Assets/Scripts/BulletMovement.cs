using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    [Range(1f, 100f)]
    public float acceleration = 10f;
    public float maxSpeed = 5f;
    public float timeToDestroy = 5f;
    private int strength;
    //private bool forceAdded = false;
	// Use this for initialization
	void Start () {
        strength = 0;
        Destroy(gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (!forceAdded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10000, ForceMode.Impulse);
            forceAdded = !forceAdded;
        }       
        */
        transform.Translate(Vector3.forward * acceleration * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //there's a hit
        if(Physics.Raycast(ray, out hit, Time.deltaTime * acceleration))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            if (hit.collider.CompareTag("Obstacle")) {
                strength++;
                EventManager.pubGainStrength(strength);
            }
            else if (hit.collider.CompareTag("Limit") || hit.collider.CompareTag("Wall") && strength < GameObject.Find("GameManager").GetComponent<GameController>().getWallHealth()) Destroy(gameObject);
            else if (hit.collider.CompareTag("Wall") && strength >= GameObject.Find("GameManager").GetComponent<GameController>().getWallHealth()) Destroy(hit.collider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit")) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.pubBulletDestroyed();
    }
}
