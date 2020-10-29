using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float ShootSpeed = 0.5f;

    public Vector3 Direction;
    public Vector3 Direction2;
    public Vector3 Direction3;

    public int Shoots;
    public float TimerShoot;
    public bool StartShoot = false;


    public GameObject Bullets;


    public GameObject First;
    public GameObject Second;
    public GameObject Third;

   

    void Update()
    {
        if (!StartShoot) return;
        ChargeShoot();
    }

    public void ChargeShoot()
    {
        
        TimerShoot += Time.deltaTime;
        if (Shoots == 0)
        {

            if (Bullets)
            {
                if (TimerShoot > 2f)
                {
                    Shoots++;

                    GameObject go = Instantiate(Bullets, First.transform.position, Bullets.transform.rotation);
                    go.GetComponent<Rigidbody>().AddForce(Direction * ShootSpeed);
                }
                
            }
        }

        if (Shoots == 1)
        {

            if (Bullets)
            {
                if (TimerShoot > 3f)
                {
                    Shoots++;

                    GameObject go1 = Instantiate(Bullets, Second.transform.position, Bullets.transform.rotation);
                    go1.GetComponent<Rigidbody>().AddForce(Direction2 * ShootSpeed);

                    GameObject go2 = Instantiate(Bullets, Third.transform.position, Bullets.transform.rotation);
                    go2.GetComponent<Rigidbody>().AddForce(Direction3 * ShootSpeed);

                    TimerShoot = 0;
                    Shoots = 0;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartShoot = true;
        }
    }

    
}
