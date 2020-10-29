using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClose : MonoBehaviour
{
    public GameObject[] Close;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Close")
        {
            for (int i = 0; i < Close.Length; i++)
            {
                Close[i].SetActive(false);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Close")
        {
            for (int i = 0; i < Close.Length; i++)
            {
                Close[i].SetActive(true);
            }
        }
    }
}
