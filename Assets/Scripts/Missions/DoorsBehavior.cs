using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehavior : MonoBehaviour
{
    public Animator DoorsAnim;
    public bool DoorPassed = false;    
    public bool CloseDoorControl = false;
    public int ControlQuantChipKeys;

    private void OnTriggerEnter(Collider other)
    {
        if (BomberTime.BomberTimeStart) return;
        if(other.tag == "Player")
        {
            if(other.GetComponent<Player>().ChipKeys >= ControlQuantChipKeys)
            {
                if (other.GetComponent<Player>().ChipKeys - 1 == other.GetComponent<Player>().ChipkeysControl || DoorPassed)
                {

                    DoorsAnim.Play("DoorOpen");
                    if (!DoorPassed)
                    {
                        other.GetComponent<Player>().ChipkeysControl++;
                    }
                    DoorPassed = true;

                }
            }
                      
        }
    }

    private void Update()
    {
        if (CloseDoorControl)
        {
            CloseDoors();
            CloseDoorControl = false;
        }
    }


    public void CloseDoors()
    {
        DoorsAnim.Play("DoorClose");        
    }
}
