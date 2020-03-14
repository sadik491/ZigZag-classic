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
        GameObject.Find("FloorCreate").GetComponent<FloorCreator>().StartRandomFloor();
    }

    public void GameOver()
    {
        
        ScoreManager.instence.StopScore();
        UIManager.instence.GameOver();
       // UIManager.instence.Life();
        gameOver = true;

    }

    public void playPause(bool isPlay)
    {
        if (isPlay == true)
        {
            Time.timeScale = 1; 
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void CheckInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //No internet
            
        }
        else
        {
            //internet

           
            
        }
    }

}
