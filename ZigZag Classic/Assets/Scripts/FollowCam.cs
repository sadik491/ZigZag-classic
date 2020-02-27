using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset;
    public bool gameOver;
    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if (!gameOver)
        {
            transform.position = ball.transform.position + offset;
        }
        
    }
}
