using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour
{
    string gameId = "3486957";
    //bool testMode = false;
    public static UnityAdManager instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Advertisement.Initialize(gameId);
        
    }

    void Update()
    {
        
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }
}
