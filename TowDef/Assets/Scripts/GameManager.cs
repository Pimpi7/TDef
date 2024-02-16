using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    // Update is called once per frame
    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
            return;
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level won");
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
