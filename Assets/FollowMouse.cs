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
            _target = Camera.ScreenToWorldPoint(Input.mousePosition);
            _target.z = 0;
        }

        var delta = ParticlesSpeed * Time.deltaTime;
        if (ParticlesAccelerates) {
            delta *= Vector3.Distance(transform.position, _target);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, delta);
	}
}
