using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(1,10)]
    public int rotationSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float xAxis = Input.GetAxisRaw("Vertical")*rotationSpeed*Time.deltaTime;
        float yAxis = Input.GetAxisRaw("Horizontal")*rotationSpeed*Time.deltaTime;
        transform.Rotate(xAxis, yAxis, 0, Space.Self);

        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.rotation = q;

        if (Input.GetKeyUp(KeyCode.R))
            transform.rotation = Quaternion.identity;
	}
}