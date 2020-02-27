using UnityEngine;

public class FloorCreator : MonoBehaviour
{
    public Transform floor;
    public Transform diamond;

    Vector3 lastPosition;
    float size;
    void Start()
    {
        
        lastPosition = transform.position;
        size = transform.localScale.x;

        for (int i = 0; i < 15; i++)
        {
            RandomFloor();
        }

        InvokeRepeating("RandomFloor", 2f, .2f);
    }

    void Update()
    {
        if (Camera.main.GetComponent<FollowCam>().gameOver)
        {
            CancelInvoke("RandomFloor");
        }
    }

    void RandomFloor()
    {
        int rand = Random.Range(0, 6);
        if (rand > 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
           
        
    }

    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;
        Instantiate(floor, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand > 2 )
        {
            Instantiate(diamond,  new Vector3 (pos.x, pos.y + 1, pos.z),  diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;
        Instantiate(floor, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand > 2)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}
