using UnityEngine;

public class BlockController : MonoBehaviour {
    public int maxHits = 3;
    public int hitCounter = 0;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (++hitCounter >= maxHits)
        {
            Destroy(gameObject);
            GameObject.Find("LevelManager").GetComponent<LevelManager>().BlockDestroyed();
        }

        if (hitCounter == 1)
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

        else if (hitCounter == 2)
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
