using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTime : MonoBehaviour
{
    public float RotateVelocity;

 
    void Update()
    {
        transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            Debug.Log("BOMBA");
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
