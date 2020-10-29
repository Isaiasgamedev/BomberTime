using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRotate : MonoBehaviour
{
    public GameObject RotateControl;
    public static bool SwitchControl;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Explosion")
        {
            if (SwitchControl) return;
            if(RotateControl.GetComponent<RotateSector>().LastRotation == 4)
            {
                RotateControl.GetComponent<RotateSector>().RotationChoice = RotateSector.RotationState.first;
            }

            if (RotateControl.GetComponent<RotateSector>().LastRotation == 1)
            {
                RotateControl.GetComponent<RotateSector>().RotationChoice = RotateSector.RotationState.second;
            }

            if (RotateControl.GetComponent<RotateSector>().LastRotation == 2)
            {
                RotateControl.GetComponent<RotateSector>().RotationChoice = RotateSector.RotationState.third;
            }

            if (RotateControl.GetComponent<RotateSector>().LastRotation == 3)
            {
                RotateControl.GetComponent<RotateSector>().RotationChoice = RotateSector.RotationState.fourt;
            }


        }
    }
}
