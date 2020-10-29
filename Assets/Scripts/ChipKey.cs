using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player")
        {
            other.GetComponent<Player>().ChipKeys++;
            Destroy(gameObject);
        }
    }
}
