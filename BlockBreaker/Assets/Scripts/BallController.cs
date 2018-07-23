using UnityEngine;

public class BallController : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
    }
}
