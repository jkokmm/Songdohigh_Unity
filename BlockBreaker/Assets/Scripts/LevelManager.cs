using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public GameObject templateBlock;
    public int numBlocks = 0;

    // Use this for initialization
    void Start () {
        CreateBlocks(1);
	}

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(0, 0, 200, 200),
            numBlocks.ToString() + "개 블럭이 남았습니다", style);
    }

    public void BlockDestroyed()
    {
        Debug.Log("BlockDestroyed called");

        numBlocks--;

        if (numBlocks <= 0)
            SceneManager.LoadScene("Win");
    }

    void CreateBlocks(int level)
    {
        for (int c = 0; c < 8; c++)
            for (int r = 0; r < 3; r++)
            {
                GameObject obj = Instantiate(templateBlock, new Vector3(c * 1f - 3.5f,
                                                                        -r + 4.5f), Quaternion.identity);
                numBlocks++;
            }
    }
}
