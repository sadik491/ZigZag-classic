using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instence;

    public bool gameOver;

    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }
    void Start()
    {
        gameOver = false;
    }

    public void StartGame()
    {
        UIManager.instence.GameStart();
        ScoreManager.instence.StartScore();
    }

    public void GameOver()
    {
        UIManager.instence.GameOver();
        ScoreManager.instence.StopScore();
    }
}
