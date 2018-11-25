using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera[] cameras = new Camera[2];
    Camera mainCamera, sphereView;
	// Use this for initialization
	void Start () {
        mainCamera = cameras[0];
        sphereView = cameras[1];

        mainCamera.enabled = true;
        sphereView.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.C))
            SwitchView();
	}

    private void SwitchView()
    {
        mainCamera.enabled = !mainCamera.enabled;
        sphereView.enabled = !sphereView.enabled;
    }
}
