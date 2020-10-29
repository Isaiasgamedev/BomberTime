using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceControl : MonoBehaviour
{
    public GameObject Follows;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Follows.GetComponent<Follow>().ControlFollow = Follow.StateFollow.Follow;
        }
    }  


    private void OnTriggerExit(Collider other)
    {
        if (!Follows.GetComponent<Follow>().CanFollow) return;
        if (other.tag == "Player")
        {            
            Follows.GetComponent<Follow>().ControlFollow = Follow.StateFollow.Wait;
        }
    }
}
