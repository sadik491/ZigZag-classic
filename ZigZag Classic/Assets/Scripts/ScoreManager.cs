using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instence;

    public int score;
    public int highScore;
    public Text scoreUpdateText;


    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
    

    public void IncrementScore()
    {
        score += 1;
        scoreUpdateText.text = score.ToString();
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }




}
