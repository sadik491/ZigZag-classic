using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instence;

    public GameObject welcomePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject scoreUpdate;
    public GameObject playPause;
    public Text score;
    public Text welcomeHighScore;
    public Text gameOverHighScore;


    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        welcomePanel.GetComponent<Animator>().Play("WelcomePanal");
        
        Invoke("LateScoreShow", 1f);
        

    }

    public void Welcome()
    {
        welcomeHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
        //Invoke("LateShowVideo", 10f);

    }

    public void GameOver()
    {
        scoreUpdate.SetActive(false);
        score.text = PlayerPrefs.GetInt("score").ToString();
        welcomePanel.SetActive(false);
        gameOverHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        //Invoke("LateShowVideo", 1f);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void LateShowRewardedVideo()
    {
        UnityAdManager.instance.ShowRewardedVideoAd();
    }

    public void LateShowVideo()
    {
        UnityAdManager.instance.ShowVideoAd();
    }

    public void LateScoreShow()
    {
        scoreUpdate.SetActive(true);
        playPause.SetActive(true);
    }

}
