using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public int maxHits = 3;
    public int hitCounter = 0;
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (++hitCounter >= maxHits)
            Destroy(gameObject);

        if (hitCounter == 1)
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

        else if (hitCounter == 2)
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
