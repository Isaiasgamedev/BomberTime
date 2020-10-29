using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int ExitControl;
    

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(ExitControl < LevelManager.LevelControl)
            {
                LevelManager.LevelControl++;
                SceneManager.LoadScene("Mission0" + ExitControl);
            }
            else
            {
                SceneManager.LoadScene("Mission0" + ExitControl);
            }

            
        }
    }
}
