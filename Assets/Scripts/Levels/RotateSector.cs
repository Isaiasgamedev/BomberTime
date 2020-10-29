using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSector : MonoBehaviour
{
    public float RotateVelocity;
    public float[] FinalRotation;
    public int LastRotation;
    public bool RotationControl;
    public enum RotationState {first, second, third, fourt, wait}
    public RotationState RotationChoice;
  
    
    void Update()
    {
        ManagerRotation();      
    }

    public void ManagerRotation()
    {
       
        switch (RotationChoice)
        {
            case RotationState.first:

                SwitchRotate.SwitchControl = true;

                transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);

                if (transform.eulerAngles.y > FinalRotation[0])
                {
                    LastRotation = 1;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, FinalRotation[0] + 1, transform.eulerAngles.z);
                    RotationChoice = RotationState.wait;
                    SwitchRotate.SwitchControl = false;
                }
               

               

            break;

            case RotationState.second:
                SwitchRotate.SwitchControl = true;

                transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);

                if (transform.eulerAngles.y > FinalRotation[1])
                {
                    LastRotation = 2;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, FinalRotation[1] + 1, transform.eulerAngles.z);
                    RotationChoice = RotationState.wait;
                    SwitchRotate.SwitchControl = false;
                }
               

               

            break;

            case RotationState.third:
                SwitchRotate.SwitchControl = true;

                transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);

                if (transform.eulerAngles.y > FinalRotation[2])
                {
                    LastRotation = 3;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, FinalRotation[2] + 1, transform.eulerAngles.z);
                    RotationChoice = RotationState.wait;
                    SwitchRotate.SwitchControl = false;
                }
                

               

            break;

            case RotationState.fourt:
                SwitchRotate.SwitchControl = true;

                transform.Rotate(transform.rotation.x, RotateVelocity * Time.deltaTime, transform.rotation.z);

                if (transform.eulerAngles.y > FinalRotation[3])
                {
                    LastRotation = 4;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, FinalRotation[3] + 1, transform.eulerAngles.z);
                    RotationChoice = RotationState.wait;
                    SwitchRotate.SwitchControl = false;
                }              

               

            break;
        }
        
    }
        
    
}
