using UnityEngine;
using UnityEngine.EventSystems;


public class BallControl : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    bool gameOver;
    bool started;
    public GameObject partical;
    public AudioSource audioSource;

    public AudioClip breakSound;
    public bool soundButton;

    public GameObject Sound;
    public static BallControl instence;




    void Awake()
    {
        if (instence == null)
        {
            instence = this;
        }
    }

    void Start()
    {
        started = false;
        soundButton = true;
        UIManager.instence.Welcome();
        GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value); ;
        
    }

   
    void Update()
    {

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            //Time.timeScale = 0;
            gameOver = true;
            Camera.main.GetComponent<FollowCam>().gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            GameManager.instence.GameOver();
        }
        
        touchControl();

    }
    public void touchControl()
    {
        if (Input.touchCount > 0)
        {
            //Touch touch = Input.GetTouch(0);

            foreach ( Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    return;
                }
                else
                {
                    
                    if (!started)
                    {
                        rb.velocity = new Vector3(0, 0, speed);
                        started = true;
                        GameManager.instence.StartGame();
                    }
                    if (touch.phase == TouchPhase.Began && !gameOver)
                    {
                        SwitchDirection();
                    }
                }

                
            }

        }
    }
    private void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    
    public void SoundOn(bool isOn)
    {
        soundButton = isOn;

        if (isOn == true)
        {
            audioSource.enabled = true;
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            audioSource.enabled = false;
            PlayerPrefs.SetInt("sound", 0);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Daimond")
        {


            if (soundButton == true)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            }
            
            GameObject part = Instantiate(partical, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
