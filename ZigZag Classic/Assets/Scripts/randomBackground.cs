using UnityEngine;

public class randomBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().backgroundColor = new Color(Random.value, Random.value, Random.value, Random.value ); ;
    }

    
}
