using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

    public Vector2 limitx;
    public Vector2 limity;

    private void Start()
    {
        //min - max
        limitx = new Vector2(-5, 5);
        limity = new Vector2(0.5f, 5);
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Mathf.Clamp(objectPos.x, limitx[0], limitx[1]), Mathf.Clamp(objectPos.y, limity[0], limity[1]), transform.position.z);
    }
}
