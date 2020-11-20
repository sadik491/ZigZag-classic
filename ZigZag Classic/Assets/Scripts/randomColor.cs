using UnityEngine;

public class randomColor : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value, Random.value); ;
    }

    
}
