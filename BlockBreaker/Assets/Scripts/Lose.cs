﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class Lose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Lose");
    }
}