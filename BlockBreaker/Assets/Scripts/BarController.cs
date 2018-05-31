using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {

    public bool autoPlay = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (autoPlay)
            transform.position = new Vector3(FindObjectOfType<BallController>().transform.position.x, transform.position.y, transform.position.z);
    }
}
