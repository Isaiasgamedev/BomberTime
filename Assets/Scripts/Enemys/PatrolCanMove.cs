using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCanMove : MonoBehaviour
{
 

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Patrol.CanMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Patrol.CanMove = false;
        }
    }
}
