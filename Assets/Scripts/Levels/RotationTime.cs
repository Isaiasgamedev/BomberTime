using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTime : MonoBehaviour
{
    public float RotateVelocity;
    Vector3 kickBomb;


    void Update()
    {
        transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);
        kickBomb = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {  
            if(other.GetComponent<Rigidbody>() != null)
            {
                other.GetComponent<Rigidbody>().isKinematic = false;
                other.GetComponent<Rigidbody>().AddForce(kickBomb * 2, ForceMode.Impulse);
            }
            
            
        }
    }
}
