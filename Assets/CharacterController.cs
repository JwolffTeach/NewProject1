using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    
    public Transform to;
    public float speed = 10f;
    public float gameTime=0f;
    public float startTime;
    public bool ismoving = false;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        gameTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.Slerp(transform.position, to.position, speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, to.rotation, speed);
	}

    void FixedUpdate() {
        gameTime = Time.time;
        //Debug.Log(gameTime);
        if (gameTime-startTime >= 3 && ismoving == false) {
            StartCoroutine(moveGoal(to));
            ismoving = true;
        }
    }

    IEnumerator moveGoal (Transform target) {
        while (Vector3.Distance(transform.position, target.position) > 0.05f) {
            transform.position = Vector3.Lerp(transform.position, target.position, speed);

            yield return null;
        }

        print("Reached the target.");

        yield return new WaitForSeconds(3f);

        print("MyCoroutine is now finished.");
        ismoving = false;
        startTime = Time.time;
    }
}
