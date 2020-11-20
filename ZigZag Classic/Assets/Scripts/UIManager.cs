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
    public GameObject life;
    public Text score;
    public Text welcomeHighScore;
    public Text gameOverHighScore;
    public GameObject floor;


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
        Destroy(floor, 5f);


    }

    public void Welcome()
    {
        welcomeHighScore.text = PlayerPrefs.GetInt("highScore").ToString();

    }

    public void GameOver()
    {
        scoreUpdate.SetActive(false);
        score.text = PlayerPrefs.GetInt("score").ToString();
        welcomePanel.SetActive(false);
        gameOverHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        playPause.SetActive(false);
        GameManager.instence.gameOver = true;
        Invoke("LateShowVideo", .5f);
    }

    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Life()
    {
        life.SetActive(true);
    }
    public void LifeButton()
    {
        life.SetActive(true);
    }
    public void NoThanks()
    {
        Time.timeScale = 1;
        life.SetActive(false);
        GameOver();
        
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
