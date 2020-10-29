using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Vector3 PunchSide;  
    
    float HorizontalPosition;
    float VerticalPosition;
    float ControlPosition;
    float SaveWaitPunch;
    public int ControlPunch = 0;
    public float WaitPunch = 0;
    public float PunchStart;
    public enum Direction {Left, Right, Up, Down};
    public Direction DirectionControl;  




    private void Start()
    {
        SaveWaitPunch = WaitPunch;
        HorizontalPosition = transform.position.x;
        VerticalPosition = transform.position.z;
        // Debug.Log("LEFT  =  " + LeftPosition);
    }

    private void Update()
    {
        //Debug.Log("LEFT  =  " + ControlPosition);        
        
        PunchStart -= Time.deltaTime;
        if (PunchStart <= 0)
        {
            switch (DirectionControl)
            {
                case Direction.Right:
                    PunchSide = new Vector3(1, 0, 0);
                    ControlPosition = transform.position.x;
                    _PunchActionRight();
                    PunchStart = 0;

                    break;

                case Direction.Left:
                    PunchSide = new Vector3(1, 0, 0);
                    ControlPosition = transform.position.x;
                    _PunchActionLeft();
                    PunchStart = 0;

                    break;

                case Direction.Up:
                    PunchSide = new Vector3(0, 0, 1);
                    ControlPosition = transform.position.z;
                    _PunchActionUp();
                    PunchStart = 0;

                    break;

                case Direction.Down:
                    PunchSide = new Vector3(0, 0, 1);
                    ControlPosition = transform.position.z;
                    _PunchActionDown();
                    PunchStart = 0;

                    break;
            }
        }
    }


    public void _PunchActionRight()
    {
        if (ControlPunch == 0)
        {
            
            transform.Translate(PunchSide * (Time.deltaTime * 5f));           
            if (ControlPosition >= HorizontalPosition + 2)
            {
                ControlPunch = 1;
            }

        }

        if (ControlPunch == 1)
        {
            
            transform.Translate(-PunchSide * (Time.deltaTime * 5f));            
            if (ControlPosition <= HorizontalPosition)
            {                
                ControlPunch = 2;
                transform.position = new Vector3(HorizontalPosition, transform.position.y, transform.position.z);
            }            

        }


        if (ControlPunch == 2)
        {
            WaitPunch -= Time.deltaTime;
            if (WaitPunch <= 0)
            {
                WaitPunch = SaveWaitPunch;
                ControlPunch = 0;
            }
        }
    }


    public void _PunchActionLeft()
    {
        if (ControlPunch == 0)
        {

            transform.Translate(-PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition <= HorizontalPosition - 2)
            {
                ControlPunch = 1;
            }

        }

        if (ControlPunch == 1)
        {

            transform.Translate(PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition >= HorizontalPosition)
            {
                ControlPunch = 2;
                transform.position = new Vector3(HorizontalPosition, transform.position.y, transform.position.z);
            }

        }


        if (ControlPunch == 2)
        {
            WaitPunch -= Time.deltaTime;
            if (WaitPunch <= 0)
            {
                WaitPunch = SaveWaitPunch;
                ControlPunch = 0;
            }
        }
    }

    public void _PunchActionUp()
    {
        if (ControlPunch == 0)
        {

            transform.Translate(PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition >= VerticalPosition + 2)
            {
                ControlPunch = 1;
            }

        }

        if (ControlPunch == 1)
        {

            transform.Translate(-PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition <= VerticalPosition)
            {
                ControlPunch = 2;
                transform.position = new Vector3(transform.position.x, transform.position.y, VerticalPosition);
            }

        }


        if (ControlPunch == 2)
        {
            WaitPunch -= Time.deltaTime;
            if (WaitPunch <= 0)
            {
                WaitPunch = SaveWaitPunch;
                ControlPunch = 0;
            }
        }
    }

    public void _PunchActionDown()
    {
        if (ControlPunch == 0)
        {

            transform.Translate(-PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition <= VerticalPosition - 2)
            {
                ControlPunch = 1;
            }

        }

        if (ControlPunch == 1)
        {

            transform.Translate(PunchSide * (Time.deltaTime * 5f));
            if (ControlPosition >= VerticalPosition)
            {
                ControlPunch = 2;
                transform.position = new Vector3(transform.position.x, transform.position.y, VerticalPosition);
            }

        }


        if (ControlPunch == 2)
        {
            WaitPunch -= Time.deltaTime;
            if (WaitPunch <= 0)
            {
                WaitPunch = SaveWaitPunch;
                ControlPunch = 0;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (DirectionControl == Direction.Right)
            {
                other.GetComponent<Rigidbody>().AddForce(PunchSide * 50, ForceMode.Impulse);
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(-PunchSide * 50, ForceMode.Impulse);
            }
            
        }
    }
}
