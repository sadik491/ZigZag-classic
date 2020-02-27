using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", .2f);
        }
    }

    private void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }

    
}
