using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
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

            Destroy(gameObject);           
        }

        else if(/*other.tag == "Breakable" || */other.tag == "Wall" || other.tag == "Block" || other.tag == "Door")
        {
            Destroy(gameObject);
        }

    }
}
