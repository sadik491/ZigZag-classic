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
        scoreUpdate.SetActive(true);

    }

    public void Welcome()
    {
        welcomeHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
        
    }

    public void GameOver()
    {
        scoreUpdate.SetActive(false);
        score.text = PlayerPrefs.GetInt("score").ToString();
        
        gameOverHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        Invoke("LateShowRewardedVideo", 2f);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void LateShowRewardedVideo()
    {
        UnityAdManager.instance.ShowRewardedVideoAd();
    }
}
