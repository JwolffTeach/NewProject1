using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowMouse : MonoBehaviour {

    private Vector3 _target;
    public Camera Camera;
    public bool FollowtheMouse;
    public bool ParticlesAccelerates;
    public float ParticlesSpeed = 2.0f;


	// Use this for initialization
	void Start () {
        
	}

    public void OnEnable() {
        if (Camera == null) {
            throw new InvalidOperationException("Camera not set");
        }
    }

	// Update is called once per frame
	void Update () {
		if (FollowtheMouse || Input.GetMouseButton(0)) {
            Debug.Log(Camera.ScreenToWorldPoint(Input.mousePosition));
        }
        _target = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 2f, 1.35f));
        _target.y = 0;

        var delta = ParticlesSpeed * Time.deltaTime;
        if (ParticlesAccelerates) {
            delta *= Vector3.Distance(transform.position, _target);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, delta);
	}
}
