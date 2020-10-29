using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoker : MonoBehaviour
{
    public GameObject ShokerExpanse;
    public float TimerExpanse;
    public bool ExpanseON = false;
    public ParticleSystem[] balls;

    
   
    public float ShokerStart;    

    // Update is called once per frame
    void Update()
    {

        ShokerStart -= Time.deltaTime;
        if (ShokerStart <= 0)
        {
            _ShokerExpanse();
            ShokerStart = 0;
        }      
    }

    public void _ShokerExpanse()
    {
        TimerExpanse += Time.deltaTime;

        if (!ExpanseON)
        {
            ShokerExpanse.GetComponent<SphereCollider>().enabled = false;
            
        }

        else
        {
            ShokerExpanse.GetComponent<SphereCollider>().enabled = true;
        }
        
        if(!ExpanseON && TimerExpanse > 7)
        {
            ExpanseON = true;
            TimerExpanse = 0;

            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].startSize = 1.15f;
            }
            
        }

        if (ExpanseON && TimerExpanse > 6)
        {
            ExpanseON = false;
            TimerExpanse = 0;
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].startSize = 0;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<Player>().respawning)
            {
                other.GetComponent<Player>().lifes--;

                if (other.GetComponent<Player_Controller>().isActiveAndEnabled)
                {
                    other.GetComponent<Player>().update_label(POWERUPS.LIFE);
                }

                if (other.GetComponent<Player>().lifes <= 0)
                {
                    other.GetComponent<Player>().dead = true; // 1
                    if (other.GetComponent<Player_Controller>().isActiveAndEnabled)
                    {

                        other.GetComponent<Player>().StartCoroutine(other.GetComponent<Player>().gameover_wait());
                    }

                    else
                    {

                        Destroy(gameObject);
                        FindObjectOfType<Global_Game_Controller>().update_labels();
                    }
                }

                else
                {
                    if (other.GetComponent<Player_Controller>().isActiveAndEnabled)
                    {
                        other.GetComponent<Player>().StartCoroutine(other.GetComponent<Player>().dmg_animation());
                    }

                    else
                    {

                    }

                    other.GetComponent<Player>().respawning = true;
                    other.GetComponent<Player>().StartCoroutine(other.GetComponent<Player>().respawn_wait());
                }

                Instantiate(other.GetComponent<Player>().Explosion, transform.position, Quaternion.identity);
            }            
        }
    }

}
