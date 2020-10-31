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


        // get animation
        fade_script fade = new fade_script();
        // init fader
        foreach (fade_script f in FindObjectsOfType<fade_script>())
        {
            if (f.tag == "fader")
            {
                fade = f;
            }

            else
            {
                Debug.Log("TESTE");
                continue;
            }
        }

        // reset values


        // load map
        if (Application.CanStreamedLevelBeLoaded("Game"))
        {
            StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Mission0" + ExitControl));
        }

        else
        {
            StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Mission0" + ExitControl));
        }

    }
}
