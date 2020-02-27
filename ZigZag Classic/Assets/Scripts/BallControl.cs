using UnityEngine;


public class BallControl : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    bool gameOver;
    bool started;
    public GameObject partical;

    void Start()
    {
        started = false;
        gameOver = false;
        UIManager.instence.Welcome();
    }

   
    void Update()
    {
        

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Camera.main.GetComponent<FollowCam>().gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            GameManager.instence.GameOver();
        }

        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!started)
            {
                rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
                started = true;
                GameManager.instence.StartGame();
            }

            if (touch.phase == TouchPhase.Began && !gameOver)
            {

                SwitchDirection();
            }

        }
        

        



    }

    private void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Daimond")
        {
            GameObject part = Instantiate(partical, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
