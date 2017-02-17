using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // place this at the top of your file
    }
    // then call this to restart game
    public void hardRestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} 